using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UEHVote.Models;
using UEHVote.Data.Interfaces;
using System.Globalization;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.JSInterop;
using Blazored.Modal.Services;

namespace UEHVote.Pages.RankPage
{
    /// <summary>
    /// CANDIDATELIST
    /// </summary>
    public partial class CandidateList : ComponentBase
    {
        [CascadingParameter] 
        public IModalService Modal { get; set; }
        [Parameter] public bool IsLogin { get; set; }
        [Parameter] public bool IsOrganizer { get; set; }
        [Parameter] public bool IsAdmin { get; set; }
        private int maxVote = 3;
        private int voteCount = 0;
        private Fakedata topData;
        private List<Fakedata> fakeDatas { get; set; } = new List<Fakedata>();
        private List<Models.Election> listElections { get; set; }
        private List<Organization> listOrganizations { get; set; }
        private List<Vote> listVotes { get; set; }
        private List<Models.Candidate> listCandidates { get; set; }
        [Inject] private IJSRuntime JSRuntinme { get; set; }
        [Inject] private IElectionService IElectionService { get; set; }
        [Inject] private IActivityVoteService IActivityVoteService { get; set; }
        [Inject] private IOrganizationService IOrganizationService { get; set; }
        [Inject] private ICandidateService ICandidateService { get; set; }

        private class Fakedata
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public int Rank { get; set; }
            public int Count { get; set; }
            public bool isRated { get; set; } = false;
        }
        private async Task ShowLoginRequire()
        {
            var options = new Blazored.Modal.ModalOptions()
            {
                HideCloseButton = true,
                DisableBackgroundCancel = true,
                UseCustomLayout = true,
            };

            Modal.Show<PopUp>("", options);
        }
        private async Task ShowVoteSuccess()
        {
            var options = new Blazored.Modal.ModalOptions()
            {
                HideCloseButton = true,
                DisableBackgroundCancel = true,
                UseCustomLayout = true,
            };

            Modal.Show<VoteSuccess>("", options);
        }

        private void Rating(int id)
        {
            var item = fakeDatas.Find(x => x.Id == id);

            if (item.isRated)
            {
                item.isRated = false;
                item.Count--;
                voteCount--;
            }
            else
            {
                if (voteCount < maxVote)
                {
                    item.isRated = true;
                    item.Count++;
                    voteCount++;
                }
            }
        }

        protected override async Task OnInitializedAsync()
        {
            listElections = await IElectionService.GetAllElectionsAsync();
            listOrganizations = await IOrganizationService.GetAllOrganizationsAsync();
            listVotes = await IActivityVoteService.GetAllVotesAsync();
            listCandidates = await ICandidateService.GetAllCandidatesAsync();
            if (listCandidates != null)
            {
                foreach (var candidate in listCandidates)
                {
                        fakeDatas.Add(new Fakedata()
                        {
                            Id = candidate.Id,
                            Name = candidate.Name,
                            Count = IActivityVoteService.GetQuantityVoted(candidate,listVotes),
                            Rank = ((short)voteCount)
                        });
                    
                    topData = fakeDatas.First();
                }
            }
        }

    }
}
