using AutoMapper;
using DisasterDispatch.Core.Dtos.NotificationUserDtos;
using DisasterDispatch.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisasterDispatch.Service.Mapping
{
    public class NotificationUserMapper:Profile
    {
        public NotificationUserMapper()
        {
            CreateMap<NotificationUser, NotificationUserDto>().ReverseMap();
            CreateMap<Notification, NotificationUserCreateDto>().ReverseMap();
            CreateMap<Notification, NotificationUserUpdateDto>().ReverseMap();
        }
    }
}
