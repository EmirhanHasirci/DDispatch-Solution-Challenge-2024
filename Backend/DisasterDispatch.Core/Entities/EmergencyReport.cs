using DisasterDispatch.Core.Entities.Common;
using DisasterDispatch.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisasterDispatch.Core.Entities
{
    public class EmergencyReport : Location
    {
        public string ReporterTc { get; set; }
        public string ReporterPhoneNumber { get; set; }
        public string Info { get; set; }
        public string Status { get; set; }
        public ICollection<CustomOperation> CustomOperations { get; set; }
    }
}
