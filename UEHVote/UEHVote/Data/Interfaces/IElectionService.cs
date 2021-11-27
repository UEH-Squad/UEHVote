using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UEHVote.Models;

namespace UEHVote.Data.Interfaces
{
    public interface IElectionService
    {
        Task<List<Election>> GetAllElectionsAsync();
        Task InsertElection(Election election);
        Task<Election> GetElectionAsync(int Id);
        Task UpdateElection(Election election);
        Task DeleteElection(Election election);
    }
}
