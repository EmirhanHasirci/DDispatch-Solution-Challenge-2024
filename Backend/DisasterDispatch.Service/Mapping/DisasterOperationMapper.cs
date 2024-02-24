using AutoMapper;
using DisasterDispatch.Core.Dtos.DisasterOperationDtos;
using DisasterDispatch.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisasterDispatch.Service.Mapping
{
    public class DisasterOperationMapper : Profile
    {
        public DisasterOperationMapper()
        {
            CreateMap<DisasterOperation, DisasterOperationDto>().ReverseMap();
            CreateMap<DisasterOperation, DisasterOperationCreateDto>().ReverseMap();
            CreateMap<DisasterOperation, DisasterOperationUpdateDto>().ReverseMap();
            CreateMap<DisasterOperation, DisasterOperationWithAssignerAndCategoryDto>().ReverseMap();
        }
    }
}
