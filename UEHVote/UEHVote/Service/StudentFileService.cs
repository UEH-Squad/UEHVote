using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UEHVote.Data;
using UEHVote.Interface;

namespace UEHVote.Service
{
    public class StudentFileService : IStudentFileService
    {
        private readonly ApplicationDbContext _context;
    }
}
