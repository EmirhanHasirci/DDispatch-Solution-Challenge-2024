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
    public class SkillRepository : GenericRepository<Skill>,ISkillRepository
    {
        public SkillRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<List<Skill>> GetSkillsWithUser()
        {
            return await _context.Skills.Include(x=>x.AppUser).Include(y=>y.SkillCategory).ToListAsync();
        }
        public async Task<List<Skill>> GetSkillsWithCategories()
        {
            return await _context.Skills.Include(y => y.SkillCategory).ToListAsync();
        }
    }
}
