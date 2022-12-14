using tutorium.Models;

namespace tutorium.Dtos.Course
{
    public class UpdateBookingDto
    {
        public int Id { get; set; }
        public CanceledBy? CanceledBy { get; set; }
    }
}
