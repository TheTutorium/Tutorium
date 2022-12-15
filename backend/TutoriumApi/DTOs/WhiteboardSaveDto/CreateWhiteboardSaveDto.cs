namespace tutorium.Dtos.WhiteboardSaveDto
{
    public class CreateWhiteboardSaveDto
    {
        public DateTime? SaveDate { get; set; }
        public string SavePath { get; set; } = null!;


        public int AffilatedBookingId { get; set; }
    }
}
