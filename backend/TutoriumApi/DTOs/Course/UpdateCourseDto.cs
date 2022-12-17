using tutorium.Models;

namespace tutorium.Dtos.CourseDto
{
    public class UpdateCourseDto
    {
        public string? Description { get; set; } = null!;
        public int? Duration { get; set; } // In minutes
        public SubjectType? Subject { get; set; }

        public string? DocumentPath { get; set; }
    }
}
