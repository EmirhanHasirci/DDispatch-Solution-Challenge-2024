using DisasterDispatch.Core.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisasterDispatch.Core.Entities
{
    public class DisasterCategory:BaseEntity
    {
        public string Name { get; set; }
        public string Color { get; set; }
        public ICollection<DisasterOperation> DisasterOperations{ get; set; }
    }
}
