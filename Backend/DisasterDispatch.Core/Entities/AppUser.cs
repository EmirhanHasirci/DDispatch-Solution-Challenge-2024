using DisasterDispatch.Core.Enums;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisasterDispatch.Core.Entities
{
    public class AppUser : IdentityUser
    {
        public string Tc { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string? Picture { get; set; }
        public DateTime? BirthDate { get; set; }
        public string? City { get; set; }
        public string? Gender { get; set; }
        public bool? IsDeleted{ get; set; }
        public string? CurrentStatus{ get; set; }
        public ICollection<PhoneNumber>? PhoneNumbers { get; set; }
        public ICollection<Address>? Addresses{ get; set; }
        public ICollection<Title>? Titles{ get; set; }
        public ICollection<CustomOperation>? Operations { get; set; }
    }
}
