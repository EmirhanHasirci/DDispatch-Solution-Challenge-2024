using DisasterDispatch.Core.Dtos.AppUserDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisasterDispatch.Core.Dtos.TitleDtos
{
    public class TitleWithUserDto 
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid TitleTypeId { get; set; }
        public string TitleTypeName { get; set; }        
        public AppUserDto AppUser { get; set; }
    }
}
