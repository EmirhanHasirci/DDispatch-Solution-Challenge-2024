using DisasterDispatch.Core.Dtos.AppUserDtos;
using DisasterDispatch.Core.Dtos.DisasterCategoryDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisasterDispatch.Core.Dtos.DisasterOperationDtos
{
    public class DisasterOperationWithAssignerAndCategoryDto
    {
        public Guid Id { get; set; }
        public string ProvinceId { get; set; }
        public AppUserDto Assigner{ get; set; }
        public DisasterCategoryDto DisasterCategory{ get; set; }
    }
}
