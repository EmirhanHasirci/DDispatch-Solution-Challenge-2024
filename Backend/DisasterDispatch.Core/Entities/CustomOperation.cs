using DisasterDispatch.Core.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisasterDispatch.Core.Entities
{
    public class CustomOperation:BaseEntity
    {
        public Guid EmergencyReportId{ get; set; }
        public EmergencyReport EmergencyReport{ get; set; }
        public Guid DisasterOperationId{ get; set; }
        public DisasterOperation DisasterOperation{ get; set; }
        public ICollection<AppUser> Workers{ get; set; }
        public string Status{ get; set; }

    }
}
