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
    public class TitleTypeRepository : GenericRepository<TitleType>,ITitleTypeRepository
    {
        public TitleTypeRepository(AppDbContext context) : base(context)
        {
        }

        public Task<List<TitleType>> GetTitleTypesWithTitles()
        {
            return _context.TitleTypes.Include(x=>x.Titles).ThenInclude(x=>x.AppUser).ToListAsync();
        }
    }
}
