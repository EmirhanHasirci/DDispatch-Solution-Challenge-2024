using DisasterDispatch.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisasterDispatch.Core.Repositories
{
     public interface IDisasterOperationRepository:IGenericRepository<DisasterOperation>
    {
        Task<List<DisasterOperation>> GetDisasterOperationsWithUserAndCategories();
        
    }
}
