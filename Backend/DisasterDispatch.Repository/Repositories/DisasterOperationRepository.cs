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
    public class DisasterOperationRepository : GenericRepository<DisasterOperation>,IDisasterOperationRepository
    {
        public DisasterOperationRepository(AppDbContext context) : base(context)
        {
        }       
        public async Task<List<DisasterOperation>> GetDisasterOperationsWithUserAndCategories()
        {
            return await _context.DisasterOperations.Include(x => x.DisasterCategory).Include(x => x.Assigner).ToListAsync();
        }
    }
}
