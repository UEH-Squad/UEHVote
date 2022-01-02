using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blazored.Modal;
using Blazored.Modal.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using UEHVote.Data.Interfaces;
using UEHVote.Models;

namespace UEHVote.Pages.CreateElection
{
    public partial class CreateConfirm : ComponentBase
    {
        [Parameter] 
        public Models.Election election { get; set; }
        [CascadingParameter]
        public BlazoredModalInstance Modal { get; set; }
        [CascadingParameter]
        public IModalService ResultModal { get; set; }
        [Inject]
        IElectionService IElectionService { get; set; }
        [Inject]
        ICandidateService ICandidateService { get; set; }
        [Inject]
        NavigationManager NavigationManager { get; set; }
        List<string> image { get; set; } = new List<string>();
        private async Task CloseModal()
        {
            await Modal.CloseAsync();
        }
        private async Task ShowResultModal()
        {
            var options = new Blazored.Modal.ModalOptions()
            {
                HideCloseButton = true,
                DisableBackgroundCancel = true,
                UseCustomLayout = true,
            }; 
            await Modal.CloseAsync();
            await ResultModal.Show<CreateSuccess>("", options).Result;
        }
        protected async Task CreateElection()
        {
            await IElectionService.InsertElection(election);
            if (image.Count != 0)
            {
                foreach (string item in image)
                {
                    ActivityImage activityImage = new ActivityImage();
                    activityImage.ElectionId = election.Id;
                    activityImage.Url = item;
                    await IElectionService.InsertActivityImage(activityImage);
                }
            }
            ShowResultModal();
        }
    }
}
