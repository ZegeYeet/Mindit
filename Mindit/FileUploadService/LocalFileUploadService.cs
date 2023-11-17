using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace Mindit.FileUploadService
{
    public class LocalFileUploadService : IFileUploadService
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        public LocalFileUploadService(IWebHostEnvironment environment)
        {
            this._webHostEnvironment = environment;
        }

        public async Task<string> GenerateFileNameAsync(string filePath)
        {
            var newFileName = Guid.NewGuid().ToString() + ".png";

            while (File.Exists(Path.Combine(filePath, newFileName)))
            {
                newFileName = Guid.NewGuid().ToString() + ".png";
            }

            return newFileName;
        }

        public async Task<string> UploadFileAsync(IFormFile file)
        {
            var filePath = Path.Combine(_webHostEnvironment.ContentRootPath, "wwwroot/Images/UserPictures");

            var fileName = await GenerateFileNameAsync(filePath);

            using var FileStream = new FileStream(Path.Combine(filePath, fileName), FileMode.Create);
            await file.CopyToAsync(FileStream);

            return fileName;
        }
    }
}
