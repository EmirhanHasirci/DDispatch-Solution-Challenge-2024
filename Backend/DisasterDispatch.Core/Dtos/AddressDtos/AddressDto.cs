using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisasterDispatch.Core.Dtos.AddressDtos
{
    public class AddressDto
    {
        public Guid Id { get; set; }
        public string Province { get; set; }
        public string District { get; set; }
        public string Neighbourhood { get; set; }
        public string Street { get; set; }
        public string AppUserId { get; set; }
    }
}
