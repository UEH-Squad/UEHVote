using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using UEHVote.Common;

namespace UEHVote.Models
{
    public class Election
    {
        public int Id { get; set; }
        [RequiredHasItem(ErrorMessage = "Vui lòng nhập tên")]
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime FinishDate { get; set; }
        [RequiredHasItem(ErrorMessage = "Vui lòng nhập nội dung")]
        public string Details { get; set; }
        public string Banner { get; set; }
        [RequiredLinkValid(ErrorMessage ="Video không hợp lệ")]
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
