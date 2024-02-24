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
    public class CertificateRepository : GenericRepository<Certificate>,ICertificateRepository
    {
        public CertificateRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<List<Certificate>> GetCertificatesWithUserAsync()
        {
            return await _context.Certificates.Include(x => x.AppUser).ToListAsync();
        }
    }
}
