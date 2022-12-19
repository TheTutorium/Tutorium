namespace tutorium.Dtos.WhiteboardSaveDto
{
    public class GetWhiteboardSaveDto
    {
        public int Id { get; set; }

        public string SavePath { get; set; } = null!;
        public DateTime SaveTime { get; set; }

        public int AffilatedBookingId { get; set; }
    }
}
