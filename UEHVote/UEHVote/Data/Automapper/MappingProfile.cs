using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UEHVote.Data.ViewModels;
using UEHVote.Models;

namespace UEHVote.Data.Automapper
{
    public class MappingProfile:Profile 
    {
        public MappingProfile()
        {
            CreateMap<Election, DetailVoteViewModel>()
               .ForMember(t => t.Id, tt => tt.MapFrom(h => h.Id))
               .ForMember(t => t.Organization, tt => tt.MapFrom(h => h.User.Organization.Name))
               .ForMember(t => t.Name, tt => tt.MapFrom(h => h.Name))
               .ForMember(t => t.Details, tt => tt.MapFrom(h => h.Details))
               .ForMember(t => t.Video, tt => tt.MapFrom(h => h.Video))
               .ForMember(t => t.ActivityImages, tt => tt.MapFrom(h => h.ActivityImages));
            CreateMap<Candidate, DetailVoteViewModel>()
               .ForMember(t => t.Id, tt => tt.MapFrom(h => h.Id))
               .ForMember(t => t.Organization, tt => tt.MapFrom(h => h.Organization.Name))
               .ForMember(t => t.Name, tt => tt.MapFrom(h => h.Name))
               .ForMember(t => t.Details, tt => tt.MapFrom(h => h.Details))
               .ForMember(t => t.ElectionId, tt => tt.MapFrom(h => h.ElectionId))
               .ForMember(t => t.Video, tt => tt.MapFrom(h => h.Video))
               .ForMember(t => t.CandidateImages, tt => tt.MapFrom(h => h.CandidateImages));
        }
    }
}
