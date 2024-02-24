using AutoMapper;
using DisasterDispatch.Core.Dtos.DisasterCategoryDtos;
using DisasterDispatch.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisasterDispatch.Service.Mapping
{
    public class DisasterCategoryMapper:Profile
    {
        public DisasterCategoryMapper()
        {
            CreateMap<DisasterCategory, DisasterCategoryCreateDto>().ReverseMap();
            CreateMap<DisasterCategory, DisasterCategoryDto>().ReverseMap();
            CreateMap<DisasterCategory, DisasterCategoryUpdateDto>().ReverseMap();
            CreateMap<DisasterCategory, DisasterCategoryWithDisasterOperationsDto>().ReverseMap();
        }
    }
}
