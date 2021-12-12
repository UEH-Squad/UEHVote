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
    public class CandidateService:ICandidateService
    {
        /// <summary>
        /// Handle Candidate
        /// </summary>
        private readonly ApplicationDbContext _db;
        public CandidateService(ApplicationDbContext db)
        {
            _db = db;
        }
        public Task<List<Candidate>> GetAllCandidatesAsync()
        {
            return _db.Candidates.ToListAsync();
        }
    }
}
