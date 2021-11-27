using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UEHVote.Data.Interfaces;
using UEHVote.Models;

namespace UEHVote.Pages.Election
{
    public partial class DeleteElection:ComponentBase
    {
        [Parameter]
        public string CurrentId { get; set; }
        [Inject]
        IElectionService IElectionService { get; set; }
        [Inject]
        NavigationManager NavigationManager { get; set; }
        [Inject]
        IUploadService IUploadService { get; set; }

        protected override async Task OnInitializedAsync()
        {
            election = await IElectionService.GetElectionAsync(Convert.ToInt32(CurrentId));
        }


        protected async Task Delete()
        {
            IUploadService.RemoveImage(election.Banner);
            await IElectionService.DeleteElection(election);
            NavigationManager.NavigateTo("Election");
        }
        void Cancel()
        {
            NavigationManager.NavigateTo("Election");
        }
    }
}
