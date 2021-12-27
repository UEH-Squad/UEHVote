using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UEHVote.Pages.RankPage
{
    public partial class RatingDetail : ComponentBase
    {
        public bool isOrganizer = false;
        public bool isAdmin = true;
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
