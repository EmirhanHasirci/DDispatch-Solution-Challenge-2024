using DisasterDispatch.Core.Dtos.BaseDtos;
using DisasterDispatch.Core.Dtos.CustomOperationDtos;
using DisasterDispatch.Core.Dtos.CustomOperationDtos;

using DisasterDispatch.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisasterDispatch.Core.Services
{
    public interface ICustomOperationService:IGenericService<CustomOperation,CustomOperationDto>
    {
        Task<CustomResponse<List<CustomOperationWithWorkersDto>>> GetCustomOperationsWithWorkersAsync();
        Task<CustomResponse<NoContentDto>> UpdateCustomOperationAsync(CustomOperationUpdateDto updateDto);
        Task<CustomResponse<CustomOperationDto>> AddCustomOperationAsync(CustomOperationCreateDto dto);
        Task<CustomResponse<List<CustomOperationDto>>> GetActiveOperations(string status);
        Task<CustomResponse<CustomOperationDto>> GetOperationById(string id);
        Task<CustomResponse<CustomOperationDto>> ChangeStatus(string id, string status);
    }
}
