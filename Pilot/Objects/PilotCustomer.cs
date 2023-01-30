using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PilotDesktop.Pilot.Objects
{
    public class PilotCustomer
    {
        public Guid SystemId { get; set; }
        public string Name { get; set; }
        public string WorkItemPrefix { get; set; }
        public List<PilotProject> Projects { get; set; }

        public override string ToString() => Name;
    }
}
