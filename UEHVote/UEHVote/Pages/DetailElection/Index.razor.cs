﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using UEHVote.Models;
using UEHVote.Data.Interfaces;
using System.Globalization;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.JSInterop;
using UEHVote.Data.ViewModels;
using UEHVote.Data.Automapper;

namespace UEHVote.Pages.DetailElection
{
    /// <summary>
    ///  HANDLE DETAIL ELECTION
    /// </summary>
    public partial class Index: ComponentBase
    {
        Models.Election election = new Models.Election();
        DetailVoteViewModel detailVoteViewModel = new DetailVoteViewModel();
        [Parameter]
        public string CurrentId { get; set; }
        [Parameter]
        public string org { get; set; }
        private bool isAct { get; set; } 
        private List<Organization> listOrganizations { get; set; }
        private List<Vote> listVotes { get; set; }
        private List<VotedCandidate> votedCandidates { get; set; }
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
            isAct = true;
            detailVoteViewModel = await IElectionService.GetDetailVoteAsync(Convert.ToInt32(CurrentId));
            if (detailVoteViewModel is not null)
            {
                election = await IElectionService.GetElectionAsync(Convert.ToInt32(CurrentId));
                detailVoteViewModel.ActivityImages = (await IElectionService.GetAllActivityImagesAsync()).Where(t=>t.ElectionId==detailVoteViewModel.Id).ToList();
                listVotes = await IActivityVoteService.GetAllVotesAsync();
                listOrganizations = await IOrganizationService.GetAllOrganizationsAsync();
                detailVoteViewModel.Organization = IUserService.GetOrganizationByUser(await IUserService.GetUserById(election.UserId), listOrganizations);
                detailVoteViewModel.TotalVoted = IActivityVoteService.GetQuantityVoted(election, listVotes);
            }
            else
            {
                isAct = !isAct;
                Candidate candidate = await ICandidateService.GetCandidateAsync(Convert.ToInt32(CurrentId));
                votedCandidates = await IActivityVoteService.GetAllVotedCandidateAsync();
                detailVoteViewModel = await ICandidateService.GetDetailCandidateAsync(Convert.ToInt32(CurrentId));
                detailVoteViewModel.TotalVoted = IActivityVoteService.GetQuantityVotedCandidate(candidate, votedCandidates);
                detailVoteViewModel.CandidateImages = (await ICandidateService.GetAllCandidateImagesAsync()).Where(t=>t.CandidateId==detailVoteViewModel.Id).ToList();
            }
        }
    }
}
