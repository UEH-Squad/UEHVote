using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace UEHVote.Model
{
    public class Rolename
    {
        [Key]
        public string RoleID { get; set; }

        public string RoleName { get; set; }
    }
}
