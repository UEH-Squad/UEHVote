using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using AntDesign;
using Blazored.Modal;
using Blazored.Modal.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Internal;
using UEHVote.Data.Interfaces;
using UEHVote.Models;

namespace UEHVote.Pages.CreateElection
{
    public partial class ListElection
    {
        private string bg;
        private bool isChecking;
        [Parameter] 
        public bool IsOrg { get; set; } = true;
        [Parameter]
        public List<Candidate> candidates { get; set; }
        [Parameter]
        public List<Organization> organizations { get; set; }
        [Parameter]
        public List<Candidate> result { get; set; } = new List<Candidate>();
        [CascadingParameter] 
        public IModalService Modal { get; set; }
        [Inject]
        private IOrganizationService IOrganizationService { get; set; }
        void OnChange(string[] checkedValues)
        {
            Console.WriteLine($"checked = {JsonSerializer.Serialize(checkedValues)}");
        }
        private async Task ShowPopupDelete(int candidateId)
        {
            var parameters = new ModalParameters();
            parameters.Add(nameof(DeleteElection.candidateId), candidateId);
            var options = new Blazored.Modal.ModalOptions()
            {
                HideCloseButton = true,
                DisableBackgroundCancel = true,
                UseCustomLayout = true,
            };
            Modal.Show<UEHVote.Pages.CreateElection.DeleteElection>("",parameters,options);
        }
        void FilterOrg(string key, object checkedValue)
        {
            List<Candidate> list = candidates.Where(t => t.Organization.Name == key).Select(t => t).ToList();
            if (Convert.ToBoolean(checkedValue))
            {
                foreach (var item in list)
                {
                    if (!result.Contains(item))
                    {
                        result.Add(item);
                    }
                }
            }
            else
            {
                foreach (var item in list)
                {
                    if (result.Contains(item))
                    {
                        result.Remove(item);
                    }
                }
            }
        }
    }
}
