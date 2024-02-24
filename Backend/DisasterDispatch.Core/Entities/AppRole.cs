using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisasterDispatch.Core.Entities
{
    public class AppRole:IdentityRole
    {
        public string Color{ get; set; }
    }
}
