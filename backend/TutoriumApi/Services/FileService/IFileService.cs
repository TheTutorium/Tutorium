namespace tutorium.Services.FileService
{
    public interface IFileService
    {
        Task<string> SaveFileAsync(int dirName, IFormFile file, FileType fileType);
        void DeleteFile(string filePath);
    }
}
