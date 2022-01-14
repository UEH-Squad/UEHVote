﻿using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UEHVote.Data.Interfaces;
using UEHVote.Models;

namespace UEHVote.Pages.RankPage
{
    public partial class Index:ComponentBase
    {
        [Inject]
        public UserManager<User> UserManager { get; set; }
        [Parameter]
        public string CurrentId { get; set; }
        private List<ActivityImage> images = new List<ActivityImage>();
        private bool isLoading;
        bool isLogin { get; set; }
        bool isOrganizer { get; set; }
        bool isAdmin { get; set; }
        [Parameter]
        public Models.Election election { get; set; }
        [Inject]
        IElectionService IElectionService { get; set; }
       /* [Inject]
        public HttpContextAccessor HttpContextAccessor { get; set; }*/
        protected override async Task OnInitializedAsync()
        {
            /*var currentUser = HttpContextAccessor.HttpContext.User;
            if(currentUser is not null)
            {
                isLogin = true;
                isOrganizer = currentUser.IsInRole("");
            }*/
            election = await IElectionService.GetElectionAsync(Convert.ToInt32(CurrentId));
            images=await IElectionService.GetAllActivityImagesAsync();
        }
      
    }
}