using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using AntDesign;
using Blazored.Modal;
using Blazored.Modal.Services;
using Microsoft.AspNetCore.Components;
using UEHVote.Data.Interfaces;
using UEHVote.Models;

namespace UEHVote.Pages.CreateElection
{
    public partial class Index
    {
        private bool isLoading { get; set; }
        private bool IsShowForm = true;
        private Models.Election election = new Models.Election();
        [Parameter]
        public List<Organization> organizations { get; set; }
        [Parameter]
        public List<Candidate> candidates { get; set; }
        [Parameter]
        public List<Candidate> result { get; set; }
        [CascadingParameter]
        public IModalService ResultModal { get; set; }
        [Inject] 
        private IOrganizationService IOrganizationService { get; set; }
        [Inject]
        private ICandidateService ICandidateService { get; set; }
        private void ShowForm()
        {
            IsShowForm = !IsShowForm;
        }
        protected override async Task OnInitializedAsync()
        {
            organizations = await IOrganizationService.GetAllOrganizationsAsync();
            candidates = await ICandidateService.GetAllCandidatesAsync();
            result = candidates.ToList();
        }
        private async Task ShowResultModal()
        {
            var parameters = new ModalParameters();
            parameters.Add(nameof(CreateConfirm.election), election);
            var options = new Blazored.Modal.ModalOptions()
            {
                HideCloseButton = true,
                DisableBackgroundCancel = true,
                UseCustomLayout = true,
            };
            ResultModal.Show<CreateConfirm>("",parameters,options);
        }
    }
}
