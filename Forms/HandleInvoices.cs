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
    public partial class HandleInvoices : Form
    {
        private WorkItemService _workItemService = new WorkItemService();
        private TimeService _timeService = new TimeService();
        private PilotCustomerService _pilotCustomerService = new PilotCustomerService();
        private PilotCustomer selectedCustomer;
        private Guid _invoiceSystemId = Program.TimeTypes.FirstOrDefault(i => i.Name == "Invoice")?.SystemId == null ? Guid.Empty : Program.TimeTypes.FirstOrDefault(i => i.Name == "Invoice").SystemId;
        public HandleInvoices()
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
            var times = Program.Times.Where(i => i.TimeTypeSystemId == _invoiceSystemId).ToList();


            if (selectedCustomer != null)
            {
                var timesForSelected = times.Where(i => i.OrganizationSystemId == selectedCustomer.SystemId).ToList();

                times = timesForSelected;
            }

            var timesGroup = times.GroupBy(g => new { g.OrganizationSystemId, g.TimeComment })
                                  .Select(group => new { inv = group.Key, total = _timeService.GetHours(group.Sum(t => t.Amount)) })
                                  .OrderByDescending(i => i.inv.TimeComment);


            lvInvoice.Items.Clear();
            lvInvoice.Columns.Clear();
            lvInvoice.Columns.Add("Kund", 100);
            lvInvoice.Columns.Add("Faktura", 100);
            lvInvoice.Columns.Add("Timmar", 100);



            //var sumEstimate = decimal.Zero;
            //var sumEstimateWithRisk = decimal.Zero;
            //var sumWorkedHours = decimal.Zero;
            //var sumWorkHoursThisPeriod = decimal.Zero;
            //var sumInvoicePeriodTime = decimal.Zero;

            foreach (var item in timesGroup)
            {
                PilotCustomer customer;
                PilotProject project;
                _pilotCustomerService.GetCustomerAndProject(Program.Customers, item.inv.OrganizationSystemId, out customer, out project);
                var listViewItem = new ListViewItem(customer.Name);
                listViewItem.Tag = item.inv.OrganizationSystemId;
                listViewItem.SubItems.Add(item.inv.TimeComment);
                listViewItem.SubItems.Add(item.total.ToString("0.##"));


                lvInvoice.Items.Add(listViewItem);


            }
            //var listViewItemTotal = new ListViewItem("Total");
            //listViewItemTotal.BackColor = Color.LightGray;

            //listViewItemTotal.SubItems.Add("");
            //listViewItemTotal.SubItems.Add("");
            //listViewItemTotal.SubItems.Add("");
            //listViewItemTotal.SubItems.Add("");

            //listViewItemTotal.SubItems.Add(sumEstimate.ToString("0.##"));
            //listViewItemTotal.SubItems.Add(sumEstimateWithRisk.ToString("0.##"));

            //listViewItemTotal.SubItems.Add(sumWorkedHours.ToString("0.##"));
            //listViewItemTotal.SubItems.Add(sumWorkHoursThisPeriod.ToString("0.##"));
            //listViewItemTotal.SubItems.Add(sumInvoicePeriodTime.ToString("0.##"));
            //lvItems.Items.Add(listViewItemTotal);

        }



        private void lvItems_DoubleClick(object sender, EventArgs e)
        {

            if (lvInvoice.SelectedItems != null && lvInvoice.SelectedItems.Count > 0)
            {
                var tag = lvInvoice.SelectedItems[0].Tag;
                if (Guid.TryParse(tag.ToString(), out Guid organizationSystemId))
                {
                    PilotCustomer customer;
                    PilotProject project;
                    _pilotCustomerService.GetCustomerAndProject(Program.Customers, organizationSystemId, out customer, out project);
                    var invoice = lvInvoice.SelectedItems[0].SubItems[1].Text;

                    if (customer != null && !string.IsNullOrEmpty(invoice))
                    {
                        var dlg = new ViewInvoice(customer, invoice);
                        dlg.ShowDialog();
                        LoadData();
                    }
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
            var rows = lvInvoice.SelectedItems;
            foreach (ListViewItem row in rows)
            {
                if (Guid.TryParse(row.Tag?.ToString(), out Guid workItemSystemId))
                {
                    var workItem = Program.WorkItems.List.FirstOrDefault(i => i.SystemId == workItemSystemId);
                    if (workItem != null)
                    {
                        var invoicedAmount = 0;
                        foreach (var time in Program.Times.Where(i => i.ItemSystemId == workItem.SystemId))
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
                        invoiceTime.TimeComment = "InvoiceDate: " + dtpTo.Value.ToShortDateString();
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
