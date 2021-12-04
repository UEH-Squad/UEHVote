using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UEHVote.Data.Interfaces;
using UEHVote.Data.Services;
using UEHVote.Data.ViewModels;
using UEHVote.Models;

namespace UEHVote
{
    public class AutoMappingProfile:Profile
    {
        public AutoMappingProfile()
        {
            CreateMap<CandidateService, ICandidateService>();
            CreateMap<CandidateViewModel, CandidateService>();
        }
    }

    
}
