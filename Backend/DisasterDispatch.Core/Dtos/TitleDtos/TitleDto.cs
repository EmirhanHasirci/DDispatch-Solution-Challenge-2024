using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisasterDispatch.Core.Dtos.TitleDtos
{
    public class TitleDto
    {
        public Guid Id{ get; set; }
        public string Name { get; set; }
        public string AppUserId { get; set; }
        public Guid TitleTypeId { get; set; }
        public string TitleTypeName { get; set; }
    }
}
