namespace tutorium.Services.MaterialService
{
    public class MaterialFileService : IMaterialFileService
    {
        private const string COMMON_MATERIAL_DIR = "StaticFiles/Materials";
        private IWebHostEnvironment _hostingEnvironment;

        public MaterialFileService(IWebHostEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        public async Task<string> SaveFileAsync(int courseId, IFormFile file)
        {
            var filePath = Path.Combine(GetCourseDirectory(courseId), file.FileName);
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

        private string GetCourseDirectory(int courseId)
        {
            string courseDir = Path.Combine(_hostingEnvironment.ContentRootPath, string.Format("{0}/{1}",
                COMMON_MATERIAL_DIR, courseId));
            if (!Directory.Exists(courseDir))
            {
                Directory.CreateDirectory(courseDir);
            }
            return courseDir;
        }
    }
}
