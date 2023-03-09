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
    public partial class HandleInvoicing : Form
    {
        private WorkItemService _workItemService = new WorkItemService();
        private TimeService _timeService = new TimeService();
        private PilotCustomerService _pilotCustomerService = new PilotCustomerService();
        private PilotCustomer selectedCustomer;
        public HandleInvoicing()
        {
            InitializeComponent();
        }

        private void HandleInvoicing_Load(object sender, EventArgs e)
        {
            SetInitialData();
            LoadData();
        }

        private void SetInitialData()
        {
            var datefrom = DateTime.Now;
            if (datefrom.Day > 15)
            {
                datefrom = datefrom.AddDays(-datefrom.Day + 1);
            }
            else
            {
                datefrom = datefrom.AddDays(-datefrom.Day + 1).AddMonths(-1);
            }
            datefrom = DateTime.Parse(datefrom.ToShortDateString() + " 00:00");
            var dateto = datefrom.AddMonths(1).AddMinutes(-1);

            dtpFrom.Value = datefrom;
            dtpTo.Value = dateto;

        }
        private void LoadData()
        {
            var workItems = _workItemService.GetWorkItemsForTimePeriod(dtpFrom.Value, dtpTo.Value);

            if (selectedCustomer!=null)
            {
                var workItemsForSelected = workItems.Where(i => i.OrganizationSystemId == selectedCustomer.SystemId).ToList();
                foreach(var project in selectedCustomer.Projects)
                {
                    workItemsForSelected.AddRange(workItems.Where(i => i.OrganizationSystemId == project.SystemId).ToList());
                }

                workItems = workItemsForSelected;
            }

            lvItems.Items.Clear();
            lvItems.Columns.Clear();
            lvItems.Columns.Add("id", 100);

            lvItems.Columns.Add("Projekt", 100);

            lvItems.Columns.Add("Titel", 300);
            lvItems.Columns.Add("typ", 100);
            lvItems.Columns.Add("status", 100);
            lvItems.Columns.Add("Estimat", 100);
            lvItems.Columns.Add("Estimat med risk", 100);
            lvItems.Columns.Add("Totalt nedlagd tid", 100);
            lvItems.Columns.Add("I tidsperioden nedlagd tid", 100);
            lvItems.Columns.Add("Fakturerad nedlagd tid", 100);

            var sumEstimate = decimal.Zero;
            var sumEstimateWithRisk = decimal.Zero;
            var sumWorkedHours = decimal.Zero;
            var sumWorkHoursThisPeriod = decimal.Zero;
            var sumInvoicePeriodTime = decimal.Zero;

            foreach (var item in workItems)
            {

                var listViewItem = new ListViewItem(item.Id);
                listViewItem.Tag = item.SystemId;
                PilotCustomer customer;
                PilotProject project;
                _pilotCustomerService.GetCustomerAndProject(Program.Customers, item.OrganizationSystemId, out customer, out project);
                
                listViewItem.SubItems.Add(project?.Name??string.Empty);
                listViewItem.SubItems.Add(item.ItemTitle);
                listViewItem.SubItems.Add(Program.ItemTypes.FirstOrDefault(i => i.SystemId == item.ItemTypeSystemId)?.Name ?? string.Empty);
                listViewItem.SubItems.Add(Program.ItemStatuses.FirstOrDefault(i => i.SystemId == item.ItemStatusSystemId)?.Name ?? string.Empty);
                var timeEstimate = _workItemService.GetEstimatedTime(item.SystemId, ref Program.Times);

                var estimate = _timeService.GetHours(timeEstimate.Amount);
                sumEstimate += estimate;
                var risk = timeEstimate.Risk * estimate;
                sumEstimateWithRisk += risk;
                listViewItem.SubItems.Add(estimate.ToString("0.##"));
                listViewItem.SubItems.Add(risk.ToString("0.##"));

                var workedTime = _timeService.GetHours(_workItemService.GetSumWorkedTime(item.SystemId, ref Program.Times));
                sumWorkedHours += workedTime;
                listViewItem.SubItems.Add(workedTime.ToString("0.##"));
                var periodTime = _timeService.GetHours(_workItemService.GetSumWorkedTime(item.SystemId, ref Program.Times, dtpFrom.Value, dtpTo.Value));
                sumWorkHoursThisPeriod +=periodTime;
                listViewItem.SubItems.Add(periodTime.ToString("0.##"));

                var invoicePeriodTime = _timeService.GetHours(_workItemService.GetSumWorkedTimeInvoiced(item.SystemId, ref Program.Times, dtpFrom.Value, dtpTo.Value));
                sumInvoicePeriodTime += invoicePeriodTime;
                listViewItem.SubItems.Add(invoicePeriodTime.ToString("0.##"));
               

                lvItems.Items.Add(listViewItem);
            }
            var listViewItemTotal = new ListViewItem("Total");
            listViewItemTotal.BackColor = Color.LightGray;

            listViewItemTotal.SubItems.Add("");
            listViewItemTotal.SubItems.Add("");
            listViewItemTotal.SubItems.Add("");
            listViewItemTotal.SubItems.Add("");

            listViewItemTotal.SubItems.Add(sumEstimate.ToString("0.##"));
            listViewItemTotal.SubItems.Add(sumEstimateWithRisk.ToString("0.##"));

            listViewItemTotal.SubItems.Add(sumWorkedHours.ToString("0.##"));
            listViewItemTotal.SubItems.Add(sumWorkHoursThisPeriod.ToString("0.##"));
            listViewItemTotal.SubItems.Add(sumInvoicePeriodTime.ToString("0.##"));
            lvItems.Items.Add(listViewItemTotal);
        
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
                    LoadData();

                }

            }
        }

        private void customerAndProjectCtrl1_Load(object sender, EventArgs e)
        {

        }

        private void customerCtrl1_OnIndexChanged(object sender, EventArgs e)
        {
            selectedCustomer = customerCtrl1.GetData();
            LoadData();
        }

        private void bInvoice_Click(object sender, EventArgs e)
        {
            var rows = lvItems.SelectedItems;
            foreach(ListViewItem row in rows )
            {
                if (Guid.TryParse(row.Tag?.ToString(), out Guid workItemSystemId))
                {
                    var workItem = Program.WorkItems.List.FirstOrDefault(i => i.SystemId == workItemSystemId);
                    if (workItem != null)
                    {
                        var invoicedAmount = 0;
                        foreach(var time in Program.Times.Where(i => i.ItemSystemId==workItem.SystemId))
                        {
                            if (_timeService.IsValidForInvoicing(dtpFrom.Value, dtpTo.Value, time))
                            {
                                invoicedAmount += time.Amount;
                                _timeService.Invoice(time);
                            }
                        }
                        var invoiceTime = new Time();
                        invoiceTime.SystemId = Guid.NewGuid();
                        invoiceTime.TimeFrom = dtpFrom.Value;
                        invoiceTime.TimeTo = dtpTo.Value;
                        invoiceTime.TimeTypeSystemId = Program.TimeTypes.FirstOrDefault(i => i.Name == "Invoice").SystemId;
                        invoiceTime.Amount = invoicedAmount;
                        invoiceTime.TimeComment = "InvoiceDate: "+ dtpTo.Value.ToShortDateString();
                        invoiceTime.ItemSystemId = workItemSystemId;
                        PilotCustomer customer;
                        PilotProject project;
                        _pilotCustomerService.GetCustomerAndProject(Program.Customers, workItem.OrganizationSystemId, out customer, out project);
                        invoiceTime.OrganizationSystemId = customer.SystemId;

                        _timeService.AddOrUpdate(invoiceTime);
                    }

                }
            }
            LoadData();
        }
    }
}
