using DisasterDispatch.Core.Dtos.AppUserDtos;
using DisasterDispatch.Core.Dtos.DisasterOperationDtos;
using DisasterDispatch.Core.Dtos.EmergencyReportDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisasterDispatch.Core.Dtos.CustomOperationDtos
{
    public class CustomOperationWithWorkersDto
    {
        public Guid Id { get; set; }
        public EmergencyReportDto EmergencyReport{ get; set; }
        public DisasterOperationWithAssignerAndCategoryDto DisasterOperation { get; set; }
        public ICollection<AppUserDto> Workers { get; set; }
        public string Status { get; set; }
    }
}
