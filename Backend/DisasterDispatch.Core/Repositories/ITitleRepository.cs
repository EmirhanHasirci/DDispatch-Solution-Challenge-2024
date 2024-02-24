using DisasterDispatch.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisasterDispatch.Core.Repositories
{
    public interface ITitleRepository:IGenericRepository<Title>
    {
        Task<List<Title>> GetTitlesWithUser();
        Task<List<Title>> GetTitlesWithTypes();
    }
}
