using AntDesign;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using UEHVote.Data.Interfaces;
using UEHVote.Data.ViewModels;
using UEHVote.Models;

namespace UEHVote.Shared.Components
{
    public partial class PicturesWall:ComponentBase
    {
        [Inject]
         MessageService _message { get; set; }
        [Inject]
        IUploadService IUploadService { get; set; }
        [Parameter]
        public string CurrentId { get; set; }
        bool previewVisible = false;
        string previewTitle = string.Empty;
        string imgUrl = string.Empty;
        [Parameter]
        public List<string> images { get; set; }
        private List<ActivityImage> activityImages = new List<ActivityImage>();
        private List<CandidateImage> candidateImages = new List<CandidateImage>();
        [Parameter]
        public List<string> imagesCandidate { get; set; }
        List<UploadFileItem> fileList = new List<UploadFileItem>();
        [Parameter]
        public EventCallback<List<string>> HandleImagesElection { get; set; }
        [Parameter]
        public EventCallback<List<string>> HandleImagesCandidate { get; set; }
        [Inject]
        IElectionService IElectionService { get; set; }
        [Inject]
        ICandidateService ICandidateService { get; set; }
        protected override async Task OnInitializedAsync()
        {
            activityImages = (await IElectionService.GetAllActivityImagesAsync()).Where(t => t.ElectionId.ToString() == CurrentId).ToList();
            candidateImages = (await ICandidateService.GetAllCandidateImagesAsync()).Where(t => t.CandidateId.ToString()==CurrentId).ToList();
        }
        void UploadCompleted(UploadInfo uploadInfo)
        {
            var response = uploadInfo.File.GetResponse<UploadResponseViewModel>();
            if (!CurrentId.Contains("id="))
            {
                if (!images.Contains(response.FileName))
                {
                    images.Add(response.FileName);
                }
            }
            else
            {
                if (!imagesCandidate.Contains(response.FileName))
                {
                    imagesCandidate.Add(response.FileName);
                }
            }
        }
        async Task<bool> RemoveImage(UploadFileItem file)
        {
            var response =file.GetResponse<UploadResponseViewModel>();
            if(!CurrentId.Contains("id="))
            {
                images.Remove(response.FileName);
            }
            else
            {
                imagesCandidate.Remove(response.FileName);
            }
            IUploadService.RemoveImage(response.FileName);
            return true;
        }
    }
}
