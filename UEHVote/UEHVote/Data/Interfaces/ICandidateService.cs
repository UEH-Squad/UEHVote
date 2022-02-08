using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using UEHVote.Data.ViewModels;
using UEHVote.Models;

namespace UEHVote.Data.Interfaces
{
    public interface ICandidateService
    {
        Task<List<Candidate>> GetAllCandidatesAsync();
        List<Candidate> GetAllCandidatesById(int id);
        Task<List<CandidateImage>> GetAllCandidateImagesAsync();
        string GetCandidateImageById(int id);
        Task InsertCandidate(Candidate candidate);
        Task InsertCandidateImage(CandidateImage candidateImage);
        Task<Candidate> GetCandidateAsync(int Id);
        Task<DetailVoteViewModel> GetDetailCandidateAsync(int Id);
        Task UpdateCandidate(Candidate candidate);
        Task DeleteCandidate(Candidate candidate);
        Task DeleteCandidateImage(CandidateImage candidateImage);
    }
}