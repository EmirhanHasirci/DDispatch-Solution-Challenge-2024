using AutoMapper;
using DisasterDispatch.Core.Dtos.TitleDtos;
using DisasterDispatch.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisasterDispatch.Service.Mapping
{
    internal class TitleMapper:Profile
    {
        public TitleMapper()
        {
            CreateMap<Title, TitleDto>().ReverseMap();
            CreateMap<Title, TitleUpdateDto>().ReverseMap();
            CreateMap<Title, TitleWithUserDto>().ReverseMap();
            CreateMap<Title, TitleCreateDto>().ReverseMap();
        }
    }
}
