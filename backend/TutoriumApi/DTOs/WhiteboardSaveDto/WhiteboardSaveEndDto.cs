namespace tutorium.Dtos.WhiteboardSaveDto
{
    public class WhiteboardSaveEndDto
    {
        public int Id { get; set; }

        public string SavePath { get; set; } = null!;
        public DateTime SaveTime { get; set; }

        public int AffilatedBookingId { get; set; }
    }
}
