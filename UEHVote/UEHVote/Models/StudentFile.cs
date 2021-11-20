using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UEHVote.Model
{
    public class StudentFile
    {
        [Key]
        public int FlieStId { get; set; }
        public string StudentName { get; set; }

        public string DetailStudent { get; set; }

        //[ForeignKey(nameof(Organization))]
        public string OrgId { get; set; }
    }
}
