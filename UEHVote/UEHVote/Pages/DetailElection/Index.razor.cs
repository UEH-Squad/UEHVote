using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using UEHVote.Models;
using UEHVote.Data.Interfaces;
using System.Globalization;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.JSInterop;

namespace UEHVote.Pages.DetailElection
{
    /// <summary>
    ///  HANDLE DETAIL ELECTION
    /// </summary>
    public partial class Index: ComponentBase
    {
        Models.Election election = new Models.Election();
        [Parameter]
        public string CurrentId { get; set; }
        [Parameter]
        public string org { get; set; }
        private bool IsAct = true;
        private List<ActivityImage> listActivityImages { get; set; }
        private List<Candidate> candidates { get; set; }
        private List<Organization> listOrganizations { get; set; }
        private List<Vote> listVotes { get; set; }
        private string organization { get; set; }
        private int totalVote { get; set; }
        [Inject] 
        private IJSRuntime JSRuntinme { get; set; }
        [Inject] 
        private IElectionService IElectionService { get; set; }
        [Inject]
        private IActivityVoteService IActivityVoteService { get; set; }
        [Inject]
        private ICandidateService ICandidateService { get; set; }
        [Inject]
        private IOrganizationService IOrganizationService { get; set; }
        [Inject]
        private IUserService IUserService { get; set; }
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                await JSRuntinme.InvokeVoidAsync("uehvote.DetailVoteCarousel");
            }
        }
        protected override async Task OnInitializedAsync()
        {
            election = await IElectionService.GetElectionAsync(Convert.ToInt32(CurrentId));
            listActivityImages = await IElectionService.GetAllActivityImagesAsync();
            candidates = await ICandidateService.GetAllCandidatesAsync();
            listVotes = await IActivityVoteService.GetAllVotesAsync();
            listOrganizations = await IOrganizationService.GetAllOrganizationsAsync();
            organization =IUserService.GetOrganizationByUser(await IUserService.GetUserById(election.UserId),listOrganizations);
            totalVote = IActivityVoteService.GetQuantityVoted(election, listVotes);
        }
    }
}
