using tutorium.Models;
using tutorium.Dtos.BookingDto;
using tutorium.Dtos.MaterialDto;
using tutorium.Dtos.ReviewDto;

namespace tutorium.Dtos.CourseDto
{
    public class GetCourseDto
    {
        public int Id { get; set; }
        public string Description { get; set; } = null!;
        public int Duration { get; set; } // In minutes
        public string Name { get; set; } = null!;
        public SubjectType Subject { get; set; }

        public string? DocumentPath { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public VerifiedStatusType VerifiedStatus { get; set; }

        public ICollection<BookingEndDto> Bookings { get; set; } = null!;
        public ICollection<MaterialEndDto> Materials { get; set; } = null!;
        public ICollection<ReviewEndDto> Reviews { get; set; } = null!;

        public int AffilatedTutorId { get; set; }
    }
}
