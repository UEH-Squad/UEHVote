using Hangfire;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using UEHVote.Data.Interfaces;
using UEHVote.Models;

namespace UEHVote.Data.Services
{
    public class UploadService : IUploadService
    {
        /// <summary>
        /// UpLoadService
        /// HANDLE IMAGE
        /// </summary>
        private readonly IWebHostEnvironment _webHostEnvironment;
        private const long MaxFileSize = 1024 * 1024 * 15;
        private const int MaxWidthFile = 2048;
        private const int MaxHeightFile = 2048;
        private const string FormatFile = "image/jpeg";
        private string Path => @$"{_webHostEnvironment.WebRootPath}\";
        public UploadService(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }
        public async Task<string> GetDataUriAsync(IBrowserFile file)
        {
            file = await file.RequestImageFileAsync(FormatFile, MaxWidthFile, MaxHeightFile);
            using Stream stream = file.OpenReadStream(MaxFileSize);
            using MemoryStream memoryStream = new();
            await stream.CopyToAsync(memoryStream);
            return $"data:image/jpeg;base64,{Convert.ToBase64String(memoryStream.ToArray())}";
        }
        public async Task<string> SaveImageAsync(IBrowserFile file, string ElectionId)
        {
            if (!file.ContentType.Contains("image/"))
            {
                throw new Exception("Invalid file type!");
            }
            file = await file.RequestImageFileAsync(FormatFile, MaxWidthFile, MaxHeightFile);
            const string imgFolder = @"img\elections";
            string fileName = @$"{imgFolder}\{DateTime.Now.ToFileTime()}_{ElectionId}.jpg";
            Directory.CreateDirectory(System.IO.Path.Combine(_webHostEnvironment.WebRootPath, imgFolder));
            using FileStream fileStream = File.Create(@$"{Path}\{fileName}");
            using Stream stream = file.OpenReadStream(MaxFileSize);
            await stream.CopyToAsync(fileStream);
            return fileName;
        }
        public void RemoveImage(string fileName)
        {
            File.Delete(@$"{Path}\{fileName}");
        }
        public void JobCleaning(string urlFile)
        {
            File.Delete(urlFile);
        }
    }
}
