namespace tutorium.Services.FileService
{
    public interface IFileService
    {
        void DeleteFile(string filePath);
        public string GetDirectory(int dirId, FileType fileType);
        public byte[] GetFile(string fullPath);
        Task<string> SaveFileAsync(int dirName, IFormFile file, FileType fileType);
    }
}
