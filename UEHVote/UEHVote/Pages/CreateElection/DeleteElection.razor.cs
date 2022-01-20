using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AntDesign;
using Blazored.Modal;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UEHVote.Data.Interfaces;
using UEHVote.Models;
using Microsoft.Extensions.Configuration;
using Blazored.Modal.Services;

namespace UEHVote.Pages.CreateElection
{
    public partial class DeleteElection : ComponentBase
    {
        [CascadingParameter] 
        public BlazoredModalInstance Modal { get; set; }
        [CascadingParameter]
        public IModalService ResultModal { get; set; }
        private async Task CloseModalAsync()
        {
            await Modal.CloseAsync();
        }
        private async Task DeleteCandidatePopup()
        {
            await Modal.CloseAsync(ModalResult.Ok<bool>(true));
        }
    }
}
