using Abp.Specifications;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UEHVote.Data.Interfaces;
using UEHVote.Data.ViewModels;
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
        public async Task<List<CandidateViewModel>> GetAllCandidatesAsync()
        {
            var candidate1 = new CandidateViewModel
            {
                ID = 1,
                Name = "Nguyen Van A",
                FacultyName = "Khoa BIT",
                Details = "Lop ST, K45",
                ElectionName = "Can bo doan hoi tieu bieu",
                Votes = 50
            };
            var candidate2 = new CandidateViewModel
            {
                ID = 2,
                Name = "Nguyen Van B",
                FacultyName = "Khoa KQM",
                Details = "Lop ST, K45",
                ElectionName = "Can bo doan hoi tieu bieu",
                Votes = 60
            };
            var candidate3 = new CandidateViewModel
            {
                ID = 3,
                Name = "Nguyen Van C",
                FacultyName = "Khoa KET",
                Details = "Lop ST, K45",
                ElectionName = "Can bo doan hoi tieu bieu",
                Votes = 40
            };
            var candidateList = new List<CandidateViewModel>
            {
                candidate1,
                candidate2,
                candidate3
            };
            return candidateList;
        }
    }
}
