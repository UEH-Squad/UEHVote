using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UEHVote.Models;

namespace UEHVote.Data.ViewModels
{
    public class CandidateViewModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string FacultyName { get; set; }
        public string Details { get; set; }
        public string ElectionName { get; set; }
        public int Votes { get; set; }
        public string Video { get; set; }
        public string Images { get; set; }
    }
}
