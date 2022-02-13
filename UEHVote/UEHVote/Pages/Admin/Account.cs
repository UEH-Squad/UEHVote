using System;
using System.ComponentModel.DataAnnotations;

namespace UEHVote.Pages.Admin
{
    public class Account
    {
        [Required(ErrorMessage = "Trường thông tin bắt buộc")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Trường thông tin bắt buộc")]
        public string Organization { get; set; }

        [Required(ErrorMessage = "Trường thông tin bắt buộc")]
        public string StudentId { get; set; }

        [Required(ErrorMessage = "Trường thông tin bắt buộc")]
        public string Email { get; set; }

    }
}
