using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using System.Text.Json;
using AntDesign;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query.Internal;
using UEHVote.Models;
using UEHVote.Data.Interfaces;
using UEHVote.Pages.CreateElection;
using Blazored.Modal.Services;
using Blazored.Modal;

namespace UEHVote.Pages.ListElection
{
    public partial class Index : ComponentBase
    {
        /// <summary>
        ///  HANDLE LIST INFORMATION ELECTION
        /// </summary>
        private string bg;
        private string bgBrowse;
        public bool IsOrg = true;
        private List<string> status = new List<string>();
        private List<Models.Election> listElections { get; set; }
        private List<Organization> listOrganizations { get; set; }
        private List<User> users { get; set; }
        private List<Vote> listVotes { get; set; }
        private List<Candidate> candidates { get; set; }
        [Inject] private IElectionService IElectionService { get; set; }
        [Inject] private IUserService IUserService { get; set; }
        [Inject] private IActivityVoteService IActivityVoteService { get; set; }
        [Inject] private IOrganizationService IOrganizationService { get; set; }
        [Inject] private ICandidateService ICandidateService { get; set; }
        [CascadingParameter] public IModalService Modal { get; set; }

        class FakeData
        {
            public int Id { get; set; }
            public int Quantity { get; set; }
            public string Name { get; set; }
            public string Status { get; set; }
            public string Org { get; set; }
            public string StatusBrowse { get; set; }
        }
        private List<FakeData> listInfoElections { get; set; } = new List<FakeData>();
        private List<FakeData> result { get; set; }
        protected override async Task OnInitializedAsync()
        {
            listElections = await IElectionService.GetAllElectionsAsync();
            listOrganizations = await IOrganizationService.GetAllOrganizationsAsync();
            listVotes = await IActivityVoteService.GetAllVotesAsync();
            users = await IUserService.GetAllUsers();
            candidates = await ICandidateService.GetAllCandidatesAsync();
            if (listElections == null) return;
            foreach (var election in listElections)
            {
                if (election.IsForIndividuals) return;
                listInfoElections.Add(new FakeData()
                {
                    Id = election.Id,
                    Quantity = IActivityVoteService.GetQuantityVoted(election, listVotes),
                    Name = election.Name,
                    Status = IElectionService.StatusElection(election),
                    Org = IUserService.GetOrganizationByUser(await IUserService.GetUserById(election.UserId), listOrganizations),
                    StatusBrowse= "Chờ duyệt"
                });
            }
            result = listInfoElections.ToList();
            GetAllStatus();
        }
        void GetAllStatus()
        {
            status.Add("ĐANG DIỄN RA");
            status.Add("GẦN KẾT THÚC");
            status.Add("KẾT THÚC");
        }
        void OnChange(string[] checkedValues)
        {
            Console.WriteLine($"checked = {JsonSerializer.Serialize(checkedValues)}");
        }
        private async Task ShowPopupDelete(int Id)
        {
            var parameters = new ModalParameters();
            parameters.Add(nameof(PopupDelete.Id), Id);
            var options = new Blazored.Modal.ModalOptions()
            {
                HideCloseButton = true,
                DisableBackgroundCancel = true,
                UseCustomLayout = true,
            };

            Modal.Show<PopupDelete>("",parameters,options);
        }
        void FilterStatus(string status,object checkedValue)
        {
            List<FakeData> fakeDatas = listInfoElections.Where(t => t.Status == status).Select(t => t).ToList();
            if (Convert.ToBoolean(checkedValue))
            {
                foreach (var item in fakeDatas)
                {
                    if (!result.Contains(item))
                    {
                        result.Add(item);
                    }
                }
            }
            else
            {
                foreach (var item in fakeDatas)
                {
                    if (result.Contains(item))
                    {
                        result.Remove(item);
                    }
                }
            }
        }
        void FilterOrg(string key,object checkedValue)
        {
            List<FakeData> fakeDatas = listInfoElections.Where(t => t.Org == key).Select(t => t).ToList();
            if (Convert.ToBoolean(checkedValue))
            {
                foreach (var item in fakeDatas)
                {
                    if (!result.Contains(item))
                    {
                        result.Add(item);
                    }
                }
            }
            else
            {
                foreach (var item in fakeDatas)
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

