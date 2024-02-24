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
    public class EmergencyReportRepository : GenericRepository<EmergencyReport>,IEmergencyReportRepository
    {
        public EmergencyReportRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<List<EmergencyReport>> GetEmergencyReportsWithCustomOperationsAsync()
        {
            return await _context.EmergencyReports.AsNoTracking().Include(X=>X.CustomOperations).Where(x=>x.Status=="Active").ToListAsync();
        }
    }
}
