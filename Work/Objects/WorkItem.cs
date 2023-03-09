
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PilotDesktop.Work.Objects
{
    public class WorkItem
    {
        public Guid SystemId { get; set; } = Guid.NewGuid();
        public Guid OrganizationSystemId { get; set; }
        public Guid ParentSystemId { get; set; }
        public Guid ItemTypeSystemId { get; set; } =  Program.ItemTypes?.FirstOrDefault(i => i.Name == "Task")?.SystemId ?? Guid.Empty;
        public Guid ItemStatusSystemId { get; set; } = Program.ItemStatuses?.FirstOrDefault(i => i.Name == "Ny")?.SystemId ?? Guid.Empty;
        public string Id { get; set; }
        public string ItemTitle { get; set; }
        public string ItemDescription { get; set; }
        public DateTime DueDateTime { get; set; } = DateTime.Parse("1900-01-01 00:00");
        public DateTime CreatedDateTime { get; set; } = DateTime.Now;
        public Guid CreatedBy { get; set; }
        public DateTime UpdatedDateTime { get; set; } = DateTime.Now;
        public Guid UpdatedBy { get; set; }
        public DateTime DeletedDateTime { get; set; } = DateTime.Parse("1900-01-01 00:00");
        public Guid DeletedBy { get; set; }
      
    }
}
