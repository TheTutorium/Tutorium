namespace tutorium.Models
{
    public class Material
    {
        // Primary Key
        public int Id { get; set; }

        // Attributes
        public DateTime CreatedAt { get; set; }
        public string Description { get; set; } = null!;
        public string DisplayName { get; set; } = null!;
        public string FilePath { get; set; } = null!;
        public DateTime UpdatedAt { get; set; }

        // Foreign Keys
        public Course AffilatedCourse { get; set; } = null!;
        public int AffilatedCourseId { get; set; }
    }
}
