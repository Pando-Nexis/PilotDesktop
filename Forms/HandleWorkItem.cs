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
    public partial class HandleWorkItem : Form
    {
        private readonly WorkItemService _workItemService;
        private WorkItem _workItem;
        public HandleWorkItem(WorkItem workItem)
        {
            InitializeComponent();
            _workItemService = new WorkItemService();
            _workItem = workItem;

        }

        private async void bSave_Click(object sender, EventArgs e)
        {
            _workItem.ItemTitle = tbTitle.Text;
            _workItem.ItemDescription = rtbDescription.Text;
            _workItem.ItemTypeSystemId = itemTypeCtrl1.GetData()?.SystemId == null ? Guid.Empty : itemTypeCtrl1.GetData().SystemId;
            _workItem.OrganizationSystemId = customerAndProjectCtrl1.GetSelectedSystemId();

            var list = await _workItemService.AddOrUpdate(_workItem);
            if (list != null)
            {
                Program.WorkItems.List = list;
                _workItem = Program.WorkItems.List.FirstOrDefault(i => i.SystemId == _workItem.SystemId);
                estimatedTime1.SaveEstimate(_workItem.SystemId);
                SetData();
            }
        }
        private void SetData()
        {
            tbTitle.Text = _workItem.ItemTitle;
            rtbDescription.Text = _workItem.ItemDescription;
            customerAndProjectCtrl1.SetData(_workItem.OrganizationSystemId);
            itemTypeCtrl1.LoadItemTypes(_workItem.ItemTypeSystemId);
            Text = $"{_workItem.Id} - {tbTitle.Text}";
            
            estimatedTime1.SetData(_workItemService.GetEstimatedTime(_workItem.SystemId, ref Program.Times)); 
            workedTime1.SetData(_workItemService.GetWorkedTime(_workItem.SystemId, ref Program.Times));
        }
        private void HandleWorkItems_Load(object sender, EventArgs e)
        {
            SetData();
        }

        private void bNew_Click(object sender, EventArgs e)
        {
            var workItem =  new WorkItem();
            workItem.OrganizationSystemId = _workItem.OrganizationSystemId;
            workItem.ItemTypeSystemId = _workItem.ItemTypeSystemId;
            _workItem = workItem;
            SetData();
        }
    }
}
