﻿using CarSenegalBakend.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSenegalBakend.Domain.Entities
{
    public class PlatformEntity : EntityBase
    {
        public string Name { get; set; }
        public decimal DefaultCommissionRate { get; set; }
    }
}
