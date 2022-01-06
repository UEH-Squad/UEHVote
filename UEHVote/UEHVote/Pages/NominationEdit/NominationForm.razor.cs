using Blazored.Modal;
using Blazored.Modal.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UEHVote.Data.Interfaces;
using UEHVote.Data.Services;
using UEHVote.Models;

namespace UEHVote.Pages.NominationEdit
{
    public partial class NominationForm : ComponentBase
    {
        [Parameter]
        public Models.Candidate candidate { get; set; } = new Models.Candidate();
        [Parameter]
        public List<Organization> organizations { get; set; }
        [Parameter]
        public List<Models.Election> elections { get; set; }
        private string org;
        [Inject]
        ICandidateService ICandidateService { get; set; }
        [Inject]
        IElectionService IElectionService { get; set; }
        [Inject]
        NavigationManager NavigationManager { get; set; }
        [Inject]
        IUploadService IUploadService { get; set; }
        [Inject]
        IOrganizationService IOrganizationService { get; set; }
        List<string> image { get; set; } = new List<string>();
        private bool isChangeFile = false;

        private Nomination nomination = new() { };
        private IReadOnlyList<IBrowserFile> uploadFile;
        [CascadingParameter]
        public BlazoredModalInstance Modal { get; set; }
        [CascadingParameter]
        public IModalService ResultModal { get; set; }

        private async Task CloseModal()
        {
            await Modal.CloseAsync();
        }
        private async Task ShowResultModal()
        {
            var parameters = new ModalParameters();
            parameters.Add(nameof(ResultPopUp.candidate), candidate);
            var options = new Blazored.Modal.ModalOptions()
            {
                HideCloseButton = true,
                DisableBackgroundCancel = true,
                UseCustomLayout = true,
            };
            ResultModal.Show<ResultPopUp>("", parameters, options);
        }
        private async Task OnInputFile(InputFileChangeEventArgs e)
        {
            var imageFiles = e.GetMultipleFiles();
            uploadFile = imageFiles;
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

        protected async Task CreateCandidate()
        {

            await ICandidateService.InsertCandidate(candidate);
            if (image.Count != 0)
            {
                foreach (string item in image)
                {
                    CandidateImage candidateImage = new CandidateImage();
                    candidateImage.CandidateId = candidate.Id;
                    candidateImage.Url = item;
                    await ICandidateService.InsertCandidateImage(candidateImage);
                }

            }
            ShowResultModal();
        }
    }
}
