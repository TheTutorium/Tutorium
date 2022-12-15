using tutorium.Models;
using tutorium.Dtos.WhiteboardSaveDto;

namespace tutorium.Dtos.BookingDto
{
    public class GetBookingEndDto
    {
        public int Id { get; set; }

        public CanceledBy? CanceledBy { get; set; }
        public DateTime Date { get; set; }
        public int Duration { get; set; }

        public ICollection<WhiteboardSaveEndDto> WhiteboardSaves { get; set; } = null!;


        public int AffilatedCourseId { get; set; }
        public int AffilatedStudentId { get; set; }
    }
}
