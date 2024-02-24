using DisasterDispatch.Core.Dtos.BaseDtos;
using DisasterDispatch.Core.Dtos.TitleTypeDtos;
using DisasterDispatch.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisasterDispatch.Core.Services
{
    public interface ITitleTypeService:IGenericService<TitleType,TitleTypeDto>
    {
        Task<CustomResponse<List<TitleTypeDto>>> GetTitleTypesWithTitles();
        Task<CustomResponse<NoContentDto>> UpdateTitleTypeAsync(TitleTypeUpdateDto updateDto);
        Task<CustomResponse<TitleTypeDto>> CreateTitleTypeAsync(TitleTypeCreateDto dto);
    }
}
