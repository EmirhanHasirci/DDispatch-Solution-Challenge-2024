using AutoMapper;
using DisasterDispatch.Core.Dtos.SkillDtos;
using DisasterDispatch.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisasterDispatch.Service.Mapping
{
    public class SkillMapper:Profile
    {
        public SkillMapper()
        {
            CreateMap<Skill, SkillUpdateDto>().ReverseMap();
            CreateMap<Skill, SkillCreateDto>().ReverseMap();
            CreateMap<Skill, SkillDto>().ReverseMap();
            CreateMap<Skill, SkillWithUsersDto>().ReverseMap();
        }
    }
}
