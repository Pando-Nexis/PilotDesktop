using PilotDesktop.Work.Objects;
using PilotDesktop.Work.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PilotDesktop.Forms
{
    public partial class WorkItems : Form
    {
        private WorkItemService _workItemService = new WorkItemService();
        private TimeService _timeService= new TimeService();
        
        public WorkItems()
        {
            InitializeComponent();
        }

        private void WorkItems_Load(object sender, EventArgs e)
        {
            LoadItems();
        }

        private void LoadItems()
        {
            lvItems.Items.Clear();
            lvItems.Columns.Clear();
            lvItems.Columns.Add("id");
            lvItems.Columns.Add("Titel");
            lvItems.Columns.Add("typ");
            lvItems.Columns.Add("status");
            lvItems.Columns.Add("Estimat");
            lvItems.Columns.Add("Estimat med risk");
            lvItems.Columns.Add("Nedlagd tid");


            foreach (var item in Program.WorkItems.List)
            {

                var test = new ListViewItem(item.Id);
                test.Tag = item.SystemId;
                test.SubItems.Add(item.ItemTitle);
                test.SubItems.Add(Program.ItemTypes.FirstOrDefault(i => i.SystemId == item.ItemTypeSystemId)?.Name ?? string.Empty);
                test.SubItems.Add(Program.ItemStatuses.FirstOrDefault(i => i.SystemId == item.ItemStatusSystemId)?.Name ?? string.Empty);
                var timeEstimate = _workItemService.GetEstimatedTime(item.SystemId, ref Program.Times);
       
                    var estimate =  _timeService.GetHours(timeEstimate.Amount);
                    var risk = timeEstimate.Risk * estimate;

                    test.SubItems.Add(estimate.ToString("0.##"));

                    test.SubItems.Add(risk.ToString("0.##"));
               
                var workedTime = _timeService.GetHours( _workItemService.GetSumWorkedTime(item.SystemId, ref Program.Times));

                test.SubItems.Add(workedTime.ToString("0.##"));
                lvItems.Items.Add(test);
            }
        }

        private void lvItems_SelectedIndexChanged(object sender, EventArgs e)
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
            var dlg = new HandleWorkItem(new WorkItem());
            dlg.ShowDialog();
        }
    }
}
