using DisasterDispatch.Core.Dtos.AppRoleDtos;
using DisasterDispatch.Core.Dtos.BaseDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisasterDispatch.Core.Services
{
    public interface IRoleService
    {
        Task<CustomResponse<AppRoleDto>> GetRoleAsync(string roleId);
        Task<CustomResponse<AppRoleDto>> AddRoleAsync(AppRoleCreateDto roleDto);
    }
}
