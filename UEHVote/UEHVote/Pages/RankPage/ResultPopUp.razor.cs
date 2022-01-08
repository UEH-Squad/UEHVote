using Blazored.Modal;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UEHVote.Pages.NominationEdit
{
    public partial class ResultPopUp : ComponentBase
    {
        [Parameter]
        public Models.Candidate candidate { get; set; }
        [CascadingParameter]
        public BlazoredModalInstance Modal { get; set; }
        private async Task CloseModal()
        {
            await Modal.CloseAsync();
        }
    }
}
