using tutorium.Models;
using tutorium.Dtos.UserDto;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using tutorium.Data;
using tutorium.Utils;
using tutorium.Exceptions;

namespace tutorium.Services.AuthService
{
    public class AuthService : IAuthService
    {
        private readonly TutoriumContext _context;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AuthService(TutoriumContext context, IConfiguration configuration, IHttpContextAccessor httpContextAccessor, IMapper mapper)
        {
            _configuration = configuration;
            _mapper = mapper;
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<GetUserDto> CheckUser()
        {
            User? user = await _context.Users.FirstOrDefaultAsync(u => u.Id == Auth.GetUserId(_httpContextAccessor));
            if (user == null)
            {
                throw new BadRequestException("No user is logged in.");
            }
            return _mapper.Map<GetUserDto>(user);
        }

        public async Task<bool> DoesUserExist(string username)  // TODO: We do not use it?
        {
            return await _context.Users.AnyAsync(x => x.Email.ToLower().Equals(username.ToLower()));
        }

        public async Task<int> GetUserId(string email)
        {
            User? user = await _context.Users.FirstOrDefaultAsync(x => x.Email.Equals(email));
            if (user == null)
            {
                throw new BadRequestException("There is no such user.");
            }
            return user.Id;
        }

        public async Task<GetUserDto> Login(LoginUserDto loginUserDto)
        {
            User? user = await _context.Users.FirstOrDefaultAsync(x => x.Email.ToLower().Equals(loginUserDto.Email.ToLower()));
            if (user == null)
            {
                throw new NotFoundException("User not found.");
            }
            else if (!Auth.VerifyPasswordHash(loginUserDto.Password, user.PasswordHash, user.PasswordSalt) && !Auth.VerifyPasswordHash(loginUserDto.Password, user.SecondPasswordHash, user.PasswordSalt))
            {
                throw new BadRequestException("Wrong password.");
            }
            else if (!user.EmailVerifiedStatus)
            {
                throw new BadRequestException("Please verify your email.");
            }

            GetUserDto getUserDto = _mapper.Map<GetUserDto>(user);
            getUserDto.Token = Auth.CreateToken(user, _configuration.GetSection("AppSettings:Token").Value!);
            return getUserDto;
        }

        public async Task<int> Register(SignupUserDto signupUserDto)
        {
            User? newUser = await _context.Users.FirstOrDefaultAsync(x => x.Email.ToLower().Equals(signupUserDto.Email.ToLower()));
            if (newUser != null)
            {
                throw new BadRequestException("User already exists.");
            }

            newUser = new User { Email = signupUserDto.Email, FirstName = signupUserDto.FirstName, LastName = signupUserDto.LastName };
            Auth.CreateHash(signupUserDto.Password, out byte[] passwordHash, out byte[] passwordSalt);
            string code = Auth.GenerateRandomCode();

            newUser.EmailVerificationCode = code;
            newUser.EmailVerifiedStatus = true; // Utility.SendMail(newUser.Email, code, false);
            newUser.PasswordHash = passwordHash;
            newUser.SecondPasswordHash = passwordHash;
            newUser.PasswordSalt = passwordSalt;
            newUser.UserType = signupUserDto.UserType;

            _context.Users.Add(newUser);
            await _context.SaveChangesAsync();
            return newUser.Id;
        }
    }
}
