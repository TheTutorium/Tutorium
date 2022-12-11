using System.ComponentModel.DataAnnotations;

namespace tutorium.Models
{
    public abstract class User
    {
        // Primary Key
        public int Id { get; set; }

        // Attributes
        public string Email { get; set; } = null!;
        public string? EmailVerificationCode { get; set; }
        public bool EmailVerifiedStatus { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public byte[] PasswordHash { get; set; } = null!;
        public byte[] PasswordSalt { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public string? PhoneVerificationCode { get; set; }
        public bool PhoneVerifiedStatus { get; set; }

    }
}
