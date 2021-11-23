using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace UEHVote.Models
{
    public class ActivityImage
    {
        public int Id { get; set; }
        public string Url { get; set; }
        [ForeignKey(nameof(Election))]
        public int ElectionId { get; set; }
        public virtual Election Election { get; set; }
    }
}
