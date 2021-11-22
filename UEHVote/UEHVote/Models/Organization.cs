using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UEHVote.Models
{
    public class Organization
    {
        public int Id { get; set; }
        public int Type { get; set; }
        public string Name { get; set; }
        public virtual ICollection<User> Users { get; set; }
        public virtual ICollection<Candidate> Candidates { get; set; }
    }
}
