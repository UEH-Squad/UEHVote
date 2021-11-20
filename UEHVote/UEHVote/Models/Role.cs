using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace UEHVote.Model
{
    public class Role : IdentityRole<String>
    {
        

        public string Desciption { get; set; }

    }
}
