using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace UEHVote.Models
{
    public class User : IdentityUser
    {
        public string StudentId { get; set; }
        public string FullName { get; set; }
        public string Batch { get; set; }
        [ForeignKey(nameof(Organization))]
        public int OrganizationId { get; set; }
        public virtual Organization Organization { get; set; }
        public virtual ICollection<Election> Elections { get; set; }
        public virtual ICollection<Vote> Votes { get; set; }
    }
}
