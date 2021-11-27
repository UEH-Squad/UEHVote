using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UEHVote.Data.Interfaces;
using UEHVote.Models;
namespace UEHVote.Pages.Election
{
    /// <summary>
    /// CODE UPDATE ELECTION
    /// </summary>
    public partial class UpdateElection:ComponentBase
    {
        /// <summary>
        /// DEFINITION
        /// </summary>
        bool disabledIsFor = false;
        bool disabledIsAllowed = false;
        private bool isChangeFile = false;
        private IReadOnlyList<IBrowserFile> selectedImages;

        [Parameter]
        public string CurrentId { get; set;}
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

        void ToggleDisable()
        {
            disabledIsFor = !disabledIsFor;
            disabledIsAllowed = !disabledIsAllowed;
        }

        protected async Task Update()
        {
            await IElectionService.UpdateElection(election);
            NavigationManager.NavigateTo("Election");
        }

        void Cancel()
        {
            NavigationManager.NavigateTo("Election");
        }

        private async Task OnUpDateFile(InputFileChangeEventArgs e)
        {
            var imageFiles = e.GetMultipleFiles();
            selectedImages = imageFiles;
            isChangeFile = true;
            foreach (var file in imageFiles)
            {
                if (file.ContentType != "image/png")
                {
                    this.StateHasChanged();
                }
                else
                {
                    string x = await IUploadService.SaveImageAsync(file, Convert.ToString(election.Id));
                    if (election.Banner != null)
                    {
                        IUploadService.RemoveImage(election.Banner);
                        election.Banner = "";
                        election.Banner = election.Banner + x; 
                    }
                    else
                    {
                        election.Banner = election.Banner + x;
                    }
                }
            }
        }
    }
}
