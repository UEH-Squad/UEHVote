using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UEHVote.Models
{
    public class Election
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime FinishDate { get; set; }
        public string Details { get; set; }
        public string Banner { get; set; }
        public string Video { get; set; }
        public bool IsForIndividuals { get; set; }
        public bool IsAllowed { get; set; }
        [ForeignKey(nameof(User))]
        public string UserId { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<Vote> Votes { get; set; }
        public virtual ICollection<Candidate> Candidates { get; set; }
        public virtual ICollection<ActivityImage> ActivityImages { get; set; }
    }
}
