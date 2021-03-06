using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UEHVote.Models;

namespace UEHVote.Data.Interfaces
{
    public interface IOrganizationService
    {
        Task<List<Organization>> GetAllOrganizationsAsync();
    }
}