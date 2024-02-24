using DisasterDispatch.Core.Dtos.AppUserDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisasterDispatch.Core.Dtos.PhoneNumberDtos
{
    public class PhoneNumberWithUserDto
    {
        public Guid Id { get; set; }
        public string Number { get; set; }
        public AppUserDto AppUser { get; set; }
    }
}
