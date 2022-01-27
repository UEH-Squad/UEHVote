using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using AntDesign;
using Blazored.Modal;
using Blazored.Modal.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Identity;
using UEHVote.Data.Interfaces;
using UEHVote.Models;

namespace UEHVote.Pages.CreateElection
{
    public partial class Index : ComponentBase
    {
        private bool IsShowForm = true;
        List<string> images { get; set; } = new List<string>();
        List<string> imagesCandidate { get; set; } = new List<string>();
        private List<Candidate> candidates = new();
        private List<ActivityImage> listActivityImages = new List<ActivityImage>();
        private Models.Election election = new Models.Election();
        private Dictionary<Candidate, List<string>> informationCandidate = new Dictionary<Candidate, List<string>>();
        [Parameter]
        public string currentId { get; set; }
        [CascadingParameter]
        public IModalService ResultModal { get; set; }
        [Inject]
        private NavigationManager NavigationManager { get; set; }
        [Inject]
        private ICandidateService ICandidateService { get; set; }
        [Inject]
        IElectionService IElectionService { get; set; }
        [Inject]
        IUploadService IUploadService { get; set; }
        [CascadingParameter]
        BlazoredModalInstance ModalInstance { get; set; }
        private void ShowForm()
        {
            IsShowForm = !IsShowForm;
        }
        public bool IsNumber(string pValue)
        {
            foreach (Char c in pValue)
            {
                if (!Char.IsDigit(c))
                    return false;
            }
            return true;
        }
        protected override async Task OnInitializedAsync()
        {
            if (currentId is not null)
            {
                if (!IsNumber(currentId)) return;
                election = await IElectionService.GetElectionAsync(Convert.ToInt32(currentId));
            }
            listActivityImages = await IElectionService.GetAllActivityImagesAsync();
        }
        private async Task CreateOrEditElection()
        {
            IModalReference createConfirmModal = ResultModal.Show<CreateConfirm>("");
            ModalResult result = await createConfirmModal.Result;
            if (!result.Cancelled)
            {
                try
                {
                    if (election.Id == null)
                    {
                        await CreateElection();
                    }
                    await UpdateElection();
                    await CreateCandidate();
                }
                catch (Exception ex)
                {
                    return;
                }
            }
        }
        void HandleInformationCandidate(Dictionary<Candidate, List<string>> informationCandidate)
        {
            this.informationCandidate = informationCandidate;
        }
        void HandleImagesElection(List<string> images)
        {
            this.images = images;
        }
        private void HandleCandidates(List<Candidate> candidates)
        {
            this.candidates=candidates;
        }
        protected async Task CreateElection()
        {
            await IElectionService.InsertElection(election);
            if (images.Count != 0)
            {
                foreach (string item in images)
                {
                    ActivityImage activityImage = new ActivityImage();
                    activityImage.ElectionId = election.Id;
                    activityImage.Url = item;
                    await IElectionService.InsertActivityImage(activityImage);
                }
            }
        }
        protected async Task UpdateElection()
        {
            await IElectionService.UpdateElection(election);
            foreach (ActivityImage item in listActivityImages)
            {
                if (images != null)
                {
                    if (election.Id == item.ElectionId)
                    {
                        IUploadService.RemoveImage(item.Url);
                        await IElectionService.DeleteActivityImage(item);
                    }
                }
            }
            foreach (string item in images)
            {
                ActivityImage activityImage = new ActivityImage();
                activityImage.ElectionId = Convert.ToInt32(election.Id);
                activityImage.Url = item;
                await IElectionService.InsertActivityImage(activityImage);
            }
        }
        protected async Task CreateCandidate()
        {
            if(candidates is null) return;
            foreach (var item in candidates)
            {
                var info = informationCandidate.Where(t => t.Key == item).FirstOrDefault();
                if (info.Key == null) continue;
                if (info.Key.ElectionId == 0 && election.Id != 0)
                {
                    info.Key.ElectionId = election.Id;
                    await ICandidateService.InsertCandidate(info.Key);
                }
                if(info.Value.Count!=0)
                {
                    foreach (string image in info.Value)
                    {
                        CandidateImage candidateImage = new CandidateImage();
                        candidateImage.CandidateId = item.Id;
                        candidateImage.Url = image;
                        await ICandidateService.InsertCandidateImage(candidateImage);
                    }
                }

            }
        }
        void Cancel()
        {
            NavigationManager.NavigateTo("/danh-sach-cac-cuoc-bau-cu");
        }
    }
}
