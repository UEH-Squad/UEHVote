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
        Task<List<Vote>> GetAllVotesAsync();
        int GetQuantityVoted(Election election, List<Vote> listVotes);
        Task<List<VotedCandidate>> GetAllVotedCandidateAsync();
        int GetQuantityVotedCandidate(Candidate candidate, List<VotedCandidate> listVotedCandidates);
    }
}