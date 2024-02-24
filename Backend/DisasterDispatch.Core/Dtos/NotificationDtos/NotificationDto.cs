using DisasterDispatch.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisasterDispatch.Core.Dtos.NotificationDtos
{
    public class NotificationDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Context { get; set; }
        public Guid? DisasterOperationId { get; set; }
        public virtual DisasterOperation DisasterOperation { get; set; }
    }
}
