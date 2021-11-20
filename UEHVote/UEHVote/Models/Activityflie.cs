using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UEHVote.Model
{
    public class ActivityFile
    {
        [Key]
        public int ActivityId { get; set; }
        public string ActivityName { get; set; }
        
        public string DetailActivity { get; set; }

        [ForeignKey(nameof(Organization))]
        public string OrgId { get; set; }


    }
}
