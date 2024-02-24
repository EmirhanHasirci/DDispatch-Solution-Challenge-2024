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
    public class TitleRepository : GenericRepository<Title>, ITitleRepository
    {
        public TitleRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<List<Title>> GetTitlesWithUser()
        {
            return await _context.Titles.Include(x=>x.AppUser).Include(x=>x.TitleType).ToListAsync();
        }
        public async Task<List<Title>> GetTitlesWithTypes()
        {
            return await _context.Titles.Include(x => x.TitleType).ToListAsync();
        }
    }
}
