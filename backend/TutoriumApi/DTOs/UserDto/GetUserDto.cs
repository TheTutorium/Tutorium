using tutorium.Models;

namespace tutorium.Dtos.User
{
    public class GetUserDto
    {
        public int Id { get; set; }
        public string Email { get; set; } = "";
        public string Name { get; set; } = "";
        public string Token { get; set; }
        public UserType UserType { get; set; }
    }
}
