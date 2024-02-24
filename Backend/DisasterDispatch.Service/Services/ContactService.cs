using DisasterDispatch.Core.Dtos.ContactDtos;
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
    public class ContactService : GenericService<Contact, ContactDto>, IContactService
    {
        private readonly IContactRepository _contactRepository;
        public ContactService(IUnitOfWork unitOfWork, IGenericRepository<Contact> genericRepository, IContactRepository contactRepository) : base(unitOfWork, genericRepository)
        {
            _contactRepository = contactRepository;
        }
    }
}
