using DisasterDispatch.Core.Dtos.BaseDtos;
using DisasterDispatch.Core.Dtos.DisasterCategoryDtos;
using DisasterDispatch.Core.Dtos.SkillDtos;
using DisasterDispatch.Core.Dtos.TitleDtos;
using DisasterDispatch.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisasterDispatch.Core.Services
{
    public interface IDisasterCategoryService:IGenericService<DisasterCategory,DisasterCategoryDto>
    {
        Task<CustomResponse<NoContentDto>> UpdateDisasterCategoryAsync(DisasterCategoryUpdateDto updateDto);
        Task<CustomResponse<DisasterCategoryDto>> AddDisasterCategoryAsync(DisasterCategoryCreateDto dto);
        Task<CustomResponse<List<DisasterCategoryWithDisasterOperationsDto>>> GetDisasterCategoryWithDisasterOperations();
    }
}
