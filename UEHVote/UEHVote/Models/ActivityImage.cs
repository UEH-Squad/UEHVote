using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
namespace UEHVote.Model
{
    public class ActivityImage
    {
        [ForeignKey(nameof(ActivityFile))]
        public int ActivityId { get; set; }
        public string Image { get; set; }
    }
}
