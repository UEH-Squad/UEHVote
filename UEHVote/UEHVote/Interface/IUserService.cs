using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UEHVote.Model;

namespace UEHVote.Interface
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetUsers();
    }
}
