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
using Blazored.Modal;

namespace UEHVote.Pages.RankPage
{
    /// <summary>
    /// CANDIDATELIST
    /// </summary>
    public partial class CandidateList : ComponentBase
    {
        private int maxVote = 3;
        private int voteCount = 0;
        private Fakedata topData;
        [CascadingParameter] 
        public IModalService Modal { get; set; }
        [Parameter]
        public bool isLogin { get; set; }
        [Parameter]
        public bool isOrganizer { get; set; }
        [Parameter]
        public bool isAdmin { get; set; }
        [Parameter]
        public string currentId { get; set; }
        private List<Fakedata> fakeDatas { get; set; } = new List<Fakedata>();
        private List<Models.Election> listElections { get; set; }
        private List<Organization> listOrganizations { get; set; }
        private List<VotedCandidate> listVotedCandidates { get; set; }
        private List<Models.Candidate> listCandidates { get; set; }
        [Inject] 
        IJSRuntime JSRuntinme { get; set; }
        [Inject]
        IElectionService IElectionService { get; set; }
        [Inject]
        IActivityVoteService IActivityVoteService { get; set; }
        [Inject] 
        IOrganizationService IOrganizationService { get; set; }
        [Inject] 
        ICandidateService ICandidateService { get; set; }
        [Inject] NavigationManager NavigationManager { get; set; }
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
            Modal.Show<UEHVote.Pages.RankPage.PopUp>("", options);
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
            await GetAllData();
            LoadingTopRank();
        }
        protected async Task GetAllData()
        {
            listElections = await IElectionService.GetAllElectionsAsync();
            listOrganizations = await IOrganizationService.GetAllOrganizationsAsync();
            listVotedCandidates = await IActivityVoteService.GetAllVotedCandidateAsync();
            listCandidates = ICandidateService.GetAllCandidatesById(Convert.ToInt32(currentId));
        }
        protected void LoadingTopRank()
        {
            if (listCandidates != null)
            {
                GetInfomationCandidate();
                GetRankCandidate();
                topData = fakeDatas.FirstOrDefault();
            }
        }
        void GetInfomationCandidate()
        {
            int i = 0;
            foreach (var candidate in listCandidates)
            {
                fakeDatas.Add(new Fakedata()
                {
                    Id = candidate.Id,
                    Name = candidate.Name,
                    Count = IActivityVoteService.GetQuantityVotedCandidate(candidate, listVotedCandidates),
                    Rank = i + 1
                });
                if (i < listCandidates.Count)
                {
                    i++;
                }
            }
        }
        void GetRankCandidate()
        {
            for(int i=0;i<fakeDatas.Count;i++)
            {
                for(int j=i+1;j<fakeDatas.Count;j++)
                {
                    if(fakeDatas[i].Count<fakeDatas[j].Count)
                    {
                        int rank = fakeDatas[i].Rank;
                        fakeDatas[i].Rank = fakeDatas[j].Rank;
                        fakeDatas[j].Rank = rank;
                        Fakedata kt = fakeDatas[i];
                        fakeDatas[i] = fakeDatas[j];
                        fakeDatas[j] = kt;
                    }
                }    
            }    
        }
        void Cancel()
        {
            NavigationManager.NavigateTo("");
        }
    }
}
