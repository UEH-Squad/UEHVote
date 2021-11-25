using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UEHVote.Models;

namespace UEHVote.Data
{
    public class ElectionService
    {
        /// <summary>
        /// CRUD Election
        /// </summary>
        private readonly ApplicationDbContext _db;
        public ElectionService(ApplicationDbContext db)
        {
            _db = db;
        }

        //Get All

        public async Task<List<Election>> GetAllElectionsAsync()
        {
            return await _db.Elections.ToListAsync();
        }

        #region Insert Election
        public void InsertElection(Election election)
        {
            _db.Elections.Add(election);
             _db.SaveChanges();
        }

        #endregion

        #region Get Election by Id
        public async Task<Election> GetElectionAsync(int Id)
        {
            Election election = await _db.Elections.FirstOrDefaultAsync(c => c.Id.Equals(Id));
            return election;
        }
        #endregion

        #region Update Election
        public void UpdateElection(Election election)
        {
            _db.Elections.Update(election);
             _db.SaveChanges();
        }
        #endregion

        #region DeleteElection
        public void DeleteElection(Election election)
        {
            _db.Remove(election);
             _db.SaveChanges();
        }
        #endregion
    }
}
