using DisasterDispatch.Core.Dtos.CustomOperationDtos;
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
    public class CustomOperationRepository : GenericRepository<CustomOperation>,ICustomOperationRepository
    {
        public CustomOperationRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<List<CustomOperation>> GetActiveOperations(string status)
        {
            return await _context.CustomOperations.Where(x=>x.Status==status).Include(x=>x.DisasterOperation).ThenInclude(x=>x.DisasterCategory).Include(x=>x.EmergencyReport).ToListAsync();
        }

        public async Task<List<CustomOperation>> GetCustomOperationsWithWorkersAsync()
        {
            return await _context.CustomOperations.Include(x => x.EmergencyReport).Include(x => x.Workers).Include(x => x.DisasterOperation).ThenInclude(y => y.DisasterCategory).ToListAsync();
        }

        public async Task<CustomOperation> GetOperationById(string id)
        {
            return await _context.CustomOperations.Where(x => x.Id == Guid.Parse(id)).Include(x=>x.EmergencyReport).Include(x=>x.DisasterOperation).ThenInclude(x=>x.DisasterCategory).FirstOrDefaultAsync();
        }
    }
}
