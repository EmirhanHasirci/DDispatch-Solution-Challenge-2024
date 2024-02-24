using DisasterDispatch.Core.Dtos.BaseDtos;
using DisasterDispatch.Core.Dtos.DisasterOperationDtos;
using DisasterDispatch.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisasterDispatch.Core.Services
{
    public interface IDisasterOperationService:IGenericService<DisasterOperation,DisasterOperationDto>
    {
        Task<CustomResponse<DisasterOperationDto>> AddDisasterOperationAsync(DisasterOperationCreateDto dto);
        Task<CustomResponse<List<DisasterOperationWithAssignerAndCategoryDto>>> GetDisasterOperationWithAssignerAndCategoryAsync();
        Task<CustomResponse<NoContentDto>> UpdateDisasterOperationAsync(DisasterOperationUpdateDto updateDto);
        Task<CustomResponse<List<DisasterOperationDto>>> DisasterOperationAddRangeAsync(List<DisasterOperationCreateDto> disasterOperationCreateDto);
    }
}
