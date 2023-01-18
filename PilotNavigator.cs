using PilotDesktop.Forms;
using PilotDesktop.Pilot.Objects;
using PilotDesktop.Pilot.Services;
using System.Windows.Forms;

namespace PilotDesktop
{
    public partial class PilotNavigator : Form
    {
        private readonly PilotCustomerService _pilotCustomerService;
        public PilotNavigator()
        {
            InitializeComponent();
            _pilotCustomerService =  new PilotCustomerService();
        }

        private void mnyWToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void bSettings_Click(object sender, EventArgs e)
        {
            var dlg = new Forms.Settings(); 
            dlg.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var frm = new Forms.CustomerSourceCodeTool("TestProject1");
            frm.Show();
        }

        private void PilotNavigator_Load(object sender, EventArgs e)
        {
            GetCustomers();
        }
        private async void GetCustomers()
        {
            Program._customers = await _pilotCustomerService.GetCustomers();

            foreach (var customer in Program._customers)
            {

                var dropDown = new ToolStripDropDownButton();
                dropDown.Text = customer.Name;
                var syncCode = new ToolStripButton();
                syncCode.Text = "sync code";
                syncCode.Tag = customer.Name;
                syncCode.Click += new EventHandler(OpenCodeSync);
                dropDown.DropDownItems.Add(syncCode);
                dropDown.DropDownItems.Add("test2");
                toolStrip1.Items.Add(dropDown);


            }
        }
        private void OpenCodeSync(object sender, EventArgs e)
        {
            var senderButton = (ToolStripButton)sender;
            var customer = Program._customers.FirstOrDefault(i => i.Name == senderButton.Tag);
            var frm = new CustomerSourceCodeTool(customer.ProjectName);
            frm.Show();
        }
    }
}