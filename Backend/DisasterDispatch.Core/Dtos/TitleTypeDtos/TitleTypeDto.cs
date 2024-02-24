using DisasterDispatch.Core.Dtos.TitleDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisasterDispatch.Core.Dtos.TitleTypeDtos
{
    public class TitleTypeDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ICollection<TitleWithUserDto>? Titles{ get; set; }
    }
}
