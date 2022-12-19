using System.Security.Claims;
using tutorium.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace tutorium.Utils
{
    public static class Auth
    {
        public static void CreateHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        public static string CreateToken(User user, string secretToken)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Role, user.UserType.ToString(), ClaimValueTypes.Integer32),
                new Claim(ClaimTypes.Name, user.Email)
            };

            SymmetricSecurityKey key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(secretToken)
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

        public static string GenerateRandomCode()
        {
            string ret = "";
            Random random = new Random();
            int len = 12;
            for (int i = 0; i < len; i++)
            {
                char tmp = (char)('1' + (random.Next() % 9));
                ret = ret + tmp.ToString();
            }
            return ret;
        }

        public static int? GetUserId(IHttpContextAccessor httpContextAccessor)
        {
            string? userId = httpContextAccessor.HttpContext!.User.FindFirstValue(ClaimTypes.NameIdentifier);
            return userId != null ? int.Parse(userId) : null;
        }

        public static bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
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
    }
}
