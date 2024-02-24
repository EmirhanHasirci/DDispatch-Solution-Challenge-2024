using DisasterDispatch.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisasterDispatch.Core.Dtos.CustomOperationDtos
{
    public class CustomOperationDto
    {
        public Guid Id { get; set; }
        public Guid EmergencyReportId { get; set; }
        public EmergencyReport EmergencyReport{ get; set; }
        public Guid DisasterOperationId { get; set; }       
        public DisasterOperation DisasterOperation{ get; set; }
        public ICollection<AppUser> Workers { get; set; }
        public string Status { get; set; }
    }
}
