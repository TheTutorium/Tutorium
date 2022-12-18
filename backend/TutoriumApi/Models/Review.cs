using System.ComponentModel.DataAnnotations.Schema;

namespace tutorium.Models
{
    public class Review
    {
        // Primary Key
        public int Id { get; set; }

        // Attributes
        public string Comment { get; set; } = null!;
        public DateTime? UpdatedAt { get; set; }
        public DateTime CreatedAt { get; set; }


        [Column(TypeName = "decimal(3, 1)")]
        public decimal Rating { get; set; }

        // Foreign Keys
        public Course AffilatedCourse { get; set; } = null!;
        public int AffilatedCourseId { get; set; }
        public User AffilatedStudent { get; set; } = null!;
        public int AffilatedStudentId { get; set; }
    }
}
