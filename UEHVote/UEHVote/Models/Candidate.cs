using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace UEHVote.Models
{
    public class Candidate
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [ForeignKey(nameof(Organization))]
        public int OrganizationId { get; set; }
        public string Details { get; set; }
        public string Video { get; set; }
        [ForeignKey(nameof(Election))]
        public int ElectionId { get; set; }
        public virtual Organization Organization { get; set; }
        public virtual Election Election { get; set; }
        public virtual ICollection<CandidateImage> CandidateImages { get; set; }
        public virtual ICollection<VotedCandidate> VotedCandidates { get; set; }
    }
}
