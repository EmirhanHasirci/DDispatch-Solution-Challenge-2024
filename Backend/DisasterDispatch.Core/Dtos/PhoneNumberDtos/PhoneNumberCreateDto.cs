using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisasterDispatch.Core.Dtos.PhoneNumberDtos
{
    public class PhoneNumberCreateDto
    {
        public string Number { get; set; }
        public string AppUserId { get; set; }
    }
}
