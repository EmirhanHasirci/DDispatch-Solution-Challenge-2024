using DisasterDispatch.Core.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisasterDispatch.Core.Entities
{
    public class DisasterOperation:BaseEntity
    {
        public DisasterCategory DisasterCategory{ get; set; }
        public Guid DisasterCategoryId { get; set; }
        public string ProvinceId{ get; set; }        
        public AppUser Assigner { get; set; }
        public string AssignerId { get; set; }
        public ICollection<CustomOperation> Operations{ get; set; }

    }
}
