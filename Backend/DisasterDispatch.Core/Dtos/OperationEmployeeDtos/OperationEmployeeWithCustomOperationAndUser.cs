using DisasterDispatch.Core.Dtos.AppUserDtos;
using DisasterDispatch.Core.Dtos.CustomOperationDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisasterDispatch.Core.Dtos.OperationEmployeeDtos
{
    public class OperationEmployeeWithCustomOperationAndUser
    {
        public Guid Id { get; set; }
        public CustomOperationDto CustomOperation { get; set; }
        public AppUserDto Worker { get; set; }
    }
}
