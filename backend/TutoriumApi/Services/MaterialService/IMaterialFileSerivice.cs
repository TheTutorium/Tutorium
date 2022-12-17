namespace tutorium.Services.MaterialService
{
    public interface IMaterialFileService
    {
        Task<string> SaveFileAsync(int courseId, IFormFile file);
        void DeleteFile(string filePath);
    }
}
