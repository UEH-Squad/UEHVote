using Blazored.Modal;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UEHVote.Data.Interfaces;
using UEHVote.Models;

namespace UEHVote.Pages.ListElection
{
    public partial class PopupDelete:ComponentBase
    {
        private Models.Election election = new Models.Election();
        private List<ActivityImage> images = new List<ActivityImage>();
        [CascadingParameter]
        public BlazoredModalInstance Modal { get; set; }
        [Parameter] public int Id { get; set; }
        [Inject]
        IElectionService IElectionService { get; set; }
        [Inject]
        IUploadService IUploadService { get; set; }
        [Inject]
        NavigationManager NavigationManager { get; set; }
        private async Task CloseModalAsync()
        {
            await Modal.CloseAsync();
        }
        protected override async Task OnInitializedAsync()
        {
            election = await IElectionService.GetElectionAsync(Id);
            images = await IElectionService.GetAllActivityImagesAsync();
        }
        protected async Task Delete()
        {
            if(election is not null)
            {
                if (election.Banner != null)
                {
                    IUploadService.RemoveImage(election.Banner);
                }
                await IElectionService.DeleteElection(election);
                foreach (ActivityImage item in images)
                {
                    if (Id.Equals(Convert.ToString(item.ElectionId)))
                    {
                        IUploadService.RemoveImage(item.Url);
                        IElectionService.DeleteActivityImage(item);
                    }
                }
            }
            CloseModalAsync();
            NavigationManager.NavigateTo("/danh-sach-cac-cuoc-bau-cu",true);
        }
    }
}
