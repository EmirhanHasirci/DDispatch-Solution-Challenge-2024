using DisasterDispatch.Core.Dtos.BaseDtos;
using DisasterDispatch.Core.Dtos.NotificationDtos;
using DisasterDispatch.Core.Dtos.NotificationUserDtos;
using DisasterDispatch.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisasterDispatch.Core.Services
{
    public interface INotificationUserService:IGenericService<NotificationUser,NotificationUserDto>
    {
        Task<CustomResponse<NotificationUserDto>> UpdateAsync(NotificationUserUpdateDto dto);
        Task<CustomResponse<NotificationUserDto>> AddNotificationUser(NotificationUserCreateDto dto);
        Task<CustomResponse<List<NotificationUserDto>>> GetNotificationUsers();
        Task<CustomResponse<List<NotificationUserDto>>> GetNotificationsByUser(string username);
    }
}
