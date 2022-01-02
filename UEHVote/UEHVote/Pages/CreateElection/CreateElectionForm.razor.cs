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
        public Models.Election election { get; set; } = new Models.Election();
        [Parameter]
        public List<Organization> organizations { get; set; }
        [Parameter]
        public List<Candidate> candidates { get; set; }
        [Parameter]
        public string org { get; set; }
        [Inject]
        IElectionService IElectionService { get; set; }
        [Inject]
        NavigationManager NavigationManager { get; set; }
        [Inject]
        IUploadService IUploadService { get; set; }
        [Inject]
        IUserService IUserService { get; set; }
        [Inject] 
        IOrganizationService IOrganizationService { get; set; }
        List<string> image { get; set; } = new List<string>();
        private bool isChangeFile = false;
        private bool isChangeBanner = false;
        private IReadOnlyList<IBrowserFile> selectedImages;
        private IReadOnlyList<IBrowserFile> selectedBanner;
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
