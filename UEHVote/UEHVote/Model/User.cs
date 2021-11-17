using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UEHVote.Model
{
    public class User
    {
        
        public string StudentId { get; set; }

        public string FullName { get; set; }
        public string Batch { get; set; }
        public string Class { get; set; }
        public int FacultyId { get; set; }
        public string NotifiedEmail { get; set; }
    }
}
