using tutorium.Models;

namespace tutorium.Dtos.BookingDto
{
    public class BookingEndDto
    {
        public int Id { get; set; }

        public CanceledBy? CanceledBy { get; set; }
        public DateTime Date { get; set; }
        public int Duration { get; set; }

        public int AffilatedCourseId { get; set; }
        public int AffilatedStudentId { get; set; }
    }
}
