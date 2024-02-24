using DisasterDispatch.Core.Dtos.SkillDtos;
using DisasterDispatch.Core.Dtos.TitleDtos;
using DisasterDispatch.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisasterDispatch.Core.Dtos.SkillCategoryDtos
{
    public class SkillCategoryDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
        public string Description { get; set; }
        public ICollection<SkillDto>? Skills { get; set; }
    }
}
