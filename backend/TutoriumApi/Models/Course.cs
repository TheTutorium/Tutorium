namespace tutorium.Models
{
    public class Course
    {
        // Primary Key
        public int Id { get; set; }

        // Attributes
        public string Description { get; set; } = null!;
        public int Duration { get; set; }  // In minutes
        public string Name { get; set; } = null!;  // If course is verifable then it names must be from 'VerifableCourseTypes'
        public SubjectType Subject { get; set; }

        // Verifiable Course Attributes
        public string? DocumentPath { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public VerifiedStatusType VerifiedStatus { get; set; }

        // One-to-Many
        public ICollection<Booking> Bookings { get; set; } = null!;
        public ICollection<Material> Materials { get; set; } = null!;
        public ICollection<Review> Reviews { get; set; } = null!;

        // Foreign Keys
        public Tutor AffilatedTutor { get; set; } = null!;
        public int AffilatedTutorId { get; set; }
    }

    public enum VerifiedStatusType
    {
        NotVerifable,
        NotVerified,
        InProcess,
        Verified
    }

    public enum SubjectType
    {
        English,
        Mathematics,
        Other,
    }

    static class VerifableCourseTypes
    {
        public const string YKS = "YKS";
    }
}
