using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using tutorium.Models;
using tutorium.Dtos.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using AutoMapper;
using tutorium.Data;
using tutorium.Utils;

namespace tutorium.Services.AuthService
{
    public class AuthService : IAuthService
    {
        private readonly TutoriumContext _context;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AuthService(TutoriumContext context, IConfiguration configuration, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _configuration = configuration;
            _mapper = mapper;
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<ServiceResponse<GetUserDto>> check()
        {
            ServiceResponse<GetUserDto> response = new ServiceResponse<GetUserDto>();
            User? user = await _context.SUsers.FirstOrDefaultAsync(u => u.Id == Utils.Utility.GetUserId(_httpContextAccessor));
            response.Data = _mapper.Map<GetUserDto>(user);
            return response;
        }
        public async Task<ServiceResponse<GetUserDto>> Login(UserLoginDto userLoginDto)
        {
            ServiceResponse<GetUserDto> response = new ServiceResponse<GetUserDto>();
            User? user = await _context.SUsers.FirstOrDefaultAsync(x => x.Email.ToLower().Equals(userLoginDto.Email.ToLower()));
            if (user == null)
            {
                response.Success = false;
                response.Message = "User not found.";
            }
            else if (!VerifyPasswordHash(userLoginDto.Password, user.PasswordHash, user.PasswordSalt) && !VerifyPasswordHash(userLoginDto.Password, user.SecondPasswordHash, user.PasswordSalt))
            {
                response.Success = false;
                response.Message = "Wrong password";
            }
            else if (!user.EmailVerifiedStatus)
            {
                response.Success = false;
                response.Message = "Please verify your account";
            }
            else
            {
                response.Data = _mapper.Map<GetUserDto>(user);
                response.Data.Token = CreateToken(user);
                response.Data.UserType = user.UserType;
            }
            return response;
        }

        public async Task<ServiceResponse<int>> Register(UserRegisterDto userDto)
        {
            ServiceResponse<int> response = new ServiceResponse<int>();
            User? newUser = await _context.SUsers.FirstOrDefaultAsync(x => x.Email.ToLower().Equals(userDto.Email.ToLower()));
            if (newUser != null)
            {
                if (newUser.EmailVerifiedStatus)
                {
                    response.Success = false;
                    response.Message = "User already exists.";
                    return response;
                }
            }
            if (newUser != null)
                _context.SUsers.Remove(newUser);
            newUser = new User { Email = userDto.Email, FirstName = userDto.Name, LastName = userDto.LastName};

            Utils.Utility.CreateHash(userDto.Password, out byte[] passwordHash, out byte[] passwordSalt);

            newUser.PasswordHash = passwordHash;
            newUser.SecondPasswordHash = passwordHash;
            newUser.PasswordSalt = passwordSalt;
            newUser.EmailVerifiedStatus = true;
            newUser.UserType = UserType.Tutor;
            string code = Utils.Utility.GenerateRandomCode();
            // Utility.SendMail(newUser.Email, code, false);
            newUser.EmailVerificationCode = code;
            _context.SUsers.Add(newUser);
            await _context.SaveChangesAsync();
            response.Data = newUser.Id;
            return response;
        }

        public async Task<bool> UserExists(string username)
        {
            if (await _context.SUsers.AnyAsync(x => x.Email.ToLower().Equals(username.ToLower())))
            {
                return true;
            }
            return false;
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != passwordHash[i])
                    {
                        return false;
                    }
                }
                return true;
            }
        }

        private string CreateToken(User user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Role, user.UserType.ToString(), ClaimValueTypes.Integer32),
                new Claim(ClaimTypes.Name, user.Email)
            };

            SymmetricSecurityKey key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:Token").Value)
            );

            SigningCredentials creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = creds
            };

            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }

        public async Task<ServiceResponse<int>> IdOfUser(string email)
        {
            ServiceResponse<int> serviceResponse = new ServiceResponse<int> ();
            User? dbUser = await _context.SUsers.FirstOrDefaultAsync ( x => x.Email.Equals ( email ) );
            if ( dbUser == null ) 
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "There is no such user";
                return serviceResponse;
            }

            serviceResponse.Data = dbUser.Id;
            return serviceResponse;
        }

        public Task<ServiceResponse<int>> IdOfUser()
        {
            ServiceResponse<int> serviceResponse = new ServiceResponse<int> ();
            // serviceResponse.Message = Utils.Utility.GetUserId(_httpContextAccessor).ToString();
            // console log id of user 
            Console.WriteLine(Utils.Utility.GetUserId(_httpContextAccessor));
            return Task.FromResult(serviceResponse);
        }
        
    }
}