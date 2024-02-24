using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisasterDispatch.Core.Dtos.OperationEmployeeDtos
{
    public class OperationEmployeeCreateDto
    {        
        public string CustomOperationId { get; set; }
        public string AppUserId { get; set; }
    }
}
