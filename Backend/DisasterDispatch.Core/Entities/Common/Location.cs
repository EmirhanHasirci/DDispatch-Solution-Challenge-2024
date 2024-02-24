using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisasterDispatch.Core.Entities.Common
{
    public abstract class Location:BaseEntity
    {
        public string Province{ get; set; }
        public string District{ get; set; }
        public string Neighbourhood{ get; set; }
        public string Street{ get; set; }
    }
}
