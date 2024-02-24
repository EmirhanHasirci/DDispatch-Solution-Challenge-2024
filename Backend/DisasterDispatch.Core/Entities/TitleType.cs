using DisasterDispatch.Core.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisasterDispatch.Core.Entities
{
    public class TitleType:BaseEntity
    {
        public string Name{ get; set; }
        public ICollection<Title> Titles{ get; set; }
    }
}
