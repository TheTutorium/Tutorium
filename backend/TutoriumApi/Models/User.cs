using System.ComponentModel.DataAnnotations;

namespace tutorium.Models
{
    public class User
    {
        // Primary Key
        public int Id { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!;
        public string? EmailVerificationCode { get; set; }
        public bool EmailVerifiedStatus { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public byte[] PasswordHash { get; set; } = null!;
        public byte[] SecondPasswordHash { get; set; } = null!;
        public byte[] PasswordSalt { get; set; } = null!;
        [Phone]
        public string? Phone { get; set; }

        public string? PhoneVerificationCode { get; set; }
        public bool PhoneVerifiedStatus { get; set; }

        public string? Description { get; set; } 
        public string? ImagePath { get; set; }
        public virtual ICollection<Course> Courses { get; set; } = null!;
        public virtual ICollection<Booking> Bookings { get; set; } = null!;
        public virtual ICollection<Review> Reviews { get; set; } = null!;
        public UserType UserType { get; set; } = UserType.Student;
    }

    public enum UserType
    {
        Student,
        Tutor
    }
}
