using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;
using Abp.Domain.Repositories;
using Abp.Specifications;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Migrations;
using UEHVote.Data.Context;
using UEHVote.Data.Interfaces;
using UEHVote.Models;

namespace UEHVote.Data.Services
{
    public class UserService: IUserService
    {
        /// <summary>
        /// Handle User
        /// </summary>
        private readonly ApplicationDbContext _db;
        private readonly UserManager<User> _userManager;
        public UserService(ApplicationDbContext db, UserManager<User> userManager)
        {
            _db = db;
            _userManager = userManager;
        }
        public async Task<List<User>> GetAllUser()
        {
            return _userManager.Users.ToList();
        }
        public async Task<User> GetUserById(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            return user;
        }
        public string GetOrganizationByUser(User user,List<Organization> organizations)
        {
            string organization = "";
            foreach (var item in organizations)
            {
                if (user is not null && item.Id == user.OrganizationId)
                {
                    organization = item.Name;
                }
            }
            return organization;
        }
    }
}