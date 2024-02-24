using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisasterDispatch.Core.Dtos.CustomOperationDtos
{
    public class CustomOperationUpdateDto
    {
        public Guid Id { get; set; }
        public Guid EmergencyReportId { get; set; }
        public Guid DisasterOperationId { get; set; }
        public string Status { get; set; }
    }
}
