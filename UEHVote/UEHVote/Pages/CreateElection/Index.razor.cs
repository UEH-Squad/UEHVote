using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UEHVote.Pages.CreateElection
{
    public partial class Index
    {
        public class FakeData
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
}
