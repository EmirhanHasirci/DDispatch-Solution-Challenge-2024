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
    public class DisasterCategoryRepository : GenericRepository<DisasterCategory>,IDisasterCategoryRepository
    {
        public DisasterCategoryRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<List<DisasterCategory>> GetDisasterCategoriesWithDisasterOperationsAsync()
        {
           return await _context.DisasterCategories.Include(x=>x.DisasterOperations).ToListAsync();
        }
    }
}
