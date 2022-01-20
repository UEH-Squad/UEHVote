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
        [CascadingParameter]
        public BlazoredModalInstance Modal { get; set; }
        [CascadingParameter]
        public IModalService ResultModal { get; set; }
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
            await Modal.CloseAsync(ModalResult.Ok<bool>(true));
            await ResultModal.Show<UEHVote.Pages.CreateElection.CreateSuccess>("", options).Result;
        }
    }
}
