namespace tutorium.Dtos.BookingDto
{
    public class CreateBookingDto
    {
        public DateTime Date { get; set; }
        public int AffilatedCourseId { get; set; }
        public int AffilatedStudentId { get; set; }
    }
}
