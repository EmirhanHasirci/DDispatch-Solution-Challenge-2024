using DisasterDispatch.Core.Dtos.ContactDtos;
using DisasterDispatch.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisasterDispatch.Core.Services
{
    public interface IContactService:IGenericService<Contact,ContactDto>
    {
    }
}
