using MiniExcelLibs;
using PilotDesktop.General.Services;
using PilotDesktop.Pilot.Objects;
using PilotDesktop.Pilot.Services;
using PilotDesktop.Work.Objects;
using PilotDesktop.Work.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.Net.Mail;

namespace PilotDesktop.Forms
{
    public partial class ViewInvoice : Form
    {
        private WorkItemService _workItemService = new WorkItemService();
        private TimeService _timeService = new TimeService();
        private PilotCustomerService _pilotCustomerService = new PilotCustomerService();
        private PilotCustomer _selectedCustomer;
        private string _invoice;
        public ViewInvoice(PilotCustomer selectedCustomer, string invoice)
        {
            InitializeComponent();
            _selectedCustomer = selectedCustomer;
            _invoice = invoice;
        }

        private void HandleInvoicing_Load(object sender, EventArgs e)
        {
            LoadData();
        }


        private void LoadData()
        {
            var invoiceTime = Program.Times.Where(i => i.OrganizationSystemId == _selectedCustomer.SystemId && i.TimeComment == _invoice);

            var dtData = new DataTable();
            var colData = new DataColumn();
            colData.ColumnName = "Kund";
            dtData.Columns.Add(colData);

            colData = new DataColumn();
            colData.ColumnName = "Projekt";
            dtData.Columns.Add(colData);

            colData = new DataColumn();
            colData.ColumnName = "Id";
            dtData.Columns.Add(colData);

            colData = new DataColumn();
            colData.ColumnName = "Titel";
            dtData.Columns.Add(colData);

            colData = new DataColumn();
            colData.ColumnName = "Hours";
            dtData.Columns.Add(colData);

            foreach (var t in invoiceTime)
            {
                var workTime = _timeService.GetHours(t.Amount);
                var workItem = _workItemService.Get(t.ItemSystemId);
                _pilotCustomerService.GetCustomerAndProject(workItem, out PilotCustomer customer, out PilotProject project);
                DataRow dtrData = dtData.NewRow();
                dtrData[0] = customer?.Name ?? string.Empty;
                dtrData[1] = project?.Name ?? string.Empty;
                dtrData[2] = workItem.Id;
                dtrData[3] = workItem.ItemTitle;
                dtrData[4] = workTime.ToString("0.##");
                dtData.Rows.Add(dtrData);
            }

            DataRow dtrDataTotal = dtData.NewRow();
            dtrDataTotal[0] = "Totalt:";


            dtrDataTotal[4] = _timeService.GetHours(invoiceTime.Sum(i => i.Amount)).ToString("0.##");
            dtData.Rows.Add(dtrDataTotal);


            dataGridView1.DataSource = dtData;
            foreach( DataGridViewColumn col in dataGridView1.Columns)
            {

                col.AutoSizeMode= DataGridViewAutoSizeColumnMode.AllCells;

            }
        }

        private void SendData()
        {

            var dtData = (DataTable)dataGridView1.DataSource;
            string fileName = $"c:\\temp\\{_selectedCustomer.Name}-{DateTime.Now.ToShortDateString().Replace("-", "")}{DateTime.Now.ToShortTimeString().Replace(":", "")}.xlsx";
            MiniExcel.SaveAs(fileName, dtData);

            using (MailMessage mm = new MailMessage("info@jennifer50.se", "jennifer.skold@dixcon.se"))
            {


                mm.Subject = "Fakturaunderlag";
                mm.Body = "";
                mm.Attachments.Add(new Attachment(fileName));

                mm.IsBodyHtml = false;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "send.one.com";
                smtp.EnableSsl = true;
                NetworkCredential NetworkCred = new NetworkCredential("info@jennifer50.se", "Happyj5k");
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = NetworkCred;
                smtp.Port = 587;
                smtp.Send(mm);
                MessageBox.Show("Email sent.", "Message");
            }
            File.Delete(fileName);

        }




        private void bToExcel_Click(object sender, EventArgs e)
        {
            SendData();
        }
    }
}
