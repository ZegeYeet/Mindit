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

        public async Task<string> UploadFileAsync(IFormFile file)
        {
            var filePath = Path.Combine(_webHostEnvironment.ContentRootPath, "wwwroot/Images/UserPictures", file.FileName);

            if (File.Exists(filePath))
            {
                return null;
            }

            using var FileStream = new FileStream(filePath, FileMode.Create);
            await file.CopyToAsync(FileStream);

            return filePath;
        }
    }
}
