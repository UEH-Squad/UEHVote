using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UEHVote.Data.ViewModels;
using UEHVote.Models;

namespace UEHVote.Data.Interfaces
{
    public interface IElectionService
    {
        /// <summary>
        /// IElectionService
        /// </summary>
        /// <returns></returns>
        Task<List<Election>> GetAllElectionsAsync();
        Task<List<ActivityImage>> GetAllActivityImagesAsync();
        Task InsertElection(Election election);
        Task InsertActivityImage(ActivityImage activityImage);
        Task<Election> GetElectionAsync(int Id);
        Task<DetailVoteViewModel> GetDetailVoteAsync(int Id);
        Task UpdateElection(Election election);
        Task DeleteElection(Election election);
        Task DeleteActivityImage(ActivityImage activityImage);
        string StatusElection(Election election);
    }
}
