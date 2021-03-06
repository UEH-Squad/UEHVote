using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UEHVote.Data.Interfaces;

namespace UEHVote.Pages.HomePage
{
    public partial class Banner:ComponentBase
    {
        [Inject]
        IJSRuntime JSRuntinme { get; set; }
        [Inject]
        IElectionService IElectionService { get; set; }
        List<Models.Election> elections = new List<Models.Election>();
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                await JSRuntinme.InvokeVoidAsync("uehvote.ShowMess");
            }
        }
        protected override async Task OnInitializedAsync()
        {
            await SortTimeElections();
        }
        protected async Task<List<Models.Election>> SortTimeElections()
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
