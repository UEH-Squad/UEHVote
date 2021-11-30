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
    /// <summary>
    /// CREATE ECLECTION 
    /// </summary>
    public partial class AddElection : ComponentBase
    {
        Models.Election election = new Models.Election();
        List<string> image { get; set; } = new List<string>();
        bool isCheckedIsFor = true;
        bool disabledIsFor = false;
        bool isCheckedIsAllowed = true;
        bool disabledIsAllowed = false;
        private bool isChangeFile = false;
        private bool isChangeBanner = false;
        private IReadOnlyList<IBrowserFile> selectedImages;
        private IReadOnlyList<IBrowserFile> selectedBanner;
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
            image.Clear();
            isChangeFile = true;
            foreach (var file in imageFiles)
            {
                if (file.ContentType != "image/jpeg")
                {
                    this.StateHasChanged();
                }
                else
                {
                    string x = await IUploadService.SaveImageAsync(file, Convert.ToString(election.Id));
                    image.Add(x);
                } 
            }
        }
        private async Task OnInputBanner(InputFileChangeEventArgs e)
        {
            var bannerFiles = e.GetMultipleFiles();
            selectedBanner = bannerFiles;
            isChangeBanner = true;
            foreach (var file in bannerFiles)
            {
                if (file.ContentType != "image/jpeg")
                {
                    this.StateHasChanged();
                }
                else
                {
                    string x = await IUploadService.SaveImageAsync(file, Convert.ToString(election.Id));
                    if (election.Banner == null)
                    {
                        election.Banner = election.Banner + x;
                    }
                }
            }
        }
    }
}

