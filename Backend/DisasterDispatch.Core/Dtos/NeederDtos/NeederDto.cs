using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisasterDispatch.Core.Dtos.NeederDtos
{
    public class NeederDto
    {
        public Guid? Id { get; set; }
        public string Tc { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Phone { get; set; }
        public string Info { get; set; }
    }
}
