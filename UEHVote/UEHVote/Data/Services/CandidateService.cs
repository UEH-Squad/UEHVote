using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UEHVote.Data.Interfaces;
using UEHVote.Models;

namespace UEHVote.Data.Services
{
    public class CandidateService : ICandidateService
    {
        private readonly ApplicationDbContext _db;
        public CandidateService(ApplicationDbContext db)
        {
            _db = db;
        }
        /// <summary>
        ///  HANDLE CANDIDATE
        /// </summary>
        public Task<List<Candidate>> GetAllCandidatesAsync()
        {
            return _db.Candidates.ToListAsync();
        }
        public async Task<Candidate> GetCandidateAsync(int Id)
        {
            Candidate candidate = await _db.Candidates.FirstOrDefaultAsync(c => c.Id.Equals(Id));
            return candidate;
        }
        public async Task InsertCandidate(Candidate candidate)
        {
            await _db.Candidates.AddAsync(candidate);
            await _db.SaveChangesAsync();
        }
        public async Task UpdateCandidate(Candidate candidate)
        {
            _db.Candidates.Update(candidate);
            await _db.SaveChangesAsync();
        }
        public async Task DeleteCandidate(Candidate candidate)
        {
            _db.Candidates.Remove(candidate);
            await _db.SaveChangesAsync();
        }
        /// <summary>
        /// HANDLE Candidate Image
        /// </summary>
        /// <returns></returns>
        public Task<List<CandidateImage>> GetAllCandidateImagesAsync()
        {
            return _db.CandidateImages.ToListAsync();
        }

        public async Task InsertCandidateImage(CandidateImage candidateImage)
        {
            await _db.CandidateImages.AddAsync(candidateImage);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteCandidateImage(CandidateImage candidateImage)
        {
            _db.CandidateImages.Remove(candidateImage);
            await _db.SaveChangesAsync();
        }
    }
}