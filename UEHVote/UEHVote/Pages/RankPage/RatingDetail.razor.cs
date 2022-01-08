using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UEHVote.Data.Interfaces;

namespace UEHVote.Pages.RankPage
{
    public partial class RatingDetail : ComponentBase
    {
        [Parameter]
        public bool isOrganizer { get; set; }
        [Parameter]
        public bool isAdmin { get; set; }
        public bool isDisplayDetail = false;
        
        private void DisplayDetail()
        {
            isDisplayDetail = !isDisplayDetail;
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            await JS.InvokeVoidAsync("uehvote.DescriptionCarousel");
        }
       
    }
}
