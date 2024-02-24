using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisasterDispatch.Core.Dtos.AppUserDtos
{
    public class AppUserEditDto
    {                        
        public string Name { get; set; }
        public string Surname { get; set; }
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public string? Picture { get; set; }
        public string? Gender { get; set; }
        public DateTime? BirthDate { get; set; }
        public string? City { get; set; }
    }
}
