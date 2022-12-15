using tutorium.Models;

namespace tutorium.Dtos.BookingDto
{
    public class UpdateBookingDto
    {
        public int Id { get; set; }
        public CanceledBy? CanceledBy { get; set; }
    }
}
