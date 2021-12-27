using Blazored.Modal;
using Blazored.Modal.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UEHVote.Data.Interfaces;
using UEHVote.Data.Services;
using UEHVote.Models;

namespace UEHVote.Pages.NominationEdit
{
    public partial class ConfirmPopUp
    {
        [Parameter]
        public Models.Candidate candidate { get; set; } = new Models.Candidate();
        [Parameter]
        public List<Organization> organizations { get; set; }
        [Parameter]
        public List<Models.Candidate> candidates { get; set; }
        [Parameter]
        public List<Models.Candidate> result { get; set; }
        [CascadingParameter]
        public BlazoredModalInstance Modal { get; set; }
        [CascadingParameter]
        public IModalService ResultModal { get; set; }
        [Inject]
        ICandidateService ICandidateService { get; set; }
        [Inject]
        private IOrganizationService IOrganizationService { get; set; }
        [Inject]
        IElectionService IElectionService { get; set; }
        [Inject]
        NavigationManager NavigationManager { get; set; }
        List<string> image { get; set; } = new List<string>();

        private async Task CloseModal()
        {
            await Modal.CloseAsync();
        }

        protected override async Task OnInitializedAsync()
        {
            organizations = await IOrganizationService.GetAllOrganizationsAsync();
            candidates = await ICandidateService.GetAllCandidatesAsync();
            result = candidates.ToList();

        }

        private async Task ShowResultModal()
        {
            var parameters = new ModalParameters();
            parameters.Add(nameof(NominationForm.candidate), candidate);
            var options = new Blazored.Modal.ModalOptions()
            {
                HideCloseButton = true,
                DisableBackgroundCancel = true,
                UseCustomLayout = true,
            };
            await Modal.CloseAsync();
            ResultModal.Show<ResultPopUp>("",parameters, options);
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


        /*private async Task ShowResultModal()
        {
            var parameters = new ModalParameters();
            parameters.Add(nameof(CreateConfirm.candidate), candidate);
            var options = new Blazored.Modal.ModalOptions()
            {
                HideCloseButton = true,
                DisableBackgroundCancel = true,
                UseCustomLayout = true,
            };
            ResultModal.Show<CreateConfirm>("", parameters, options);
        }*/
    }
}
