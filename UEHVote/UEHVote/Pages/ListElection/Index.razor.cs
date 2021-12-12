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

namespace UEHVote.Pages.ListElection
{
    public partial class Index : ComponentBase
    {
        /// <summary>
        ///  HANDLE LIST INFORMATION ELECTION
        /// </summary>
        private string bg;
        private bool CheckHappening = true;
        private bool CheckNearEnd = true;
        private bool CheckEnded = true;
        private List<Models.Election> listElections { get; set; }
        private List<Organization> listOrganizations { get; set; }
        private List<Vote> listVotes { get; set; }
        private List<Candidate> listCandidates { get; set; }
        [Inject] private IElectionService IElectionService { get; set; }
        [Inject] private IActivityVoteService IActivityVoteService { get; set; }
        [Inject] private IOrganizationService IOrganizationService { get; set; }
        [Inject] private ICandidateService ICandidateService { get; set; }
        class FakeData
        {
            public int Id { get; set; }
            public int Quantity { get; set; }
            public string Name { get; set; }
            public string Status { get; set; }
            public string Org { get; set; }
        }
        private List<FakeData> listInfoElections { get; set; } = new List<FakeData>();
        private List<FakeData> result { get; set; }
        protected override async Task OnInitializedAsync()
        {
            listElections = await IElectionService.GetAllElectionsAsync();
            listOrganizations = await IOrganizationService.GetAllOrganizationsAsync();
            listVotes = await IActivityVoteService.GetAllVotesAsync();
            listCandidates = await ICandidateService.GetAllCandidatesAsync();
            if (listElections != null)
            {
                foreach (var election in listElections)
                {
                    if (election.IsForIndividuals == false)
                    {
                        listInfoElections.Add(new FakeData()
                        {
                            Id = election.Id,
                            Quantity = IActivityVoteService.GetQuantityVoted(election, listVotes),
                            Name = election.Name,
                            Status = IElectionService.StatusElection(election),
                            Org = IOrganizationService.GetOrganization(election, listOrganizations, listCandidates)
                        });
                    }
                }
            }
            result = listInfoElections.ToList();
        }
        void OnChange(string[] checkedValues)
        {
            Console.WriteLine($"checked = {JsonSerializer.Serialize(checkedValues)}");
        }
        void ClickHappening()
        {
            List<FakeData> fakeDatas = listInfoElections.Where(t => t.Status == "ĐANG DIỄN RA").Select(t => t).ToList();
            if (CheckHappening)
            {
                CheckHappening = false;
                foreach (var item in fakeDatas)
                {
                    result.Remove(item);
                }
            }
            else
            {
                CheckHappening = true;
                foreach (var item in fakeDatas)
                {
                    result.Add(item);
                }
            }
        }
        void ClickNearEnd()
        {
            List<FakeData> fakeDatas = listInfoElections.Where(t => t.Status == "GẦN KẾT THÚC").Select(t => t).ToList();
            if (CheckNearEnd)
            {
                CheckNearEnd = false;
                foreach (var item in fakeDatas)
                {
                    result.Remove(item);
                }
            }
            else
            {
                CheckNearEnd = true;
                foreach (var item in fakeDatas)
                {
                    result.Add(item);
                }
            }
        }
        void ClickEnded()
        {
            List<FakeData> fakeDatas = listInfoElections.Where(t => t.Status == "KẾT THÚC").Select(t => t).ToList();
            if (CheckEnded)
            {
                CheckEnded = false;
                foreach (var item in fakeDatas)
                {
                    result.Remove(item);
                }
            }
            else
            {
                CheckEnded = true;
                foreach (var item in fakeDatas)
                {
                    result.Add(item);
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

