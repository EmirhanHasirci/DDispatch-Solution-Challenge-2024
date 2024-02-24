using DisasterDispatch.Core.Dtos.NeederDtos;
using DisasterDispatch.Core.Dtos.OperationEmployeeDtos;
using DisasterDispatch.Core.Entities;
using DisasterDispatch.Core.Repositories;
using DisasterDispatch.Core.Services;
using DisasterDispatch.Core.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisasterDispatch.Service.Services
{
    public class NeederService : GenericService<Needer, NeederDto>, INeederService
    {
        private readonly INeederRepository _repository;
        public NeederService(IUnitOfWork unitOfWork, IGenericRepository<Needer> genericRepository, INeederRepository repository) : base(unitOfWork, genericRepository)
        {
            _repository = repository;
        }

    }
}
