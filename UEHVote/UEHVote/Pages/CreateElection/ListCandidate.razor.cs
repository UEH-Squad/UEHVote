using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using AntDesign;
using Blazored.Modal;
using Blazored.Modal.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Internal;
using UEHVote.Data.Interfaces;
using UEHVote.Models;
using UEHVote.Pages.NominationEdit;

namespace UEHVote.Pages.CreateElection
{
    public partial class ListCandidate : ComponentBase
    {
        [Parameter] 
        public bool IsOrg { get; set; } = true;
        public List<CandidateImage> listCandidateImages = new List<CandidateImage>();
        [Parameter]
        public string currentId { get; set; }
        [Parameter]
        public List<Candidate> Candidates { get; set; }
        [Parameter]
        public List<string> imagesCandidate { get; set; }
        [Parameter]
        public EventCallback<List<Candidate>> HandleCandidates { get; set; }
        [Parameter]
        public EventCallback<List<string>> HandleImagesCandidate { get; set; }
        [Parameter]
        public Dictionary<Candidate,List<string>> InformationCandidate { get; set; }
        [Parameter]
        public EventCallback<Dictionary<Candidate,List<string>>> HandleInformationCandidate { get; set; }
        [Parameter]
        public List<Organization> organizations { get; set; }
        [Parameter]
        public List<Candidate> result { get; set; } = new List<Candidate>();
        [CascadingParameter] 
        public IModalService Modal { get; set; }
        [Inject]
        private IOrganizationService IOrganizationService { get; set; }
        [Inject]
        private ICandidateService ICandidateService { get; set; }
        void OnChange(string[] checkedValues)
        {
            Console.WriteLine($"checked = {JsonSerializer.Serialize(checkedValues)}");
        }
        public bool IsNumber(string pValue)
        {
            if (pValue is null) return false;
            foreach (Char c in pValue)
            {
                if (!Char.IsDigit(c))
                    return false;
            }
            return true;
        }
        protected override async Task OnInitializedAsync()
        {
            organizations = await IOrganizationService.GetAllOrganizationsAsync();
            if (!IsNumber(currentId)) return;
            Candidates = (await ICandidateService.GetAllCandidatesAsync()).Where(t=>t.ElectionId==Convert.ToInt32(currentId)).ToList();
            result = Candidates.ToList();
            listCandidateImages = await ICandidateService.GetAllCandidateImagesAsync();
        }
        private async Task Delete(Candidate candidate)
        {
            IModalReference deleteCandidateModal = Modal.Show<DeleteElection>("");
            ModalResult t = await deleteCandidateModal.Result;
            if (!t.Cancelled)
            {
                try
                {
                    if (candidate.Id!=0)
                    {
                        var list = listCandidateImages.Where(t => t.CandidateId == candidate.Id).ToList();
                        foreach (var item in list)
                        {
                            await ICandidateService.DeleteCandidateImage(item);
                        }
                        await ICandidateService.DeleteCandidate(candidate);
                    }
                    Candidates.Remove(candidate);
                    if (Candidates is null) result = null;
                    result = Candidates.ToList();
                    await InvokeAsync(StateHasChanged);
                }
                catch (Exception ex)
                {
                    return;
                }
            }
        }
        private async Task CreateCandidatePopup()
        {
            var parameters = new ModalParameters();
            parameters.Add(("Candidates"), Candidates);
            parameters.Add(("imagesCandidate"), imagesCandidate);
            parameters.Add("InformationCandidate", InformationCandidate);
            var options = new Blazored.Modal.ModalOptions()
            {
                HideCloseButton = true,
                DisableBackgroundCancel = true,
                UseCustomLayout = true,
            };
            await Modal.Show<UEHVote.Pages.NominationEdit.PopupNominationForm>("",parameters, options).Result;
            result = Candidates.ToList();
            await HandleCandidates.InvokeAsync(Candidates);
            await HandleImagesCandidate.InvokeAsync(imagesCandidate);
            await HandleInformationCandidate.InvokeAsync(InformationCandidate);
            await InvokeAsync(StateHasChanged);
        }
        private async Task EditCandidatePopup(Candidate candidate)
        {
            var parameters = new ModalParameters();
            parameters.Add(("candidate"), candidate);
            parameters.Add(("Candidates"), Candidates);
            parameters.Add(("imagesCandidate"), imagesCandidate);
            parameters.Add("InformationCandidate", InformationCandidate);
            var options = new Blazored.Modal.ModalOptions()
            {
                HideCloseButton = true,
                DisableBackgroundCancel = true,
                UseCustomLayout = true,
            };
            await Modal.Show<UEHVote.Pages.NominationEdit.PopupNominationForm>("", parameters, options).Result;
            result = Candidates.ToList();
            await HandleCandidates.InvokeAsync(Candidates);
            await HandleImagesCandidate.InvokeAsync(imagesCandidate);
            await HandleInformationCandidate.InvokeAsync(InformationCandidate);
            await InvokeAsync(StateHasChanged);
        }
        void FilterOrg(string key, object checkedValue)
        {
            List<Candidate> list = Candidates.Where(t => t.OrganizationId == Convert.ToInt32(key)).Select(t => t).ToList();
            if (Convert.ToBoolean(checkedValue))
            {
                foreach (var item in list)
                {
                    if (!result.Contains(item))
                    {
                        result.Add(item);
                    }
                }
            }
            else
            {
                foreach (var item in list)
                {
                    if (result.Contains(item))
                    {
                        result.Remove(item);
                    }
                }
            }
        }
    }
}
