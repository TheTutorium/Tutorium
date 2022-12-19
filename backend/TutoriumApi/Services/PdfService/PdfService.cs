using tutorium.Services.FileService;
using tutorium.Models;
using iTextSharp.text;
using iTextSharp.text.pdf;


namespace tutorium.Services.PdfService
{
    public class PdfService : IPdfService
    {
        private IWebHostEnvironment _hostingEnvironment;
        private IFileService _fileService;
        public PdfService(IFileService fileService, IWebHostEnvironment hostingEnvironment)
        {
            _fileService = fileService;
            _hostingEnvironment = hostingEnvironment;
        }

        public string SavePdfAsync(int bookingId, IList<WhiteboardSave> whiteboardSaves)
        {
            string path = $"{_fileService.GetDirectory(bookingId, FileType.WhiteboardSave)}/Whiteboard.pdf";
            Document pdf = new Document(PageSize.LETTER);
            pdf.SetPageSize(iTextSharp.text.PageSize.LETTER.Rotate());
            using (var stream = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                PdfWriter.GetInstance(pdf, stream);
                pdf.Open();
                for (int i = 0; i < whiteboardSaves.Count; i++)
                {
                    using (var imageStream = new FileStream(whiteboardSaves[i].SavePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                    {
                        var image = Image.GetInstance(imageStream);
                        image.SetAbsolutePosition(10, 10);
                        image.ScaleAbsoluteHeight(pdf.PageSize.Height - 20);
                        image.ScaleAbsoluteWidth(pdf.PageSize.Width - 20);
                        pdf.Add(image);
                        pdf.NewPage();
                    }
                }
                pdf.Close();
            }
            return path;
        }
    }
}
