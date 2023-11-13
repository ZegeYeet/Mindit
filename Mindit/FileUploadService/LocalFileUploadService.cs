﻿using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace Mindit.FileUploadService
{
    public class LocalFileUploadService : IFileUploadService
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        public LocalFileUploadService(IWebHostEnvironment environment)
        {
            this._webHostEnvironment = environment;
        }

        public async Task<string> UploadFile(IFormFile file)
        {
            var filePath = Path.Combine(_webHostEnvironment.ContentRootPath, "Images/UserPictures", file.FileName);

            using var FileStream = new FileStream(filePath, FileMode.Create);
            await file.CopyToAsync(FileStream);

            return filePath;
        }
    }
}
