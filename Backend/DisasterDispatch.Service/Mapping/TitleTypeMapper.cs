using AutoMapper;
using DisasterDispatch.Core.Dtos.TitleDtos;
using DisasterDispatch.Core.Dtos.TitleTypeDtos;
using DisasterDispatch.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisasterDispatch.Service.Mapping
{
    public class TitleTypeMapper:Profile
    {
        public TitleTypeMapper()
        {
            CreateMap<TitleType, TitleTypeUpdateDto>().ReverseMap();
            CreateMap<TitleType, TitleTypeDto>().ReverseMap();
            CreateMap<TitleType, TitleTypeCreateDto>().ReverseMap();

        }
    }
}
