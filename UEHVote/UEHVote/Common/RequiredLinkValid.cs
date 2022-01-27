using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UEHVote.Common
{
    public class RequiredLinkValid: ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string link = value.ToString();
            if (link.Contains("http:") || link.Contains("https:") || link=="")
            {
                return ValidationResult.Success;
            }
            return new ValidationResult("Video không hợp lệ");
        }
    }
}
