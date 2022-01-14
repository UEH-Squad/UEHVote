using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UEHVote.Data.Context;
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
        private readonly IDbContextFactory<ApplicationDbContext> _dbContextFactory;
        public ActivityVoteService(IDbContextFactory<ApplicationDbContext> dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }
        public Task<List<VotedCandidate>> GetAllVotedCandidateAsync()
        {
            var context = _dbContextFactory.CreateDbContext();
            return context.VotedCandidates.ToListAsync();

        }
        public Task<List<Vote>> GetAllVotesAsync()
        {
            var context = _dbContextFactory.CreateDbContext();
            return context.Votes.ToListAsync();
        }
        public int GetQuantityVotedCandidate(Candidate candidate, List<VotedCandidate> listVotedCandidates)
        {
            int total = 0;
            foreach (var vote in listVotedCandidates)
            {
                if (candidate.Id == vote.CandidateId)
                    total++;
            }
            return total;
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
