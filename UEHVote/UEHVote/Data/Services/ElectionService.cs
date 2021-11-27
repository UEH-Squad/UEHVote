using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UEHVote.Data.Interfaces;
using UEHVote.Models;

namespace UEHVote.Data
{
    public class ElectionService:IElectionService
    {
        /// <summary>
        /// CRUD Election
        /// </summary>
        private readonly ApplicationDbContext _db;
        public ElectionService(ApplicationDbContext db)
        {
            _db = db;
        }

        /// <summary>
        /// GET ELECTION
        /// </summary>

        public Task<List<Election>> GetAllElectionsAsync()
        {
            return  _db.Elections.ToListAsync();
        }

        /// <summary>
        /// INSERT ELECTION
        /// </summary>
        #region Insert Election
        public async Task InsertElection(Election election)
        {
           await _db.Elections.AddAsync(election);
           await  _db.SaveChangesAsync();
        }

        #endregion

        /// <summary>
        /// GET ELECTION BY ID
        /// </summary>
        #region Get Election by Id
        public async Task<Election> GetElectionAsync(int Id)
        {
            Election election = await _db.Elections.FirstOrDefaultAsync(c => c.Id.Equals(Id));
            return election;
        }
        #endregion

        /// <summary>
        /// CRUD Election
        /// </summary>
        
        #region Update Election
        public async Task UpdateElection(Election election)
        {
            _db.Elections.Update(election);
           await  _db.SaveChangesAsync();
        }
        #endregion

        /// <summary>
        /// DELETE ELECTION
        /// </summary>
        
        #region DeleteElection
        public async Task DeleteElection(Election election)
        {
            _db.Remove(election);
           await _db.SaveChangesAsync();
        }
        #endregion
    }
}
