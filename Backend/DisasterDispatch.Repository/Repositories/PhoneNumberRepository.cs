using DisasterDispatch.Core.Dtos.PhoneNumberDtos;
using DisasterDispatch.Core.Entities;
using DisasterDispatch.Core.Repositories;
using DisasterDispatch.Repository.DbContexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisasterDispatch.Repository.Repositories
{
    public class PhoneNumberRepository : GenericRepository<PhoneNumber>,IPhoneNumberRepository
    {
        public PhoneNumberRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<List<PhoneNumber>> GetPhoneNumbersByUser(string userName)
        {
            return await _context.PhoneNumbers.Include(x=>x.AppUser).Where(x=>x.AppUser.UserName==userName).ToListAsync();
        }

        public async Task<List<PhoneNumber>> GetPhoneNumberWithUsersAsync()
        {
            return await _context.PhoneNumbers.Include(x => x.AppUser).ToListAsync();
        }
    }
}
