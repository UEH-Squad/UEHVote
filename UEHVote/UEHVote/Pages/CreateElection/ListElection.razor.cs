using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text.Json;
using System.Threading.Tasks;
using Blazored.Modal.Services;
using Microsoft.AspNetCore.Components;
using UEHVote.Data.Interfaces;
using UEHVote.Models;

namespace UEHVote.Pages.CreateElection
{
    public partial class ListElection
    {
        private string bg;
        [Parameter] public bool IsOrg { get; set; } = true;
        [Parameter] public string CurrentId { get; set; }
        private List<Candidate> candidates = new List<Candidate>();
        List<CandidateImage> listCandidateImages = new List<CandidateImage>();
        private Candidate candidate { get; set; }
        private List<Organization> organizations { get; set; }
        private List<Candidate> result = new List<Candidate>();
        [Inject]
        private ICandidateService ICandidateService { get; set; }
        [Inject]
        private IOrganizationService IOrganizationService { get; set; }
        [CascadingParameter] public IModalService Modal { get; set; }
        void OnChange(string[] checkedValues)
        {
            Console.WriteLine($"checked = {JsonSerializer.Serialize(checkedValues)}");
        }
        private async Task ShowPopupDelete()
        {
            var options = new Blazored.Modal.ModalOptions()
            {
                HideCloseButton = true,
                DisableBackgroundCancel = true,
                UseCustomLayout = true,
            };
            Modal.Show<UEHVote.Pages.ListElection.PopupDelete>("", options);
            Delete();
        }
        protected async override Task OnInitializedAsync()
        {
            candidates = await ICandidateService.GetAllCandidatesAsync();
            organizations = await IOrganizationService.GetAllOrganizationsAsync();
            candidate = await ICandidateService.GetCandidateAsync(Convert.ToInt32(CurrentId));
            result = candidates.ToList();
        }
        protected async Task Delete()
        {
            await ICandidateService.DeleteCandidate(candidate);
            foreach (CandidateImage item in listCandidateImages)
            {
                if (CurrentId.Equals(Convert.ToString(item.CandidateId)))
                {
                    await ICandidateService.DeleteCandidateImage(item);
                }
            }
        }
        void FilterOrg(string key, object checkedValue)
        {
            List<Candidate> list = candidates.Where(t => t.Organization.Name == key).Select(t => t).ToList();
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
