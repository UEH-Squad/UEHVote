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
    /// CREATE CANDIDATE
    /// </summary>
    public partial class AddCandidate : ComponentBase
    {
        Models.Candidate candidate = new Models.Candidate();
        List<string> imagecandidate { get; set; } = new List<string>();
        private bool isChangeFile = true;
        private IReadOnlyList<IBrowserFile> selectedImages;
        [Inject]
        ICandidateService ICandidateService { get; set; }
        [Inject]
        NavigationManager NavigationManager { get; set; }
        [Inject]
        IUploadService IUploadService { get; set; }
        protected async Task CreateCandidate()
        {
            await ICandidateService.InsertCandidate(candidate);
            if (imagecandidate.Count != 0)
            {
                foreach (string item in imagecandidate)
                {
                    CandidateImage candidateImage = new CandidateImage();
                    candidateImage.CandidateId = candidate.Id;
                    candidateImage.Url = item;
                    await ICandidateService.InsertCandidateImage(candidateImage);
                }
            }
            NavigationManager.NavigateTo("Candidate");
        }
        void Cancel()
        {
            NavigationManager.NavigateTo("Candidate");
        }
        private async Task OnInputFile(InputFileChangeEventArgs e)
        {
            var imageFiles = e.GetMultipleFiles();
            selectedImages = imageFiles;
            imagecandidate.Clear();
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
                    imagecandidate.Add(x);
                }
            }
        }
    }
}
