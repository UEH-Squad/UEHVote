using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UEHVote.Data.Interfaces;

namespace UEHVote.Pages.HomePage
{
    public partial class OwlCarousel : ComponentBase
    {
        [Inject]
        IJSRuntime JSRuntinme { get; set; }
        [Inject]
        IElectionService IElectionService { get; set; }
        [Inject]
        IActivityVoteService IActivityVoteService { get; set; }
        List<Models.Election> elections = new List<Models.Election>();
        List<Models.Vote> votes = new List<Models.Vote>();
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                await JSRuntinme.InvokeVoidAsync("uehvote.DetailVoteCarousel");
            }
        }
        protected override async Task OnInitializedAsync()
        {
            votes = await IActivityVoteService.GetAllVotesAsync();
            await SortHappingElections();
        }
        protected async Task<List<Models.Election>> SortHappingElections()
        {
            elections = (await IElectionService.GetAllElectionsAsync()).Where(t => t.FinishDate > DateTime.Today).ToList();
            for (int i = 0; i < elections.Count - 1; i++)
            {
                if (elections[i].StartDate < elections[i + 1].StartDate)
                {
                    Models.Election election = elections[i];
                    elections[i] = elections[i + 1];
                    elections[i + 1] = election;
                }
            }
            return elections;
        }
    }
}
