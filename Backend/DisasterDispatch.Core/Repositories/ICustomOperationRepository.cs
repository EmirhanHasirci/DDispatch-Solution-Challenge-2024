using DisasterDispatch.Core.Dtos.BaseDtos;
using DisasterDispatch.Core.Dtos.CustomOperationDtos;
using DisasterDispatch.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisasterDispatch.Core.Repositories
{
    public interface ICustomOperationRepository:IGenericRepository<CustomOperation>
    {
        Task<List<CustomOperation>> GetCustomOperationsWithWorkersAsync();
        Task<List<CustomOperation>> GetActiveOperations(string status);
        Task<CustomOperation> GetOperationById(string id);
    }
}
