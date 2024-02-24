using DisasterDispatch.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisasterDispatch.Core.Dtos.NotificationUserDtos
{
    public class NotificationUserDto
    {
        public Guid Id { get; set; }
        public Guid NotificationId { get; set; }
        public Notification Notification { get; set; }
        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }
    }
}
