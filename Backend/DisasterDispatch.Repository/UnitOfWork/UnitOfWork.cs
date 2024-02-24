using DisasterDispatch.Core.UnitOfWork;
using DisasterDispatch.Repository.DbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisasterDispatch.Repository.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _appDbContext;

        public UnitOfWork(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public void Commit()
        {
            _appDbContext.SaveChanges();
        }

        public async Task CommitAsync()
        {
            await _appDbContext.SaveChangesAsync();
        }
    }
}
