using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Threading.Tasks;
using UEHVote.Data.Interfaces;
using UEHVote.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace UEHVote.Pages.Candidate
{
    /// <summary>
    /// UPDATE CANDIDATE
    /// </summary>
    public partial class UpdateCandidate : ComponentBase
    {
        Models.Candidate candidate = new Models.Candidate();
        List<CandidateImage> listCandidateImages = new List<CandidateImage>();
        List<string> image { get; set; } = new List<string>();
        private IReadOnlyList<IBrowserFile> selectedImages;
        private bool isChangeFile;

        [Parameter]
        public string CurrentId { get; set; }
        [Inject]
        ICandidateService ICandidateService { get; set; }
        [Inject]
        NavigationManager NavigationManager { get; set; }
        [Inject]
        IUploadService IUploadService { get; set; }
        protected override async Task OnInitializedAsync()
        {
            candidate = await ICandidateService.GetCandidateAsync(Convert.ToInt32(CurrentId));
        }
        protected async Task Update()
        {
            await ICandidateService.UpdateCandidate(candidate);
            foreach (CandidateImage item in listCandidateImages)
            {
                if (CurrentId.Equals(Convert.ToString(item.CandidateId)))
                {
                    await ICandidateService.DeleteCandidateImage(item);
                }
            }
            foreach (string item in image)
            {
                CandidateImage candidateImage = new CandidateImage();
                candidateImage.CandidateId = Convert.ToInt32(CurrentId);
                candidateImage.Url = item;
                await ICandidateService.InsertCandidateImage(candidateImage);
            }
            NavigationManager.NavigateTo("Candidate");
        }
        void Cancel()
        {
            NavigationManager.NavigateTo("Candidate");
        }
        private async Task OnUpdateFile(InputFileChangeEventArgs e)
        {
            var imageFiles = e.GetMultipleFiles();
            selectedImages = imageFiles;
            image.Clear();
            isChangeFile = true;
            foreach (var file in imageFiles)
            {
                if (file.ContentType != "image/jpeg")
                {
                    this.StateHasChanged();
                }
                else
                {
                    string x = await IUploadService.SaveImageAsync(file, Convert.ToString(candidate.Id));
                    image.Add(x);
                }
            }
        }
    }
}
