using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using UEHVote.Models;

namespace UEHVote.Data.Interfaces
{
    public interface IUserService
    {
        Task<List<User>> GetAllUser();
        Task<User> GetUserById(string userId);
        string GetOrganizationByUser(User user, List<Organization> organizations);
    }
}
