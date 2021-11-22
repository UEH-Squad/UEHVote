using System.ComponentModel.DataAnnotations.Schema;

namespace UEHVote.Models
{
    public class VotedCandidate
    {
        public int Id { get; set; }
        public int VoteId { get; set; }
        public int CandidateId { get; set; }
        public virtual Vote Vote { get; set; }
        public virtual Candidate Candidate { get; set; }
    }
}
