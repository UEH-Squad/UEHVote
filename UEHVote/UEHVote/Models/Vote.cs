using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UEHVote.Models
{
    public class Vote
    {       
        public int Id { get; set; }
        [ForeignKey(nameof(User))]
        public string UserId { get; set; }
        [ForeignKey(nameof(Election))]
        public int ElectionId { get; set; }
        public DateTime Time { get; set; }
        public virtual User User  { get; set; }
        public virtual Election Election { get; set; }       
        public virtual ICollection<VotedCandidate> VotedCandidates  { get; set; }
    }
}
