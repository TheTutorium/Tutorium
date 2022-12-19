namespace tutorium.Services.FileService
{
    public class FileService : IFileService
    {
        private const string COMMON_DIR = "StaticFiles";
        private const string COURSE_DIR = $"{COMMON_DIR}/Courses";
        private const string BOOKING_DIR = $"{COMMON_DIR}/Bookings";

        private IWebHostEnvironment _hostingEnvironment;
        public FileService(IWebHostEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        public async Task<string> SaveFileAsync(int dirId, IFormFile file, FileType fileType)
        {
            var filePath = Path.Combine(GetDirectory(dirId, fileType), file.FileName);
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
            return filePath;
        }


        public void DeleteFile(string filePath)
        {
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
            else
            {
                // We should never be here. Log here to persistent storage.
            }
        }

        private string GetDirectory(int dirId, FileType fileType)
        {
            string common_dir = fileType == FileType.Material ? COURSE_DIR : BOOKING_DIR;
            string courseDir = Path.Combine(_hostingEnvironment.ContentRootPath, string.Format("{0}/{1}",
                common_dir, dirId));
            if (!Directory.Exists(courseDir))
            {
                Directory.CreateDirectory(courseDir);
            }
            return courseDir;
        }
    }

    public enum FileType
    {
        Material,
        WhiteboardSave
    }
}
