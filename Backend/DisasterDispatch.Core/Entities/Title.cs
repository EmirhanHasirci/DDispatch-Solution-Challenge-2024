using DisasterDispatch.Core.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisasterDispatch.Core.Entities
{
    public class Title:BaseEntity
    {
        public string AppUserId { get; set; }
        public AppUser AppUser{ get; set; }
        public string Name{ get; set; }
        public Guid TitleTypeId{ get; set; }
        public TitleType TitleType{ get; set; }
    }
}
