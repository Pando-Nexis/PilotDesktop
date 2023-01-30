using PilotDesktop.Work.Objects;
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
        public WorkItems()
        {
            InitializeComponent();
        }

        private void WorkItems_Load(object sender, EventArgs e)
        {

            lvItems.Columns.Add("id");
            lvItems.Columns.Add("Titel");
            lvItems.Columns.Add("typ");
            foreach (var item in Program.WorkItems.List)
            {

                var test = new ListViewItem(item.Id);
                test.Tag = item.SystemId;
                test.SubItems.Add(item.ItemTitle);
                test.SubItems.Add(Program.ItemTypes.FirstOrDefault(i => i.SystemId == item.ItemTypeSystemId)?.Name ?? string.Empty); 

                lvItems.Items.Add(test);
            }
        }

        private void lvItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvItems.SelectedItems!=null&& lvItems.SelectedItems.Count>0)
            {
                var item =(Guid) lvItems.SelectedItems[0].Tag;
                var workItem = Program.WorkItems.List.FirstOrDefault(i => i.SystemId == item);

                if (workItem != null)
                {
                    var dlg = new HandleWorkItem(workItem);
                    dlg.ShowDialog();
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
