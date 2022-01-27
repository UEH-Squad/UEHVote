using Blazored.Modal;
using Blazored.Modal.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UEHVote.Data.Interfaces;
using UEHVote.Models;

namespace UEHVote.Pages.NominationEdit
{
    public partial class PopupNominationForm : ComponentBase
    {
        private List<Organization> organizations = new List<Organization>();
        private List<CandidateImage> candidateImages = new List<CandidateImage>();
        [Parameter]
        public Models.Candidate candidate { get; set; } = new Models.Candidate();
        [Parameter]
        public List<string> imagesCandidate { get; set; }
        [Parameter]
        public Dictionary<Candidate,List<string>> InformationCandidate { get; set; }
        [CascadingParameter]
        public BlazoredModalInstance Modal { get; set; }
        [CascadingParameter]
        public IModalService ResultModal { get; set; }
        [Inject]
        IOrganizationService IOrganizationService { get; set; }
        [Inject]
        IUploadService IUploadService { get; set; }
        [Inject]
        ICandidateService ICandidateService { get; set; }
        [Parameter]
        public List<Candidate> Candidates { get; set; }
        [CascadingParameter] 
        BlazoredModalInstance ModalInstance { get; set; }
        protected override async Task OnInitializedAsync()
        {
            organizations = await IOrganizationService.GetAllOrganizationsAsync();
            candidateImages = await ICandidateService.GetAllCandidateImagesAsync();
        }
        private async Task CloseModal()
        {
            await Modal.CloseAsync();
        }
        private async Task HandleCreateCandidate()
        {
            IModalReference createConfirmModal = ResultModal.Show<ConfirmPopUp>("");
            ModalResult result = await createConfirmModal.Result;
            if (!result.Cancelled)
            {
                try
                {
                    if (candidate is null) return;
                    if (candidate.Id != 0)
                    {
                        await UpdateCandidate();
                        if (InformationCandidate.Count == 0)
                        {
                            InformationCandidate.Add(candidate, imagesCandidate);
                        }
                        else
                        {
                            var info = InformationCandidate.Where(t => t.Key == candidate).SingleOrDefault();
                            if (info.Key != null)
                            {
                                info.Value.Clear();
                                foreach (var item in imagesCandidate)
                                {
                                    info.Value.Add(item);
                                }
                            }
                        }
                        imagesCandidate.Clear();
                    }
                    if (!Candidates.Contains(candidate))
                    {
                        Candidates.Add(candidate);
                        List<string> list = imagesCandidate.ToList();
                        InformationCandidate.Add(candidate, list);
                        imagesCandidate.Clear();
                    }

                }
                catch (Exception ex)
                {
                    return;
                }
            }
            await ModalInstance.CloseAsync(ModalResult.Ok(""));
        } 
        private async Task UpdateCandidate()
        {
            await ICandidateService.UpdateCandidate(candidate);
            foreach (CandidateImage item in candidateImages)
            {
                if (imagesCandidate != null)
                {
                    if (candidate.Id == item.CandidateId)
                    {
                        IUploadService.RemoveImage(item.Url);
                        await ICandidateService.DeleteCandidateImage(item);
                    }
                }
            }
            foreach (string item in imagesCandidate)
            {
                CandidateImage activityImage = new CandidateImage();
                activityImage.CandidateId = Convert.ToInt32(candidate.Id);
                activityImage.Url = item;
                await ICandidateService.InsertCandidateImage(activityImage);
            }
        }
        public void HandleImagesCandidate(List<string> imagesCandidate)
        {
            this.imagesCandidate = imagesCandidate;
        }
    }
}
