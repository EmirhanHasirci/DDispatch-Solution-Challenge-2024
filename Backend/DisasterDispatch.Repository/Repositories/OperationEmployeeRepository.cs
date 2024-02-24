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
    public class OperationEmployeeRepository : GenericRepository<OperationEmployee>,IOperationEmployeeRepository
    {
        public OperationEmployeeRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<OperationEmployee> GetOperationByEmployeeId(string id)
        {
            return await _context.OperationEmployees.Include(x => x.AppUser).Include(x => x.CustomOperation).ThenInclude(x => x.DisasterOperation).Include(x => x.CustomOperation).ThenInclude(x => x.EmergencyReport).Where(x => x.CustomOperation.Status == "Active" && x.AppUserId == id).FirstOrDefaultAsync();
        }

        public async Task<List<OperationEmployee>> GetOperationEmployeesWithCustomOperationAndUserAsync()
        {
            return await _context.OperationEmployees.Include(x => x.AppUser).Include(x => x.CustomOperation).ThenInclude(x => x.DisasterOperation).ThenInclude(x=>x.DisasterCategory).Include(x => x.CustomOperation).ThenInclude(x => x.EmergencyReport).Include(x=>x.AppUser).Include(x => x.CustomOperation).ThenInclude(x => x.DisasterOperation).ToListAsync(); 
        }
    }
}
