﻿using DisasterDispatch.Core.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisasterDispatch.Core.Entities
{
    public class Notification:BaseEntity
    {
        public string Title { get; set; }
        public string Context { get; set; }
        public Guid? DisasterOperationId { get; set; }
        public virtual DisasterOperation DisasterOperation { get; set; }
    }
}
