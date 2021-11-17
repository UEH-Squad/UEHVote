using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UEHVote.Model
{
    public class Election
    {
        [Key]
        public string ElectionId { get; set; }
        public string ElectionName { get; set; }

        [ForeignKey(nameof(ObjElectionID))]
        public int ObjElectionID { get; set; }
        public string ObjElectionName { get; set; }
        public string Numbervote { get; set; }
        public DateTime Startday { get; set; }
        public DateTime Finishday { get; set; }
        public string DetailElection { get; set; }
    }
}
