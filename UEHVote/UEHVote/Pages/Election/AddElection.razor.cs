using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Threading.Tasks;
using UEHVote.Data.Interfaces;
using UEHVote.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace UEHVote.Pages.Election
{
    public partial class AddElection:ComponentBase
    {
        bool isCheckedIsFor = true;
        bool disabledIsFor = false;
        bool isCheckedIsAllowed = true;
        bool disabledIsAllowed = false;
        private bool isChangeFile = false;

        private IReadOnlyList<IBrowserFile> selectedImages;
        [Inject]
        IElectionService IElectionService { get; set; }
        [Inject]
        NavigationManager NavigationManager { get; set; }
        [Inject]
        IUploadService IUploadService { get; set; }

        void ToggleDisable()
        {
            disabledIsFor = !disabledIsFor;
            disabledIsAllowed = !disabledIsAllowed;
        }
        protected async Task CreateElection()
        {
            await IElectionService.InsertElection(election);
            NavigationManager.NavigateTo("Election");

        }

        void Cancel()
        {
            NavigationManager.NavigateTo("Election");
        }


        private async Task OnInputFile(InputFileChangeEventArgs e)
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
                    if (election.Banner == null)
                    { election.Banner = election.Banner + x; }                   
                }
            }
        }
    }
}
