using DisasterDispatch.Core.Dtos.AppRoleDtos;
using DisasterDispatch.Core.Dtos.AppUserDtos;
using DisasterDispatch.Core.Dtos.BaseDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisasterDispatch.Core.Services
{
    public interface IUserService
    {
        Task<CustomResponse<AppUserDto>> CreateUserAsync(UserSignUpDto signInDto);
        Task<CustomResponse<AppUserDto>> GetUserByNameAsync(string userName);
        Task<CustomResponse<AppUserEditDto>> GetUserByNameForEditAsync(string userName);
        Task<CustomResponse<AppUserDto>> GetUserByTcAsync(string tc);
        Task<CustomResponse<AppUserDto>>LoginAsycn(UserLoginDto userLoginDto);
        Task<CustomResponse<List<string>>>GetRolesByUsername(string username);
        Task<CustomResponse<NoContentDto>> Logout();
        Task<CustomResponse<AppUserEditDto>> EditUser(AppUserEditDto p);
        Task<CustomResponse<AppUserDto>> ChangeStatus(StatusChangeDto dto);
        Task<CustomResponse<List<AppUserDto>>> GetUsersByCity(string city);
        Task<CustomResponse<List<AppUserDto>>> GetUsers();


    }
}
