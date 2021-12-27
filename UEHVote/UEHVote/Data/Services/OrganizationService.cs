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
        private readonly ApplicationDbContext _db;
        public OrganizationService(ApplicationDbContext db)
        {
            _db = db;
        }
        public Task<List<Organization>> GetAllOrganizationsAsync()
        {
            return _db.Organizations.ToListAsync();
        }
    }
}
