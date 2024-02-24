using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisasterDispatch.Core.Dtos.ContactDtos
{
    public class ContactDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PhoneNumber { get; set; }
        public string Mail { get; set; }
        public string Subject { get; set; }
        public string Context { get; set; }
    }
}
