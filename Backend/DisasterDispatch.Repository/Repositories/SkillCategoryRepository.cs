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
    public class SkillCategoryRepository : GenericRepository<SkillCategory>,ISkillCategoryRepository
    {
        public SkillCategoryRepository(AppDbContext context) : base(context)
        {
        }

        public Task<List<SkillCategory>> GetSkillCategoryWithSkills()
        {
            return _context.SkillCategories.Include(x => x.Skills).ThenInclude(x => x.AppUser).ToListAsync();
        }
    }
}
