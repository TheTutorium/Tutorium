using tutorium.Models;

namespace tutorium.Dtos.UserDto
{
    public class SignupUserDto
    {
        public string Email { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Password { get; set; } = null!;
        public UserType UserType { get; set; }
    }
}
