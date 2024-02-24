using DisasterDispatch.Core.Dtos.CustomOperationDtos;
using DisasterDispatch.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisasterDispatch.Core.Dtos.OperationEmployeeDtos
{
    public class OperationEmployeeDto
    {
        public Guid Id { get; set; }
        public Guid CustomOperationId { get; set; }
        public CustomOperationDto CustomOperation{ get; set; }
        public string AppUserId { get; set; }
        public AppUser AppUser{ get; set; }
    }
}
