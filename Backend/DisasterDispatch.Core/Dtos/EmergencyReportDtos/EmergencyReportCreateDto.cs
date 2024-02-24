using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisasterDispatch.Core.Dtos.EmergencyReportDtos
{
    public class EmergencyReportCreateDto
    {
        public Guid? Id{ get; set; }
        public string ReporterTc { get; set; }
        public string ReporterPhoneNumber { get; set; }
        public string Info { get; set; }
        public string Province { get; set; }
        public string District { get; set; }
        public string Neighbourhood { get; set; }
        public string Street { get; set; }
    }
}
