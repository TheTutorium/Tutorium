namespace tutorium.Dtos.WhiteboardSaveDto
{
    public class CreateWhiteboardSaveDto
    {
        public IFormFile File { get; set; } = null!;

        public int AffilatedBookingId { get; set; }
    }
}
