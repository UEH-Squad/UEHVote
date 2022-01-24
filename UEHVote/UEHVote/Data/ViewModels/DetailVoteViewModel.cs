using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UEHVote.Models;

namespace UEHVote.Data.ViewModels
{
    public class DetailVoteViewModel
    {
        public int Id { get; set; }
        public string Organization { get; set; }
        public string Name { get; set; }
        public string Details { get; set; }
        public string Banner { get; set; }
        public string Video { get; set; }
        public int TotalVoted { get; set; }
        public int ElectionId { get; set; }
        public ICollection<ActivityImage> ActivityImages { get; set; }
        public ICollection<CandidateImage> CandidateImages { get; set; }
    }
}
