using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace UEHVote.Models
{
    public class CandidateImage
    {
        public int Id { get; set; }
        public string Url { get; set; }
        [ForeignKey(nameof(Candidate))]
        public int CandidateId { get; set; }
        public virtual Candidate Candidate { get; set; }
    }
}
