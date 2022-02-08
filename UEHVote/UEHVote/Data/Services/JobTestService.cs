using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using UEHVote.Data.Context;
using UEHVote.Data.Interfaces;
using UEHVote.Models;

namespace UEHVote.Data.Services
{
    public class JobTestService: IJobTestService
    {
        /// <summary>
        /// JobTestService
        /// HANDLE HANGFIRE DELETE IMAGE
        /// </summary>
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IDbContextFactory<ApplicationDbContext> _dbContextFactory;
        private readonly IUploadService _uploadService;
        private string Path => @$"{_webHostEnvironment.WebRootPath}";
        public JobTestService(IWebHostEnvironment webHostEnvironment,IDbContextFactory<ApplicationDbContext> dbContextFactory,IUploadService uploadService)
        {
            _webHostEnvironment = webHostEnvironment;
            _dbContextFactory = dbContextFactory;
            _uploadService = uploadService;
        }
        public void FireAndForgetJob()
        {
            Console.WriteLine("Hello from a Fire and Forget job!");
        }
        public void ReccuringJob()
        {
            var context = _dbContextFactory.CreateDbContext();
            List<string> activityImages = context.ActivityImages.Select(t => t.Url).ToList();
            List<string> candidateImages = context.CandidateImages.Select(t => t.Url).ToList();
            List<string> bannerElections = context.Elections.Select(t => t.Banner).ToList();
            const string imgFolder = @"img\elections";
            string fileName = @$"{Path}\{imgFolder}";
            string[] files = Directory.GetFiles(fileName);
            foreach (var item in files)
            {
                var urlImg = item.Replace(Path + "\\", "");
                if (!bannerElections.Contains(urlImg) && !activityImages.Contains(urlImg) && !candidateImages.Contains(urlImg))
                {
                    _uploadService.JobCleaning(item);
                }
            }
        }
        public void DelayedJob()
        {
            Console.WriteLine("Hello from a Delayed job!");
        }
        public void ContinuationJob()
        {
            Console.WriteLine("Hello from a Continuation job!");
        }
    }
}
