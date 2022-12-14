using tutorium.Models;

namespace tutorium.Dtos.UserDto
{
    public class GetUserDto
    {
        public int Id { get; set; }
        public string Email { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Token { get; set; } = null!;
        public UserType UserType { get; set; }
    }
}
