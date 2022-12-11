namespace tutorium.Models
{
    public class Student : User 
    {
        // One-to-Many
        public ICollection<Booking> Bookings { get; set; } = null!;
    }
}
