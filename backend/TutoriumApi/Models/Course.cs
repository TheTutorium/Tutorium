namespace tutorium.Models
{
    public class Course 
    {   
        // Primary Key
        public int Id { get; set; }

        // Attributes
        public string Description { get; set; } = null!;
        public int Duration { get; set; }  // In minutes
        public string Name { get; set; } = null!;
        public SubjectType Subject { get; set; }

        // One-to-Many
        public ICollection<Booking> Bookings { get; set; } = null!;
        public ICollection<Material> Materials { get; set; } = null!;
        public ICollection<Review> Reviews { get; set; } = null!;

        // Foreign Keys
        public Tutor AffilatedTutor { get; set; } = null!;
        public int AffilatedTutorId { get; set; }
    }

    public enum SubjectType
    {
        Biology,
        Chemistry,
        Coding,
        English,
        Geography,
        History,
        Mathematics,
        Philosophy,
        Physics,
        ReligionCulture,
        Turkish,
        TurkishLiterature,
        Other,
    }
}
