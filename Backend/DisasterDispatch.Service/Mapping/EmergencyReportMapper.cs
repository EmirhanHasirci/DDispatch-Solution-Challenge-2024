using AutoMapper;
using DisasterDispatch.Core.Dtos.EmergencyReportDtos;
using DisasterDispatch.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisasterDispatch.Service.Mapping
{
    public class EmergencyReportMapper:Profile
    {
        public EmergencyReportMapper()
        {
            CreateMap<EmergencyReport, EmergencyReportDto>().ReverseMap();
            CreateMap<EmergencyReport, EmergencyReportCreateDto>().ReverseMap();
            CreateMap<EmergencyReport, EmergencyReportUpdateDto>().ReverseMap();
            CreateMap<EmergencyReport, EmergencyReportWithCustomOperationsDto>().ReverseMap();
        }
    }
}
