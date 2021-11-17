using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UEHVote.Model
{
    public class Organization
    {
        [Key]
        public string OrgId { get; set; }

        public string OrgName { get; set; }
        public string OrgEmail { get; set; }
    }
}
