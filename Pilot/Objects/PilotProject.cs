﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PilotDesktop.Pilot.Objects
{
    public class PilotProject
    {
        public Guid SystemId { get; set; }
        public string Name { get; set; }
        public string ProjectType { get; set; }
        public List<string> AddOns { get; set; }

    }
}
