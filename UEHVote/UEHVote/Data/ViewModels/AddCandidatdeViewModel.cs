using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UEHVote.Models;

namespace UEHVote.Data
{
    public class AddCandidatdeViewMode
    {
        public string Name { get; set; }
        public string FacultyName { get; set; }
        public List<Organization> Faculties { get; set; }
        public string Details { get; set; }
        public string ElectionName { get; set; }
        public List<Election> Elections { get; set; }
        public string Video { get; set; }
        public string Images { get; set; }
    }
}
