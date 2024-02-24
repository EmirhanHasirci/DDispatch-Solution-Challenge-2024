using DisasterDispatch.Core.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisasterDispatch.Core.Entities
{
    public class PhoneNumber : BaseEntity
    {
        public string Number { get; set; }
        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }

    }
}
