using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UEHVote.Models;

namespace UEHVote.Data.Interfaces
{
    public interface IActivityVoteService
    {
        /// <summary>
        /// IActivityVoteServices
        /// </summary>
        /// <returns></returns>
        Task<List<VotedCandidate>> GetAllVotesAsync();
        int GetQuantityVoted(Candidate candidate, List<VotedCandidate> listVotedCandidates);
    }
}