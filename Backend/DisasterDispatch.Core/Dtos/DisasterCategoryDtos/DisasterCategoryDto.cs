using DisasterDispatch.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisasterDispatch.Core.Dtos.DisasterCategoryDtos
{
    public class DisasterCategoryDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }        
    }
}
