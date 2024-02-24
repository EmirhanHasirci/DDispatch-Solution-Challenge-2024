using DisasterDispatch.Core.Dtos.BaseDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DisasterDispatch.Core.Services
{
    public interface IGenericService<Entity,Dto> where Entity : class where Dto: class
    {
        Task<CustomResponse<Dto>> GetByIdAsync(string id);
        Task<CustomResponse<IEnumerable<Dto>>> GetAllAsync();

        Task<CustomResponse<IEnumerable<Dto>>> Where(Expression<Func<Entity, bool>> expression);

        Task<CustomResponse<bool>> AnyAsync(Expression<Func<Entity, bool>> expression);

        Task<CustomResponse<Dto>> AddAsync(Dto dto);

        Task<CustomResponse<IEnumerable<Dto>>> AddRangeAsync(IEnumerable<Dto> dtos);

        Task<CustomResponse<NoContentDto>> UpdateAsync(Dto dto);

        Task<CustomResponse<NoContentDto>> RemoveAsync(string id);

        Task<CustomResponse<NoContentDto>> RemoveRangeAsync(IEnumerable<string> ids);
    }
}
