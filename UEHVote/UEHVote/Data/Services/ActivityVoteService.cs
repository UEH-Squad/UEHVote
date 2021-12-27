﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UEHVote.Data.Interfaces;
using UEHVote.Models;

namespace UEHVote.Data.Services
{
    public class ActivityVoteService : IActivityVoteService
    {
        /// <summary>
        /// Handle ActivityVote
        /// </summary>
        /// <returns></returns>
        private readonly ApplicationDbContext _db;
        public ActivityVoteService(ApplicationDbContext db)
        {
            _db = db;
        }
        public Task<List<Vote>> GetAllVotesAsync()
        {
            return _db.Votes.ToListAsync();
        }
        public int GetQuantityVoted(Election election, List<Vote> listVotes)
        {
            int total = 0;
            foreach (var vote in listVotes)
            {
                if (election.Id == vote.ElectionId)
                {
                    total++;
                }
            }
            return total;
        }
    }
}