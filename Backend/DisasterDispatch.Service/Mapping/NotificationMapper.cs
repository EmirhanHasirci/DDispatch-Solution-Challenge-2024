using AutoMapper;
using DisasterDispatch.Core.Dtos.NotificationDtos;
using DisasterDispatch.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisasterDispatch.Service.Mapping
{
    public class NotificationMapper:Profile
    {
        public NotificationMapper()
        {
            CreateMap<Notification, NotificationDto>().ReverseMap();
            CreateMap<Notification, NotificationCreateDto>().ReverseMap();
            CreateMap<Notification, NotificationUpdateDto>().ReverseMap();
        }
    }
}
