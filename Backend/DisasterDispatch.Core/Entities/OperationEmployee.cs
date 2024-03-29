﻿using DisasterDispatch.Core.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisasterDispatch.Core.Entities
{
    public class OperationEmployee:BaseEntity
    {
        public CustomOperation CustomOperation{ get; set; }
        public Guid CustomOperationId{ get; set; }
        public AppUser AppUser{ get; set; }
        public string AppUserId{ get; set; }
    }
}
