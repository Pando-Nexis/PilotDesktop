using PilotDesktop.Forms;
using PilotDesktop.Pilot.Objects;
using PilotDesktop.Pilot.Services;
using System.Runtime.InteropServices;
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
            SnapToLeft();
        }

        private void SnapToLeft()
        {
            Screen scn = Screen.FromPoint(this.Location);
            this.Left = -8;

            this.Height = scn.WorkingArea.Height - 400;
            this.Top = (scn.WorkingArea.Height/4) - (this.Height/4);
        }

        private const int SnapDist = 200;
        private bool DoSnap(int pos, int edge, int snapDist=200)
        {
            int delta = pos - edge;
            return delta > 0 && delta <= SnapDist;
        }


        protected override void OnResizeEnd(EventArgs e)
        {
            base.OnResizeEnd(e);
            Screen scn = Screen.FromPoint(this.Location);
            if (DoSnap(this.Left, scn.WorkingArea.Left))
            {
                this.Left = scn.WorkingArea.Left - 10; 
                this.Height = scn.WorkingArea.Height - 400;
                this.Top = (scn.WorkingArea.Height / 4) - (this.Height / 4);
            }
            //else if (DoSnap(this.Top, scn.WorkingArea.Top, 40)) this.Top = scn.WorkingArea.Top;
            else if (DoSnap(scn.WorkingArea.Right, this.Right))
            {
                this.Left = scn.WorkingArea.Right - this.Width + 10; 
                this.Height = scn.WorkingArea.Height - 400;
                this.Top = (scn.WorkingArea.Height / 4) - (this.Height / 4);
            }
            //else if (DoSnap(scn.WorkingArea.Bottom, this.Bottom, 40)) this.Top = scn.WorkingArea.Bottom - this.Height;
            else
            {
                this.Height = 500;
            }
        }

        //protected override void OnMove(EventArgs e)
        //{
        //    base.OnMove(e);
        //    this.Height = 300; 
            
        //}

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
           
        }

        private void PilotNavigator_Load(object sender, EventArgs e)
        {
            GetCustomers();
            SnapToLeft();
        }
        private async void GetCustomers()
        {
            Program._customers = await _pilotCustomerService.GetCustomers();

            foreach (var customer in Program._customers)
            {

                var dropDown = new ToolStripDropDownButton();
                dropDown.Text = customer.Name;
              
                foreach(var project in customer.Projects)
                {
                    var projectNode = new ToolStripDropDownButton();
                    projectNode.Text = project.Name;
                    projectNode.Tag = project.SystemId.ToString();  
                    var syncCode = new ToolStripButton();
                    syncCode.Text = "sync code";
                    syncCode.Tag = project;
                    syncCode.Click += new EventHandler(OpenCodeSync);
                    projectNode.DropDownItems.Add(syncCode);
                    projectNode.DropDownItems.Add("test2");
                    dropDown.DropDownItems.Add(projectNode);
                }
                
   
                toolStrip1.Items.Add(dropDown);


            }
        }
        private void OpenCodeSync(object sender, EventArgs e)
        {
            var senderButton = (ToolStripButton)sender;
            var project =  senderButton.Tag as PilotProject;
            var frm = new CustomerSourceCodeTool(project);
            frm.Show();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            //var dlg = new Forms.CodeGenerator();
            //dlg.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var dlg = new Forms.CodeGenerator();
            dlg.ShowDialog();
        }

        private void bRegisterAddon_Click(object sender, EventArgs e)
        {
            var dlg = new Forms.HandleAddons();
            dlg.ShowDialog();
        }
    }
}