using DisasterDispatch.Core.Dtos.BaseDtos;
using DisasterDispatch.Core.Dtos.NotificationDtos;
using DisasterDispatch.Core.Dtos.TitleDtos;
using DisasterDispatch.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisasterDispatch.Core.Services
{
    public interface INotificationService : IGenericService<Notification, NotificationDto>
    {
        Task<CustomResponse<NotificationDto>> UpdateAsync(NotificationUpdateDto dto);
        Task<CustomResponse<NotificationDto>> AddNotification(NotificationCreateDto dto);
        Task<CustomResponse<List<NotificationDto>>> GetNotifications();
        
    }
}
