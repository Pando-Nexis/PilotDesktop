using PilotDesktop.Pilot.Objects;
using PilotDesktop.Pilot.Services;
using PilotDesktop.Work.Objects;
using PilotDesktop.Work.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Contracts;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;

namespace PilotDesktop.Forms
{
    public partial class WorkItems : Form
    {
        private WorkItemService _workItemService = new WorkItemService();
        private TimeService _timeService= new TimeService();
        private PilotCustomerService _pilotCustomerService = new PilotCustomerService();
        private string _query = string.Empty;
        private Guid _systemId= Guid.Empty;
        
        public WorkItems(string query, Guid systemId)
        {
            InitializeComponent();
            _query = query;
            _systemId = systemId;
        }

        private void WorkItems_Load(object sender, EventArgs e)
        {
            LoadItems();
        }

        private void LoadItems()
        {
            lvItems.Items.Clear();
            lvItems.Columns.Clear();
            lvItems.Columns.Add("Kund", 100);
            lvItems.Columns.Add("Project", 100);
            lvItems.Columns.Add("id", 100);
            lvItems.Columns.Add("Titel", 300);
            lvItems.Columns.Add("typ", 100);
            lvItems.Columns.Add("status", 100);
            lvItems.Columns.Add("Estimat", 100);
            lvItems.Columns.Add("Estimat med risk", 100);
            lvItems.Columns.Add("Nedlagd tid", 100);

            var workItems = new List<WorkItem>();
            switch (_query)
            {
                case "CustomerSystemId":
                    var customer = Program.Customers.FirstOrDefault(i=>i.SystemId == _systemId);

                    workItems = Program.WorkItems.List.Where(i => i.OrganizationSystemId == customer.SystemId).ToList();
                    foreach(var project in customer.Projects)
                    {
                        workItems.AddRange(Program.WorkItems.List.Where(i => i.OrganizationSystemId == project.SystemId).ToList());
                    }
                    Text = "Aktiviteter för " + customer.Name;
                    break;
                case "ProjectSystemId":
                    foreach(var cust in Program.Customers)
                    {
                        foreach(var project in cust.Projects)
                        {
                            if (project.SystemId == _systemId)
                            {
                                Text = "Aktiviteter för " + cust.Name + ": " + project.Name;
                                workItems.AddRange(Program.WorkItems.List.Where(i => i.OrganizationSystemId == project.SystemId).ToList());
                            }
                        }
                    }
                    
                    break;
                default:
                    workItems = Program.WorkItems.List;
                        break;

            }

            foreach (var item in workItems.OrderBy(i=>i.Id))
            {
                PilotCustomer customer;
                PilotProject project;
                _pilotCustomerService.GetCustomerAndProject(Program.Customers, item.OrganizationSystemId, out customer, out project);
                var listViewItem = new ListViewItem(customer?.Name ?? string.Empty);
                listViewItem.Tag = item.SystemId;

                listViewItem.SubItems.Add(project?.Name ?? string.Empty);

                listViewItem.SubItems.Add(item.Id);
                listViewItem.SubItems.Add(item.ItemTitle);
                listViewItem.SubItems.Add(Program.ItemTypes.FirstOrDefault(i => i.SystemId == item.ItemTypeSystemId)?.Name ?? string.Empty);
                listViewItem.SubItems.Add(Program.ItemStatuses.FirstOrDefault(i => i.SystemId == item.ItemStatusSystemId)?.Name ?? string.Empty);
                var timeEstimate = _workItemService.GetEstimatedTime(item.SystemId, ref Program.Times);
       
                    var estimate =  _timeService.GetHours(timeEstimate.Amount);
                    var risk = timeEstimate.Risk * estimate;

                    listViewItem.SubItems.Add(estimate.ToString("0.##"));

                    listViewItem.SubItems.Add(risk.ToString("0.##"));
               
                var workedTime = _timeService.GetHours( _workItemService.GetSumWorkedTime(item.SystemId, ref Program.Times));

                listViewItem.SubItems.Add(workedTime.ToString("0.##"));
                lvItems.Items.Add(listViewItem);
            }
        }

        private void lvItems_DoubleClick(object sender, EventArgs e)
        {
            if (lvItems.SelectedItems != null && lvItems.SelectedItems.Count > 0)
            {
                var item = (Guid)lvItems.SelectedItems[0].Tag;
                var workItem = Program.WorkItems.List.FirstOrDefault(i => i.SystemId == item);

                if (workItem != null)
                {
                    var dlg = new HandleWorkItem(workItem);
                    dlg.ShowDialog();
                    LoadItems();

                }

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var workitem = new WorkItem();
            switch (_query)
            {
                case "CustomerSystemId":
                case "ProjectSystemId":
                    workitem.OrganizationSystemId = _systemId; 
                    break;
            }

            var dlg = new HandleWorkItem(workitem);
            dlg.ShowDialog();
            LoadItems();
        }

        private void lvItems_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
