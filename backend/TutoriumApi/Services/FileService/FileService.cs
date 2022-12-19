using ICSharpCode.SharpZipLib.Zip;
using tutorium.Exceptions;


namespace tutorium.Services.FileService
{
    public static class FilePaths
    {
        public const string COMMON_DIR = "StaticFiles";
        public const string COURSES_DIR = $"{COMMON_DIR}/Courses";
        public const string BOOKINGS_DIR = $"{COMMON_DIR}/Bookings";
    }

    public class FileService : IFileService
    {
        private IWebHostEnvironment _hostingEnvironment;
        public FileService(IWebHostEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        public void DeleteFile(string filePath)
        {
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }

        public string GetDirectory(int id, FileType fileType)
        {
            string path = $"{(fileType == FileType.Material ? FilePaths.COURSES_DIR : FilePaths.BOOKINGS_DIR)}/{id}/{fileType}";
            string fullPath = Path.Combine(_hostingEnvironment.ContentRootPath, path);
            if (!Directory.Exists(fullPath))
            {
                Directory.CreateDirectory(fullPath);
            }
            return fullPath;
        }

        public byte[] GetFile(string fullPath)
        {
            string? dirName = Path.GetDirectoryName(fullPath);
            if (dirName == null)
            {
                throw new BadRequestException("Something wrong. Try again.");
            }
            string fileName = Path.GetFileName(fullPath);

            var tempOutput = $"{dirName}/{fileName}.zip";
            using (ZipOutputStream zipOutputStream = new ZipOutputStream(System.IO.File.Create(tempOutput)))
            {
                zipOutputStream.SetLevel(9);
                byte[] buffer = new byte[4096];
                ZipEntry zipEntry = new ZipEntry(Path.GetFileName(fullPath));
                zipEntry.DateTime = DateTime.Now;
                zipEntry.IsUnicodeText = true;
                zipOutputStream.PutNextEntry(zipEntry);
                using (FileStream fileStream = System.IO.File.OpenRead(fullPath))
                {
                    int sourceBytes;
                    do
                    {
                        sourceBytes = fileStream.Read(buffer, 0, buffer.Length);
                        zipOutputStream.Write(buffer, 0, sourceBytes);
                    } while (sourceBytes > 0);
                }

                zipOutputStream.Finish();
                zipOutputStream.Flush();
                zipOutputStream.Close();

                byte[] finalResult = System.IO.File.ReadAllBytes(tempOutput);
                if (System.IO.File.Exists(tempOutput))
                {
                    System.IO.File.Delete(tempOutput);
                }
                if (finalResult == null || !finalResult.Any())
                {
                    throw new BadRequestException("Unknown error. Try again");
                }
                return finalResult;
            }
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
    }

    public enum FileType
    {
        Material,
        WhiteboardPdf,
        WhiteboardSave
    }
}
