using System;
using System.ComponentModel.DataAnnotations;

namespace UEHVote.Pages.NominationEdit
{
    public class Nomination
    {
        [Required(ErrorMessage = "Trường thông tin bắt buộc")]
        public string Organization { get; set; }

        [Required]
        public string NominationName { get; set; }

        [Required]
        public string Content { get; set; }

        public string VideoLink { get; set; }

        [Required]
        public string ElectionName { get; set; }

        [Required]
        public string OrgCreatesElection { get; set; }

        public string Banner { get; set; }

        public DateTime OpenDate { get; set; } = DateTime.Now.Date;

    }
}
