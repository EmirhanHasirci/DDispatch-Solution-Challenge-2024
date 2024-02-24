using DisasterDispatch.Core.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisasterDispatch.Core.Entities
{
    public class Needer:BaseEntity
    {
        public string Tc{ get; set; }
        public string Name{ get; set; }
        public string Surname{ get; set; }
        public string Phone{ get; set; }
        public string Info{ get; set; }
    }
}
