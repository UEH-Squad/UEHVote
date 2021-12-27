using Blazored.Modal;
using Blazored.Modal.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UEHVote.Data.Interfaces;
using UEHVote.Data.Services;
using UEHVote.Models;

namespace UEHVote.Pages.NominationEdit
{
    public partial class Index
    {
        private Models.Candidate candidate = new Models.Candidate();
        [Parameter]
        public List<Organization> organizations { get; set; }
        [Parameter]
        public List<Candidate> candidates { get; set; }
        [Parameter]
        public List<Candidate> result { get; set; }
        [CascadingParameter] public IModalService Modal { get; set; }
        [CascadingParameter] public IModalService ResultModal { get; set; }
        
        [Inject]
        private IOrganizationService IOrganizationService { get; set; }
        [Inject]
        private ICandidateService ICandidateService { get; set; }
        private async Task ShowConfirmPopUp()
        {
            var parameters = new ModalParameters();
            parameters.Add(nameof(ConfirmPopUp.candidate), candidate);
            var options = new Blazored.Modal.ModalOptions()
            {
                HideCloseButton = true,
                DisableBackgroundCancel = true,
                UseCustomLayout = true,
            };

            Modal.Show<ConfirmPopUp>("",parameters, options);
        }
    }
}
