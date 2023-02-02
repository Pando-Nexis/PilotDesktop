using PilotDesktop.UserControls;
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
    public partial class QuickAddTask : Form
    {
        private WorkItem _workItem;
        private readonly WorkItemService _workItemService;
        public QuickAddTask(WorkItem workItem)
        {
            InitializeComponent();
            _workItemService = new WorkItemService();
            _workItem = workItem;
            SetData();
        }
        private void SetData()
        {
            tbTitle.Text = _workItem.ItemTitle;
            itemTypeCtrl1.LoadItemTypes(_workItem.ItemTypeSystemId);
            itemStatusCtrl1.LoadItemStatuses(_workItem.ItemStatusSystemId);
            if (_workItem.ParentSystemId != null && _workItem.ParentSystemId != Guid.Empty)
            {
                var parent = Program.WorkItems.List.FirstOrDefault(i => i.SystemId == _workItem.ParentSystemId);
                if (parent != null)
                {
                    Text = $"Lägg till delaktivitet för {parent.Id} {parent.ItemTitle}";
                }
            }
        }

        private async void bSave_Click(object sender, EventArgs e)
        {
            _workItem.ItemTitle = tbTitle.Text;
            _workItem.ItemTypeSystemId = itemTypeCtrl1.GetData()?.SystemId == null ? Guid.Empty : itemTypeCtrl1.GetData().SystemId;
            _workItem.ItemStatusSystemId = itemStatusCtrl1.GetData()?.SystemId == null ? Guid.Empty : itemStatusCtrl1.GetData().SystemId;

            var list = await _workItemService.AddOrUpdate(_workItem);
            if (list != null)
            {
                Program.WorkItems.List = list;
            }
            DialogResult = DialogResult.OK;
            Close();

        }
    }
}
