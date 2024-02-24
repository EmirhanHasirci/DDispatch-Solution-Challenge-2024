using DisasterDispatch.Core.Dtos.NeederDtos;
using DisasterDispatch.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisasterDispatch.Core.Services
{
    public interface INeederService: IGenericService<Needer, NeederDto>
    {
    }
}
