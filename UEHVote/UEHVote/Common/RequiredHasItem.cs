using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UEHVote.Common
{
    public class RequiredHasItem: ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            IList list = value as IList;

            if (list is not null && list.Count > 0)
            {
                return ValidationResult.Success;
            }
            return new ValidationResult("Vui lòng không để trống!");
        }
    }
}
