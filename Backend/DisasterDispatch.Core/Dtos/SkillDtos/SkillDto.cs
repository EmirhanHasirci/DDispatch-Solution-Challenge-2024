using DisasterDispatch.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisasterDispatch.Core.Dtos.SkillDtos
{
    public class SkillDto
    {
        public Guid Id { get; set; }
        public string AppUserId { get; set; }        
        public string Name { get; set; }      
        public string Description { get; set; }
        public Guid SkillCategoryId { get; set; }          
    }
}
