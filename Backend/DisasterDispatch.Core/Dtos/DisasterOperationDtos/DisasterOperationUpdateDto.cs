﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisasterDispatch.Core.Dtos.DisasterOperationDtos
{
    public class DisasterOperationUpdateDto
    {
        public Guid Id { get; set; }
        public Guid DisasterCategoryId { get; set; }
        public string ProvinceId { get; set; }
        public string AssignerId { get; set; }
    }
}
