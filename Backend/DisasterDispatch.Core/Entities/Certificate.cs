﻿using DisasterDispatch.Core.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisasterDispatch.Core.Entities
{
    public class Certificate:BaseEntity
    {
        public string Proof{ get; set; }
        public DateTime ReceivedDate{ get; set; }
        public AppUser AppUser { get; set; }
        public string AppUserId { get; set; }
        public DateTime? ExpiryDate{ get; set; }
    }
}
