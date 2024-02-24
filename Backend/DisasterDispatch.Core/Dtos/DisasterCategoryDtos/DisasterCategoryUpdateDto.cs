using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisasterDispatch.Core.Dtos.DisasterCategoryDtos
{
    public class DisasterCategoryUpdateDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
    }
}
