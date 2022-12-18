using System.Security.Claims;

namespace tutorium.Utils
{
    public static class Utility
    {
        public static void CreateHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
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
        public static int GetUserId(IHttpContextAccessor httpContextAccessor) => int.Parse(httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));
    }

}
