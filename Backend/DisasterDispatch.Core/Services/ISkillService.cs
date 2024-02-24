using DisasterDispatch.Core.Dtos.BaseDtos;
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
    public interface ISkillService:IGenericService<Skill,SkillDto>
    {
        Task<CustomResponse<NoContentDto>> UpdateSkillAsync(SkillUpdateDto updateDto);
        Task<CustomResponse<SkillDto>> AddSkillAsync(SkillCreateDto dto);
        Task<CustomResponse<List<SkillWithUsersDto>>> GetSkillsWithUsersAsync();
        Task<CustomResponse<List<SkillDto>>> GetSkillsWithCategoriesAsync();
    }
}
