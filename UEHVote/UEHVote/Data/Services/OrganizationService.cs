using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Threading.Tasks;
using AntDesign;
using Microsoft.AspNetCore.HostFiltering;
using Microsoft.EntityFrameworkCore;
using UEHVote.Data.Context;
using UEHVote.Data.Interfaces;
using UEHVote.Models;

namespace UEHVote.Data.Services
{
    public class OrganizationService : IOrganizationService
    {
        /// <summary>
        /// Handle Organization
        /// </summary>
        private readonly IDbContextFactory<ApplicationDbContext> _dbContextFactory;
        public OrganizationService(IDbContextFactory<ApplicationDbContext> dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }
        public Task<List<Organization>> GetAllOrganizationsAsync()
        {
            var context = _dbContextFactory.CreateDbContext();
            return context.Organizations.ToListAsync();
        }
    }
}
