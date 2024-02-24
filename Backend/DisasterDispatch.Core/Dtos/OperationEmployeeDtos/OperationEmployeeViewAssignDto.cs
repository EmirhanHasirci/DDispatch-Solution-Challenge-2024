using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisasterDispatch.Core.Dtos.OperationEmployeeDtos
{
    public class OperationEmployeeViewAssignDto
    {
        public string[] UserIds{ get; set; }
        public string CustomOperationId{ get; set; }
    }
}
