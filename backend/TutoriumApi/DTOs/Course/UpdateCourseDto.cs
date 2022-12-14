using tutorium.Models;

namespace tutorium.Dtos.CourseDto
{
    public class UpdateCourseDto
    {
        public int Id { get; set; }
        public string Description { get; set; } = null!;
        public int Duration { get; set; } // In minutes
        public string Name { get; set; } = null!;
        public SubjectType Subject { get; set; }


        public string? DocumentPath { get; set; }

    }
}
