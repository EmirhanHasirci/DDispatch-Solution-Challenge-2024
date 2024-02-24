using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DisasterDispatch.Core.Entities.Common;

namespace DisasterDispatch.Core.Entities
{
    public class Address : Location
    {
        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }
    }
}
