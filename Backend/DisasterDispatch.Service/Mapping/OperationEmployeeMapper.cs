using AutoMapper;
using DisasterDispatch.Core.Dtos.OperationEmployeeDtos;
using DisasterDispatch.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisasterDispatch.Service.Mapping
{
    public class OperationEmployeeMapper:Profile
    {
        public OperationEmployeeMapper()
        {
            CreateMap<OperationEmployee, OperationEmployeeDto>().ReverseMap();
            CreateMap<OperationEmployee, OperationEmployeeCreateDto>().ReverseMap();
            CreateMap<OperationEmployee, OperationEmployeeUpdateDto>().ReverseMap();
            CreateMap<OperationEmployee, OperationEmployeeWithCustomOperationAndUser>().ReverseMap();
        }
    }
}
