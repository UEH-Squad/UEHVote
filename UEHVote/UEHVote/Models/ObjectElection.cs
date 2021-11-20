using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UEHVote.Model
{
    public class ObjectElection
    {
        [Key]
        public int ObjElectionID { get; set; }
        public string ObjElectionName { get; set; }

        [ForeignKey(nameof(Candidate))]
        public string CandidateId { get; set; }

        [ForeignKey(nameof(ActivityVoted))]
        public string ActivityVotedId { get; set; }
    }
}
