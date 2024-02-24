using AutoMapper;
using DisasterDispatch.Core.Dtos.SkillCategoryDtos;
using DisasterDispatch.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisasterDispatch.Service.Mapping
{
    public class SkillCategoryMapper:Profile
    {
        public SkillCategoryMapper()
        {
            CreateMap<SkillCategory, SkillCategoryUpdateDto>().ReverseMap();
            CreateMap<SkillCategory, SkillCategoryCreateDto>().ReverseMap();
            CreateMap<SkillCategory, SkillCategoryDto>().ReverseMap();
        }
    }
}
