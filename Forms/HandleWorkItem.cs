using PilotDesktop.Pilot.Objects;
using PilotDesktop.Pilot.Services;
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
        private readonly TimeService _timeService;
        private PilotCustomerService _pilotCustomerService = new PilotCustomerService();
        private WorkItem _workItem;

        public HandleWorkItem(WorkItem workItem)
        {
            InitializeComponent();
            _workItemService = new WorkItemService();
            _timeService = new TimeService();
            _workItem = workItem;

        }

        private async void bSave_Click(object sender, EventArgs e)
        {
            _workItem.ItemTitle = tbTitle.Text;
            _workItem.ItemDescription = rtbDescription.Text;
            _workItem.ItemTypeSystemId = itemTypeCtrl1.GetData()?.SystemId == null ? Guid.Empty : itemTypeCtrl1.GetData().SystemId;
            _workItem.ItemStatusSystemId = itemStatusCtrl1.GetData()?.SystemId == null ? Guid.Empty : itemStatusCtrl1.GetData().SystemId;
            _workItem.OrganizationSystemId = customerAndProjectCtrl1.GetSelectedSystemId();

            var list = await _workItemService.AddOrUpdate(_workItem);
            if (list != null)
            {
                Program.WorkItems.List = list;
                _workItem = Program.WorkItems.List.FirstOrDefault(i => i.SystemId == _workItem.SystemId);
                estimatedTime1.SaveEstimate(_workItem.SystemId);
                workedTime1.SaveHoursWorked(_workItem.SystemId);
                SetData();
            }
        }
        private void SetData()
        {
            tbTitle.Text = _workItem.ItemTitle;
            rtbDescription.Text = _workItem.ItemDescription;
            customerAndProjectCtrl1.SetData(_workItem.OrganizationSystemId);
            itemTypeCtrl1.LoadItemTypes(_workItem.ItemTypeSystemId);
            itemStatusCtrl1.LoadItemStatuses(_workItem.ItemStatusSystemId);
            Text = $"{_workItem.Id} - {tbTitle.Text}";

            estimatedTime1.SetData(_workItemService.GetEstimatedTime(_workItem.SystemId, ref Program.Times));
            workedTime1.SetData(_workItemService.GetWorkedTime(_workItem.SystemId, ref Program.Times));
            LoadChildTasks();
        }
        private void HandleWorkItems_Load(object sender, EventArgs e)
        {
            SetData();
        }

        private void bNew_Click(object sender, EventArgs e)
        {
            var workItem = new WorkItem();
            workItem.OrganizationSystemId = _workItem.OrganizationSystemId;
            workItem.ItemTypeSystemId = _workItem.ItemTypeSystemId;
            _workItem = workItem;
            SetData();
        }

        private void bAddSubActivities_Click(object sender, EventArgs e)
        {
            var workItem = new WorkItem();
            workItem.ItemTypeSystemId = Program.ItemTypes?.FirstOrDefault(i => i.Name == "Task")?.SystemId ?? Guid.Empty;
            workItem.ItemStatusSystemId = Program.ItemStatuses?.FirstOrDefault(i => i.Name == "Ny")?.SystemId ?? Guid.Empty;
            workItem.OrganizationSystemId = _workItem.OrganizationSystemId;
            workItem.ParentSystemId = _workItem.SystemId;

            var dlg = new QuickAddTask(workItem);
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                LoadChildTasks();
            }

        }

        private void LoadChildTasks()
        {

            lvItems.Items.Clear();
            lvItems.Columns.Clear();
            var children = Program.WorkItems.List.Where(i => i.ParentSystemId == _workItem.SystemId).ToList();

            lvItems.Columns.Add("id", 100);
            lvItems.Columns.Add("Titel", 300);
            lvItems.Columns.Add("typ", 100);
            lvItems.Columns.Add("status", 100);

            lvItems.Columns.Add("Estimat", 100);
            lvItems.Columns.Add("Estimat med risk", 100);
            lvItems.Columns.Add("Totalt nedlagd tid", 100);

            foreach (var child in children)
            {

                var listViewItem = new ListViewItem(child.Id);
                listViewItem.Tag = child.SystemId;
                listViewItem.SubItems.Add(child.ItemTitle);
                listViewItem.SubItems.Add(Program.ItemTypes.FirstOrDefault(i => i.SystemId == child.ItemTypeSystemId)?.Name ?? string.Empty);
                listViewItem.SubItems.Add(Program.ItemStatuses.FirstOrDefault(i => i.SystemId == child.ItemStatusSystemId)?.Name ?? string.Empty);

                var timeEstimate = _workItemService.GetEstimatedTime(child.SystemId, ref Program.Times);
                var estimate = _timeService.GetHours(timeEstimate.Amount);
                var risk = timeEstimate.Risk * estimate;

                var workedTime = _timeService.GetHours(_workItemService.GetSumWorkedTime(child.SystemId, ref Program.Times));

                listViewItem.SubItems.Add(estimate.ToString("0.##"));
                listViewItem.SubItems.Add(risk.ToString("0.##"));
                listViewItem.SubItems.Add(workedTime.ToString("0.##"));

                lvItems.Items.Add(listViewItem);
            }

        }

        private void tabCtrl_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (tabCtrl.SelectedTab.Name)
            {
                case "tabWorkTime":
                    LoadWorkTime();
                    break;
                case "tabInvoices":
                    LoadInvoices();
                    break;
            };
        }
        private void LoadInvoices()
        {
            var times = _workItemService.GetInvoicedTime(_workItem.SystemId, ref Program.Times);

            lvInvoice.Items.Clear();
            lvInvoice.Columns.Clear();
            lvInvoice.Columns.Add("TimeFrom", 100);
            lvInvoice.Columns.Add("TimeTo", 100);
            lvInvoice.Columns.Add("Hours", 100);
            lvInvoice.Columns.Add("Kommentar", 100);
            lvInvoice.Columns.Add("Status", 100);


            foreach (var t in times)
            {
                var time = new ListViewItem(t.TimeFrom.ToShortDateString());
                time.Tag = t.TimeComment;
                time.SubItems.Add(t.TimeTo.ToShortDateString());
                time.SubItems.Add(_timeService.GetHours(t.Amount).ToString("0.##"));
                time.SubItems.Add(t.TimeComment);
                time.SubItems.Add(Program.TimeStatuses.FirstOrDefault(i => i.SystemId == t.TimeStatusSystemId)?.Name ?? string.Empty);

                lvInvoice.Items.Add(time);

            }
        }

        private void LoadWorkTime()
        {
            var times = _workItemService.GetWorkedTime(_workItem.SystemId, ref Program.Times);

            lvWorkTime.Items.Clear();
            lvWorkTime.Columns.Clear();
            lvWorkTime.Columns.Add("TimeFrom", 100);
            lvWorkTime.Columns.Add("TimeTo", 100);
            lvWorkTime.Columns.Add("Hours", 100);
            lvWorkTime.Columns.Add("Kommentar", 100);
            lvWorkTime.Columns.Add("Status", 100);


            foreach (var t in times)
            {
                var time = new ListViewItem(t.TimeFrom.ToShortDateString());
                time.Tag = t.SystemId;
                time.SubItems.Add(t.TimeTo.ToShortDateString());
                time.SubItems.Add(_timeService.GetHours(t.Amount).ToString("0.##"));
                time.SubItems.Add(t.TimeComment);
                time.SubItems.Add(Program.TimeStatuses.FirstOrDefault(i => i.SystemId == t.TimeStatusSystemId)?.Name ?? string.Empty);

                lvWorkTime.Items.Add(time);

            }
        }

        private void lvInvoice_DoubleClick(object sender, EventArgs e)
        {
            if (lvInvoice.SelectedItems != null && lvInvoice.SelectedItems.Count > 0)
            {
                var invoice = lvInvoice.SelectedItems[0].Tag?.ToString();
                PilotCustomer customer;
                PilotProject project;
                _pilotCustomerService.GetCustomerAndProject(Program.Customers, _workItem.OrganizationSystemId, out customer, out project);

                if (customer != null&&!string.IsNullOrEmpty(invoice))
                {
                    var dlg = new ViewInvoice(customer, invoice);
                    dlg.ShowDialog();
                    LoadInvoices();

                }

            }
        }

        private void lvItems_DoubleClick(object sender, EventArgs e)
        {
            if (lvItems.SelectedItems != null && lvItems.SelectedItems.Count > 0)
            {
                var itemId = (Guid)lvItems.SelectedItems[0].Tag;
                var item = Program.WorkItems.List.FirstOrDefault(i => i.SystemId == itemId);

                if (item != null)
                {
                    var dlg = new HandleWorkItem(item);
                    dlg.ShowDialog();
                    LoadChildTasks();

                }

            }
        }

        private void bAddTime_Click(object sender, EventArgs e)
        {
            var time = new Time()
            {
                ItemSystemId = _workItem.SystemId,
                TimeTypeSystemId = Program.TimeTypes.FirstOrDefault(i => i.Name == "Worked").SystemId,
                TimeStatusSystemId  = Program.TimeStatuses.FirstOrDefault(i => i.Name == "New").SystemId
            };
            
            var dlg = new HandleWorkTime(time);
            dlg.ShowDialog();
            LoadWorkTime();

        }

        private void lvWorkTime_DoubleClick(object sender, EventArgs e)
        {
            if (lvWorkTime.SelectedItems != null && lvWorkTime.SelectedItems.Count > 0)
            {
                var itemId = (Guid)lvWorkTime.SelectedItems[0].Tag;
                var item = Program.Times.FirstOrDefault(i => i.SystemId == itemId);

                if (item != null)
                {
                    var dlg = new HandleWorkTime(item);
                    dlg.ShowDialog();
                    LoadWorkTime();

                }

            }
        }

        private void lvInvoice_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lvWorkTime_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}

