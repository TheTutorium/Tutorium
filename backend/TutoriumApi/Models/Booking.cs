namespace tutorium.Models
{
    public class Booking
    {
        // Primary Key
        public int Id { get; set; }

        // Attributes
        public CanceledBy? CanceledBy { get; set; }
        public DateTime Date { get; set; }

        // One-to-Many
        public ICollection<WhiteboardSave> WhiteboardSaves { get; set; } = null!;

        // Foreing Keys
        public Course AffilatedCourse { get; set; } = null!;
        public int AffilatedCourseId { get; set; }
        public Student AffilatedStudent { get; set; } = null!;
        public int AffilatedStudentId { get; set; }
    }

    public enum CanceledBy
    {
        Student,
        System,
        Tutor,
    }
}
