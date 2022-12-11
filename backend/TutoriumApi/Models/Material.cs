namespace tutorium.Models
{
    public class Material
    {
        // Primary Key
        public int Id { get; set; }

        // Attributes
        public string FilePath { get; set; } = null!;

        // Foreign Keys
        public Course AffilatedCourse { get; set; } = null!;
        public int AffilatedCourseId { get; set; }
    }
}
