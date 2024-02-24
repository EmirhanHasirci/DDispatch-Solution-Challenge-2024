using DisasterDispatch.Core.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisasterDispatch.Core.Entities
{
    public class Skill:BaseEntity
    {
        public Guid SkillCategoryId { get; set; }
        public SkillCategory SkillCategory{ get; set; }
        public AppUser AppUser{ get; set; }
        public string AppUserId{ get; set; }
        public string Name{ get; set; }        
        public string Description{ get; set; }
    }
}
