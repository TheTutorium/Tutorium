namespace tutorium.Models
{
    public class Tutor : User
    {
        public string Description { get; set; } = null!;        
        public string? ImagePath { get; set; }

        // One-to-Many
        public ICollection<Course> Courses { get; set; } = null!;
    }
}
