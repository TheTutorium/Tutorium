using System.ComponentModel.DataAnnotations.Schema;

namespace tutorium.Models
{
    public class Review
    {   
        // Primary Key
        public int Id { get; set; }

        // Attributes
        public string Comment { get; set; } = null!;

        [Column(TypeName = "decimal(2, 1)")]
        public decimal Rating { get; set; }

        // Foreign Keys
        public Course AffilatedCourse { get; set; } = null!;
        public int AffilatedCourseId { get; set; }
        public Student AffilatedStudent { get; set; } = null!;
        public int AffilatedStudentId { get; set; }
    }
}
