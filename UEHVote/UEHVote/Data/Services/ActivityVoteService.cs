using System.Collections.Generic;
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
        public Task<List<VotedCandidate>> GetAllVotedCandidateAsync()
        {
            return _db.VotedCandidates.ToListAsync();
        }
        public int GetQuantityVotedCandidate(Candidate candidate, List<VotedCandidate> listVotedCandidates)
        {
            int total = 0;
            foreach (var vote in listVotedCandidates)
            {
                if (candidate.Id == vote.CandidateId)
                {
                    total++;
                }
            }
            return total;
        }
    }
}
