﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PilotDesktop.Work.Objects
{
    public class TimeStatus
    {
        public Guid SystemId { get; set; }
        public Guid TimeTypeSystemId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
