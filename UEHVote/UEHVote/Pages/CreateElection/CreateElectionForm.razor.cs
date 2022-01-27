using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using UEHVote.Data.Interfaces;
using UEHVote.Models;

namespace UEHVote.Pages.CreateElection
{
    public partial class CreateElectionForm : ComponentBase
    {
        [Parameter]
        public string currentId { get; set; }
        [Parameter] 
        public Models.Election election { get; set; } = new Models.Election();
        private List<Organization> organizations = new List<Organization>();
        [Parameter]
        public EventCallback<List<string>> HandleImagesElection { get; set; }
        [Parameter]
        public string org { get; set; }
        [Inject]
        IUploadService IUploadService { get; set; }
        [Inject] 
        IOrganizationService IOrganizationService { get; set; }
        [Parameter]
        public List<string> images { get; set; } 
        private IReadOnlyList<IBrowserFile> selectedImages;
        private IReadOnlyList<IBrowserFile> selectedBanner;
        private IBrowserFile uploadFile;
        protected override async Task OnInitializedAsync()
        {
            organizations = await IOrganizationService.GetAllOrganizationsAsync();
        }
      
        private async Task HandleImageDiscarded()
        {
            uploadFile = null;
        }
        void HandleImages(List<string> images)
        {
            this.images = images;
        }
        private async Task OnInputBanner(InputFileChangeEventArgs e)
        {
            var bannerFiles = e.GetMultipleFiles();
            selectedBanner = bannerFiles;
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
        private async Task OnUpdateBanner(InputFileChangeEventArgs e)
        {
            var bannerFiles = e.GetMultipleFiles();
            selectedBanner = bannerFiles;
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
