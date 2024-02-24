using DisasterDispatch.Core.Dtos.BaseDtos;
using DisasterDispatch.Core.Dtos.TitleDtos;
using DisasterDispatch.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisasterDispatch.Core.Services
{
    public interface ITitleService:IGenericService<Title,TitleDto>
    {
        Task<CustomResponse<NoContentDto>> UpdateAsync(TitleUpdateDto dto);
        Task<CustomResponse<TitleDto>> AddTitle(TitleCreateDto dto);
        Task<CustomResponse<List<TitleWithUserDto>>> GetTitlesWithUser();
        Task<CustomResponse<List<TitleDto>>> GetTitlesWithTypes();

    }
}
