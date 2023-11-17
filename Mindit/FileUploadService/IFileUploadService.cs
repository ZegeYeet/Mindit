namespace Mindit.FileUploadService
{
    public interface IFileUploadService
    {
        Task<string> UploadFileAsync(IFormFile file);

        Task<string> GenerateFileNameAsync(string filePath);
    }
}
