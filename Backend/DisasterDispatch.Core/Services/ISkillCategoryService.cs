using DisasterDispatch.Core.Dtos.BaseDtos;
using DisasterDispatch.Core.Dtos.SkillCategoryDtos;
using DisasterDispatch.Core.Dtos.TitleTypeDtos;
using DisasterDispatch.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisasterDispatch.Core.Services
{
    public interface ISkillCategoryService:IGenericService<SkillCategory,SkillCategoryDto>
    {
        Task<CustomResponse<List<SkillCategoryDto>>> GetSkillCategoryWithSkills();
        Task<CustomResponse<SkillCategoryDto>> CreateSkillCategoryAsync(SkillCategoryCreateDto dto);
        Task<CustomResponse<NoContentDto>>UpdateSkillCategoryAsync(SkillCategoryUpdateDto updateDto);
    }
}
