using tutorium.Models;

namespace tutorium.Services.PdfService
{
    public interface IPdfService
    {
        public string SavePdfAsync(int bookingId, IList<WhiteboardSave> whiteboardSaves);
    }
}
