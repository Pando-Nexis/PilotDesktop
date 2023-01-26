using PilotDesktop.Forms;
using PilotDesktop.Pilot.Objects;
using PilotDesktop.Pilot.Services;
using PilotDesktop.WorkItems.Services;

namespace PilotDesktop
{
    public partial class PilotNavigator : Form
    {
        private readonly PilotCustomerService _pilotCustomerService;
        private readonly WorkItemService _workItemService;
        public PilotNavigator()
        {
            InitializeComponent();
            _pilotCustomerService =  new PilotCustomerService();
            _workItemService = new WorkItemService();
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
                this.Width = 135;
            }
            //else if (DoSnap(this.Top, scn.WorkingArea.Top, 40)) this.Top = scn.WorkingArea.Top;
            else if (DoSnap(scn.WorkingArea.Right, this.Right))
            {
                this.Left = scn.WorkingArea.Right - this.Width + 10; 
                this.Height = scn.WorkingArea.Height - 400;
                this.Width = 135;
                this.Top = (scn.WorkingArea.Height / 4) - (this.Height / 4);
            }
            //else if (DoSnap(scn.WorkingArea.Bottom, this.Bottom, 40)) this.Top = scn.WorkingArea.Bottom - this.Height;
            else
            {
                this.Height = this.Height;
                this.Width = 800;
            }
        }

        //protected override void OnMove(EventArgs e)
        //{
        //    base.OnMove(e);
        //    this.Height = 300; 
            
        //}

        private void btnSettings_Click(object sender, EventArgs e)
        {
            var dlg = new Forms.Settings(); 
            dlg.ShowDialog();
        }

        private void PilotNavigator_Load(object sender, EventArgs e)
        {
            SnapToLeft();
            GetCustomers();
            GetWorkItems();
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
        private async void GetWorkItems()
        {
            Program.workItems = await _workItemService.GetWorkItems();
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

        private void btnToCodeGenerator_Click(object sender, EventArgs e)
        {
            var dlg = new Forms.CodeGenerator();
            dlg.ShowDialog();
        }

        private void Keg_Click(object sender, EventArgs e)
        {
            var dlg = new Forms.Settings();
            dlg.ShowDialog();
        }

        private void bHandleAddOn_Click(object sender, EventArgs e)
        {
            var dlg = new Forms.HandleAddons();
            dlg.ShowDialog();
        }
    }
}