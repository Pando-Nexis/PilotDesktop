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
    public partial class WorkTimeCalender : Form
    {
        private WorkItemService _workItemService = new WorkItemService();
        private TimeService _timeService = new TimeService();
        private PilotCustomerService _pilotCustomerService = new PilotCustomerService();
        private PilotCustomer _selectedCustomer;
        public WorkTimeCalender()
        {
            InitializeComponent();
        }

        private void WorkTimeCalender_Load(object sender, EventArgs e)
        {
            var date = DateTime.Today;

            while (date.DayOfWeek != DayOfWeek.Monday)
            {
                date = date.AddDays(-1);
            }
            dtpFrom.Value = date;
            dtpTo.Value = dtpFrom.Value.AddDays(7);
            LoadData();
        }
        private void LoadData()
        {
            dataGridView1.DataSource = null;
            var timeFrom = dtpFrom.Value;
            var timeTo = dtpTo.Value;



            var dates = new Dictionary<DateTime, int>();
            var dtDay = timeFrom;

            var worktime = _timeService.GetWorkTime(timeFrom, timeTo);
            var organizationSystemId = customerAndProjectCtrl1.GetSelectedSystemId();
            if (organizationSystemId != Guid.Empty)
            {
                _pilotCustomerService.GetCustomerAndProject(Program.Customers, organizationSystemId, out var customer, out var project);

                if (project != null)
                {
                    worktime = _timeService.WorkTimeForProject(worktime, project);
                }
                else if (customer != null)
                {
                    worktime = _timeService.WorkTimeForCustomer(worktime, customer, true);
                }
            }

            var index = 0;
            var dtData = new DataTable();
            var colData = new DataColumn();

            colData = new DataColumn();
            colData.ColumnName = "Kund/Projekt";
            dtData.Columns.Add(colData);
            index++;

            colData = new DataColumn();
            colData.ColumnName = "Id";
            dtData.Columns.Add(colData);
            index++;

            colData = new DataColumn();
            colData.ColumnName = "Titel";
            dtData.Columns.Add(colData);
            index++;

            colData = new DataColumn();
            colData.ColumnName = "Hours";
            dtData.Columns.Add(colData);
            index++;

            while (dtDay <= timeTo)
            {
                dates.Add(dtDay, index);

                colData = new DataColumn();
                colData.ColumnName = dtDay.ToShortDateString();
                dtData.Columns.Add(colData);

                index++;
                dtDay = dtDay.AddDays(1);

            }

            var items = worktime.GroupBy(i => i.ItemSystemId);
            var sums = new Dictionary<int, decimal>();
            foreach (var item in items)
            {
                var workItem = Program.WorkItems.List.FirstOrDefault(i => i.SystemId == item.Key);
                _pilotCustomerService.GetCustomerAndProject(workItem, out PilotCustomer customer, out PilotProject project);
                var rowData = dtData.NewRow();

                rowData[0] = project?.Name == null ? customer.Name : customer.Name + "-" + project.Name;
                rowData[1] = workItem.Id;
                rowData[2] = workItem.ItemTitle;
                var periodHours = _timeService.GetHours(item.Sum(i => i.Amount));
                rowData[3] = periodHours;
                if (sums.ContainsKey(3))
                {
                    sums[3] += periodHours;
                }
                else
                {
                    sums.Add(3, periodHours);
                }

                foreach (var day in dates)
                {
                    var hours = _timeService.GetWorkTimeSum(workItem.SystemId, day.Key, day.Key);
                    rowData[day.Value] = hours;

                    if (sums.ContainsKey(day.Value))
                    {
                        sums[day.Value] += hours;
                    }
                    else
                    {
                        sums.Add(day.Value, hours);
                    }

                }
                dtData.Rows.Add(rowData);
            }
            var rowSums = dtData.NewRow();

            rowSums[0] = "Totalt";

            foreach (var sum in sums)
            {
                rowSums[sum.Key] = sum.Value;
            }

            dtData.Rows.Add(rowSums);

            dataGridView1.DataSource = dtData;

        }

        private void dtpFrom_ValueChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        private void dtpTo_ValueChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        private void customerAndProjectCtrl1_OnIndexChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        private void bRefresh_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void bOpen_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tbOpenWorkItem.Text))
            {
                var workItem = Program.WorkItems.List.FirstOrDefault(i => i.Id == tbOpenWorkItem.Text);
                if (workItem != null)
                {
                    var frm = new HandleWorkItem(workItem);
                    frm.ShowDialog();
                }
            }
        }
    }
}
