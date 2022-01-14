using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AntDesign;
using Blazored.Modal;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UEHVote.Data.Interfaces;
using UEHVote.Models;
using Microsoft.Extensions.Configuration;

namespace UEHVote.Pages.CreateElection
{
    public partial class DeleteElection : ComponentBase
    {
        [CascadingParameter] public BlazoredModalInstance Modal { get; set; }
        public List<CandidateImage> listCandidateImages = new List<CandidateImage>();
        [Parameter] public int candidateId { get; set; }
        private List<Candidate> candidates { get; set; }
        private Candidate candidate { get; set; }
        [Inject]
        private ICandidateService ICandidateService { get; set; }
        [Inject]
        private IUploadService IUploadService { get; set; }
        [Inject]
        NavigationManager NavigationManager { get; set; }
        private async Task CloseModalAsync()
        {
            await Modal.CloseAsync();
        }
        protected override async Task OnInitializedAsync()
        { 
            candidate = await ICandidateService.GetCandidateAsync(candidateId);
            listCandidateImages = await ICandidateService.GetAllCandidateImagesAsync();
        }
        protected async Task Delete()
        {
            if (candidate != null)
            {
                await ICandidateService.DeleteCandidate(candidate);
                foreach (CandidateImage item in listCandidateImages)
                {
                    if (candidateId.Equals(item.CandidateId))
                    {
                        await ICandidateService.DeleteCandidateImage(item);
                    }
                }
            }
            CloseModalAsync();
            NavigationManager.NavigateTo("/tao-va-chinh-sua-cuoc-bau-cu", true);
        }
    }
}
