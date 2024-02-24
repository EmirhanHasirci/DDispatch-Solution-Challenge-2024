using DisasterDispatch.Core.Dtos.AppUserDtos;
using DisasterDispatch.Core.Dtos.SkillCategoryDtos;
using DisasterDispatch.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisasterDispatch.Core.Dtos.SkillDtos
{
    public class SkillWithUsersDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public SkillCategoryDto SkillCategory{ get; set; }        
        public AppUserDto AppUser { get; set; }
    }
}
