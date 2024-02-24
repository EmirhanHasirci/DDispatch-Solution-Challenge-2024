using DisasterDispatch.Core.Dtos.BaseDtos;
using DisasterDispatch.Core.Dtos.PhoneNumberDtos;
using DisasterDispatch.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisasterDispatch.Core.Repositories
{
    public interface IPhoneNumberRepository:IGenericRepository<PhoneNumber>
    {
        Task<List<PhoneNumber>> GetPhoneNumberWithUsersAsync();
        Task<List<PhoneNumber>> GetPhoneNumbersByUser(string userName);
    }
}
