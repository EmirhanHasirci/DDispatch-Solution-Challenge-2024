using DisasterDispatch.Core.Entities;
using DisasterDispatch.Core.Repositories;
using DisasterDispatch.Repository.DbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisasterDispatch.Repository.Repositories
{
    public class NeederRepository : GenericRepository<Needer>, INeederRepository
    {
        public NeederRepository(AppDbContext context) : base(context)
        {
        }
    }
}
