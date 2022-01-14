using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UEHVote.Data.Context;
using UEHVote.Data.Interfaces;
using UEHVote.Data.ViewModels;
using UEHVote.Models;
using AutoMapper;

namespace UEHVote.Data.Services
{
    public class ElectionService:IElectionService
    {
        /// <summary>
        /// CRUD Election
        /// </summary>
        private readonly IDbContextFactory<ApplicationDbContext> _dbContextFactory;
        private readonly IMapper _mapper;
        public ElectionService(IDbContextFactory<ApplicationDbContext> dbContextFactory,IMapper mapper)
        {
            _mapper = mapper;
            _dbContextFactory = dbContextFactory;
        }
        /// <summary>
        ///  HANDLE ELECTION
        /// </summary>
        #region HANDLE ELECTION
        public Task<List<Election>> GetAllElectionsAsync()
        {
            var context = _dbContextFactory.CreateDbContext();
            return context.Elections.Include(t => t.User.Organization).ToListAsync();
        }
        public async Task<Election> GetElectionAsync(int Id)
        {
            var context = _dbContextFactory.CreateDbContext();
            Election election = await context.Elections.FirstOrDefaultAsync(c => c.Id.Equals(Id));
            return election;
        }
        public async Task<DetailVoteViewModel> GetDetailVoteAsync(int Id)
        {
            DetailVoteViewModel detailVoteViewModel = new DetailVoteViewModel();
            var context = _dbContextFactory.CreateDbContext();
            Election election = await context.Elections.FirstOrDefaultAsync(c => c.Id.Equals(Id));
            return _mapper.Map(election,detailVoteViewModel);
        }
        public async Task InsertElection(Election election)
        {
           var context = _dbContextFactory.CreateDbContext();
           await context.Elections.AddAsync(election);
           await  context.SaveChangesAsync();
        }
        public async Task UpdateElection(Election election)
        {
            var context = _dbContextFactory.CreateDbContext();
            context.Elections.Update(election);
            await context.SaveChangesAsync();
        }
        public async Task DeleteElection(Election election)
        {
            var context = _dbContextFactory.CreateDbContext();
            context.Elections.Remove(election);
            await context.SaveChangesAsync();
        }

        public string StatusElection(Election election)
        {
            string status= "KẾT THÚC";
            DateTime today=DateTime.Today;
            TimeSpan lastthreeday = election.FinishDate.Date- DateTime.Today.Date;
            if (election.StartDate <= today && today <= election.FinishDate)
            {
                if (lastthreeday.Days > 3)
                {
                    status = "ĐANG DIỄN RA";
                }
                else
                {
                    status = "GẦN KẾT THÚC";
                }
            }
            return status;
        }
        #endregion
        /// <summary>
        /// HANDLE ELECTION IMAGES
        /// </summary>
        /// <returns></returns>
        #region HANDLE ELECTION IMAGES
        public Task<List<ActivityImage>> GetAllActivityImagesAsync()
        {
            var context = _dbContextFactory.CreateDbContext();
            return context.ActivityImages.ToListAsync();
        }
        public async Task InsertActivityImage(ActivityImage activityImage)
        {
            var context = _dbContextFactory.CreateDbContext();
            await context.ActivityImages.AddAsync(activityImage);
            await context.SaveChangesAsync();
        }
        public async Task DeleteActivityImage(ActivityImage activityImage)
        {
            var context = _dbContextFactory.CreateDbContext();
            context.ActivityImages.Remove(activityImage);
            await context.SaveChangesAsync();
        }
        #endregion
    }
}
