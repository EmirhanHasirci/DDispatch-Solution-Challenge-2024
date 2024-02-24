using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisasterDispatch.Core.Dtos.NotificationDtos
{
    public class NotificationCreateDto
    {
        public string Title { get; set; }
        public string Context { get; set; }
        public Guid? DisasterOperationId { get; set; }
    }
}
