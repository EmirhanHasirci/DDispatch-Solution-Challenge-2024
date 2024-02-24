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
    public class AddressRepository : GenericRepository<Address>,IAddressRepository
    {
        public AddressRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<List<Address>> GetAddressesByUsername(string username)
        {
            return await _context.Addresses.Include(x => x.AppUser).Where(x => x.AppUser.UserName == username).ToListAsync();
        }

        public async Task<List<Address>> GetAddressesWithUserAsync()
        {
            return await _context.Addresses.Include(x=>x.AppUser).ToListAsync();
        }
    }
}
