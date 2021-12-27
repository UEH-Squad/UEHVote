using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;
using UEHVote.Models;

namespace UEHVote.Data.Interfaces
{
    public interface IUserService
    {
        Task<List<User>> GetAllUsersAsync();
    }
}