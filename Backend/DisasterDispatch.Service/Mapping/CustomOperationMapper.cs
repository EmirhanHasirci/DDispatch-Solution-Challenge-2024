using AutoMapper;
using DisasterDispatch.Core.Dtos.CustomOperationDtos;
using DisasterDispatch.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisasterDispatch.Service.Mapping
{
    public class CustomOperationMapper:Profile
    {
        public CustomOperationMapper()
        {
            CreateMap<CustomOperation, CustomOperationDto>().ReverseMap();
            CreateMap<CustomOperation, CustomOperationCreateDto>().ReverseMap();
            CreateMap<CustomOperation, CustomOperationUpdateDto>().ReverseMap();
            CreateMap<CustomOperation, CustomOperationWithWorkersDto>().ReverseMap();
        }
    }
}
