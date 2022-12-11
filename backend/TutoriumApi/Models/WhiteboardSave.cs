namespace tutorium.Models
{
    public class WhiteboardSave 
    {   
        // Primary Key
        public int Id { get; set; }

        // Attributes
        public string ImagePath { get; set; } = null!;
        public DateTime SaveTime { get; set; }

        // Foreign Keys
        public Booking AffilatedBooking { get; set; } = null!;
        public int AffilatedBookingId { get; set; }
    }
}
