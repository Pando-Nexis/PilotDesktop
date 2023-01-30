using PilotDesktop.Work.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PilotDesktop.Work.Objects
{
    public class WorkItems
    {
        public List<WorkItem> List { get; set; } = new List<WorkItem>();
        public DateTime ListLoaded { get; set; }

        public List<WorkItem> SetList
        {
            set
            {
                List = value;
                ListLoaded = DateTime.Now;
            }
        }

    }
}
