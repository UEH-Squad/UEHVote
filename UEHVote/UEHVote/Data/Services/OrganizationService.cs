using System;
using System.Collections.Generic;
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
    public class OrganizationService:IOrganizationService
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
        public string GetOrganization(Election election, List<Organization> listOrganizations, List<Candidate> listCandidates)
        {
            string org = "";
            switch (election.IsForIndividuals)
            {
                case false:
                {
                    foreach (var candidate in listCandidates)
                    {
                        if (election.Id ==candidate.ElectionId)
                        {
                            foreach (var organization in listOrganizations)
                            {
                                if (organization.Id == candidate.OrganizationId)
                                {
                                    org = org + organization.Name;
                                    break;
                                }
                            }
                        }
                    }
                    break;
                }
                case true:
                {
                    break;
                }
            }
            return org;
        }
    }
}
