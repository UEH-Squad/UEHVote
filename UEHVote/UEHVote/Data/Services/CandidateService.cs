using Abp.Specifications;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UEHVote.Data.Context;
using UEHVote.Data.Interfaces;
using UEHVote.Models;
using UEHVote.Data.ViewModels;
using AutoMapper;

namespace UEHVote.Data.Services
{
    public class CandidateService : ICandidateService
    {
        /// <summary>
        ///  HANDLE CANDIDATE
        /// </summary>
        private readonly IDbContextFactory<ApplicationDbContext> _dbContextFactory;
        private readonly IMapper _mapper;
        public CandidateService(IDbContextFactory<ApplicationDbContext> dbContextFactory, IMapper mapper)
        {
            _dbContextFactory = dbContextFactory;
            _mapper = mapper;
        }
        /// <summary>
        ///  HANDLE CANDIDATE
        /// </summary>
        public Task<List<Candidate>> GetAllCandidatesAsync()
        {
            var context = _dbContextFactory.CreateDbContext();
            return context.Candidates.Include(t => t.Organization).ToListAsync();
        }
        public List<Candidate> GetAllCandidatesById(int id)
        {
            var context = _dbContextFactory.CreateDbContext();
            return context.Candidates.Where(t => t.ElectionId == id).ToList();
        }
        public async Task<Candidate> GetCandidateAsync(int Id)
        {
            var context = _dbContextFactory.CreateDbContext();
            Candidate candidate = await context.Candidates.FirstOrDefaultAsync(c => c.Id==Id);
            return candidate;
        }
        public async Task<DetailVoteViewModel> GetDetailCandidateAsync(int Id)
        {
            DetailVoteViewModel detailVoteViewModel = new DetailVoteViewModel();
            var context = _dbContextFactory.CreateDbContext();
            Candidate candidate = await context.Candidates.FirstOrDefaultAsync(c => c.Id.Equals(Id));
            return _mapper.Map(candidate, detailVoteViewModel);
        }
        public async Task InsertCandidate(Candidate candidate)
        {
            var context = _dbContextFactory.CreateDbContext();
            await context.Candidates.AddAsync(candidate);
            await context.SaveChangesAsync();
        }
        public async Task UpdateCandidate(Candidate candidate)
        {
            var context = _dbContextFactory.CreateDbContext();
            context.Candidates.Update(candidate);
            await context.SaveChangesAsync();
        }
        public async Task DeleteCandidate(Candidate candidate)
        {
            var context = _dbContextFactory.CreateDbContext();
            context.Candidates.Remove(candidate);
            await context.SaveChangesAsync();
        }
        /// <summary>
        /// HANDLE Candidate Image
        /// </summary>
        /// <returns></returns>
        public Task<List<CandidateImage>> GetAllCandidateImagesAsync()
        {
            var context = _dbContextFactory.CreateDbContext();
            return context.CandidateImages.ToListAsync();
        }
        public string GetCandidateImageById(int id)
        {
            var context = _dbContextFactory.CreateDbContext();
            var url = "./img/meomeo.png";
            var list = context.CandidateImages.Where(t => t.CandidateId == id).Select(t => t.Url).ToList();
            if (list.Count != 0)
                url = list[0];
            return url;
        }
        public async Task InsertCandidateImage(CandidateImage candidateImage)
        {
            var context = _dbContextFactory.CreateDbContext();
            await context.CandidateImages.AddAsync(candidateImage);
            await context.SaveChangesAsync();
        }

        public async Task DeleteCandidateImage(CandidateImage candidateImage)
        {
            var context = _dbContextFactory.CreateDbContext();
            context.CandidateImages.Remove(candidateImage);
            await context.SaveChangesAsync();
        }
    }
}