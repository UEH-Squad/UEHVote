using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UEHVote.Model
{
    public class Votes
    {
        [ForeignKey(nameof(User))]
        public string StudentId { get; set; }

        [ForeignKey(nameof(Election))]
        public string ElectionId { get; set; }
        public string ElectionName { get; set; }
        public DateTime TimeVotes { get; set; }
        
        
    }
}
