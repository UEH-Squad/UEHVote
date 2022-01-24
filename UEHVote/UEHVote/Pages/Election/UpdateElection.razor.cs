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
        Models.Election election = new Models.Election();
        private List<ActivityImage> listActivityImages { get; set; }
        List<string> image { get; set; } = new List<string>();
        bool disabledIsFor = false;
        bool disabledIsAllowed = false;
        private bool isChangeFile = false;
        private bool isChangeBanner = false;
        private IReadOnlyList<IBrowserFile> selectedImages;
        private IReadOnlyList<IBrowserFile> selectedBanner; 
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
            listActivityImages = await IElectionService.GetAllActivityImagesAsync();
        }
        void ToggleDisable()
        {
            disabledIsFor = !disabledIsFor;
            disabledIsAllowed = !disabledIsAllowed;
        }
        protected async Task Update()
        {
            await IElectionService.UpdateElection(election);
            foreach (ActivityImage item in listActivityImages)
            {
                if (image != null)
                {
                    if (CurrentId == Convert.ToString(item.ElectionId))
                    {
                        IUploadService.RemoveImage(item.Url);
                        await IElectionService.DeleteActivityImage(item);
                    }
                }
            }
            foreach (string item in image)
            {
                ActivityImage activityImage = new ActivityImage();
                activityImage.ElectionId = Convert.ToInt32(CurrentId);
                activityImage.Url = item;
                await IElectionService.InsertActivityImage(activityImage);
            }
            NavigationManager.NavigateTo("them-");
        }
        void Cancel()
        {
            NavigationManager.NavigateTo("Election");
        }
        private async Task OnUpdateFile(InputFileChangeEventArgs e)
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
        private async Task OnUpdateBanner(InputFileChangeEventArgs e)
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
                    { election.Banner = election.Banner + x; }
                    else
                    {
                        election.Banner = "";
                        election.Banner = election.Banner + x; 
                    }    
                }
            }
        }
    }
}
