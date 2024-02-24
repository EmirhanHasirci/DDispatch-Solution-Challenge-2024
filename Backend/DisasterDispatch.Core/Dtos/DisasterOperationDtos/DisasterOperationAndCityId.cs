using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisasterDispatch.Core.Dtos.DisasterOperationDtos
{
    public class DisasterOperationAndCityId
    {
        public string[] CitiyId{ get; set; }
        public string DisasterCategoryId { get; set; }
    }
}
