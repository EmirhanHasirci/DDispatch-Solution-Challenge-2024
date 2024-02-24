using DisasterDispatch.Core.Dtos.OperationEmployeeDtos;
using DisasterDispatch.Core.Dtos.BaseDtos;
using DisasterDispatch.Core.Dtos.OperationEmployeeDtos;
using DisasterDispatch.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DisasterDispatch.Core.Dtos.DisasterOperationDtos;

namespace DisasterDispatch.Core.Services
{
    public interface IOperationEmployeeService:IGenericService<OperationEmployee,OperationEmployeeDto>
    {
        Task<CustomResponse<NoContentDto>> UpdateOperationEmployeeAsync(OperationEmployeeUpdateDto updateDto);
        Task<CustomResponse<OperationEmployeeDto>> AddOperationEmployeeAsync(OperationEmployeeCreateDto dto);
        Task<CustomResponse<List<OperationEmployeeWithCustomOperationAndUser>>> GetOperationEmployeesWithCustomOperationAndUserAsync();
        Task<CustomResponse<OperationEmployeeDto>> ActiveOperation(string userid);
        Task<CustomResponse<List<OperationEmployeeDto>>> AddRange(List<OperationEmployeeCreateDto> operations);
        Task<CustomResponse<List<OperationEmployeeDto>>> OnMissionUsers(string id);
        Task<CustomResponse<List<OperationEmployeeDto>>> GetOperationsByUser(string id);


    }
}
