using System;
using System.ComponentModel.DataAnnotations;

namespace UEHVote.Pages.NominationEdit
{
    public class Nomination
    {
        [Required(ErrorMessage = "Trường thông tin bắt buộc")]
        public string Organization { get; set; }

        [Required(ErrorMessage = "Trường thông tin bắt buộc")]
        public string NominationName { get; set; }

        [Required(ErrorMessage = "Trường thông tin bắt buộc")]
        public string Content { get; set; }

        public string VideoLink { get; set; }

        [Required(ErrorMessage = "Trường thông tin bắt buộc")]
        public string ElectionName { get; set; }

        [Required(ErrorMessage = "Trường thông tin bắt buộc")]
        public string OrgCreatesElection { get; set; }

        public string Banner { get; set; }
    }
}
