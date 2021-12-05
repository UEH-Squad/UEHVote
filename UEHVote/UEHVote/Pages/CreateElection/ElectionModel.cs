using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace UEHVote.Pages.CreateElection
{
    public class ElectionModel
    {
        [Required(ErrorMessage = "Trường thông tin bắt buộc")]
        public string Organization { get; set; }

        [Required(ErrorMessage = "Trường thông tin bắt buộc")]
        public string NominationName { get; set; }

        [Required(ErrorMessage = "Trường thông tin bắt buộc")]
        public string Content { get; set; }

        public string VideoLink { get; set; }
        public string Banner { get; set; }
    }
}
