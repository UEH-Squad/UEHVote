using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using UEHVote.Data;
using UEHVote.Interface;
using UEHVote.Model;


namespace UEHVote.Service
{
    public class UserService : IUserService
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IConfiguration _config;
        private readonly ApplicationDbContext _context;

        public UserService(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public string IsManagerOrLeader(User user)
        {
            var data = from ur in _context.UserRoles
                       join us in _context.Users on ur.UserId equals us.Id
                       join rl in _context.Roles on ur.RoleId equals rl.Id
                       select new { ur, us, rl };
            var rolesquery = data.Where(data => data.us.Id == user.Id).Select(dt => dt.rl.Name).ToArray();
            string roles = string.Join(",", rolesquery);
            string result = "";
            if (roles.Contains("ITManager") || roles.Contains("HrManager") || roles.Contains("HrManager"))
            {
                result = "Admin";
                return result;
            }
            else if (roles.Contains("ManagerGeneral"))
            {
                return result = "Org";
            }
            else return result = "User";
        }

        private bool IsInRole(User user1, object user2)
        {
            throw new NotImplementedException();
        }

        private User FindUserById(string userId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<User>> GetUsers()
        {
            throw new NotImplementedException();
        }
    }
}
