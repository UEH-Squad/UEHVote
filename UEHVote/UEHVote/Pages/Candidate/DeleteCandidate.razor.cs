using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UEHVote.Data.Interfaces;
using UEHVote.Models;

namespace UEHVote.Pages.Candidate
{
    /// <summary>
    /// DELETE CANDIDATE
    /// </summary>
    public partial class DeleteCandidate : ComponentBase
    {
        Models.Candidate candidate = new Models.Candidate();
        List<CandidateImage> listCandidateImages = new List<CandidateImage>();
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
            NavigationManager.NavigateTo("Candidate");
        }
        void Cancel()
        {
            NavigationManager.NavigateTo("Candidate");
        }
    }
}
