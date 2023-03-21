using PilotDesktop.Forms;
using PilotDesktop.General.Services;
using PilotDesktop.Pilot.Objects;
using PilotDesktop.Pilot.Services;
using PilotDesktop.Settings.Objects;
using PilotDesktop.Work.Objects;
using PilotDesktop.Work.Services;

namespace PilotDesktop
{
    public partial class PilotNavigator : Form
    {
        private readonly PilotCustomerService _pilotCustomerService;
        private readonly WorkItemService _workItemService;
        private readonly ItemStatusService _itemStatusService;
        private readonly ItemTypeService _itemTypeService;
        private readonly TimeService _timeService;
        private readonly TimeTypeService _timeTypeService;
        private readonly TimeStatusService _timeStatusService;
        public PilotNavigator()
        {
            InitializeComponent();
            _pilotCustomerService = new PilotCustomerService();
            _workItemService = new WorkItemService();
            _itemStatusService = new ItemStatusService();
            _itemTypeService = new ItemTypeService();
            _timeService = new TimeService();
            _timeTypeService = new TimeTypeService();
            _timeStatusService = new TimeStatusService();
            SnapToLeft();
        }

        private void SnapToLeft()
        {
            Screen scn = Screen.FromPoint(this.Location);
            this.Left = -8;

            this.Height = scn.WorkingArea.Height - 400;
            this.Top = (scn.WorkingArea.Height / 4) - (this.Height / 4);
        }

        private const int SnapDist = 200;
        private bool DoSnap(int pos, int edge, int snapDist = 200)
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



        private void btnSettings_Click(object sender, EventArgs e)
        {
            var dlg = new Forms.Settings();
            dlg.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void PilotNavigator_Load(object sender, EventArgs e)
        {
            SnapToLeft();
            if (!Program._pilotApplicationSettings.RequiredFieldValid())
            {
                var dlg = new Forms.Settings();
                dlg.ShowDialog();
                if (!Program._pilotApplicationSettings.RequiredFieldValid())
                    return;
            }
            LoadDataLayer();
        }
        private async void LoadDataLayer()
        {
            try
            {
                Program.WorkItems.List = await _workItemService.GetAll();
                Program.ItemStatuses = await _itemStatusService.GetAll();
                Program.ItemTypes = await _itemTypeService.GetAll();
                Program.Times = await _timeService.GetAll();
                Program.TimeStatuses = await _timeStatusService.GetAll();
                Program.TimeTypes = await _timeTypeService.GetAll();
                GetCustomers();
            }
            catch
            {
            }

        }
        private async void GetCustomers()
        {
            Program.Customers = await _pilotCustomerService.GetCustomers();

            foreach (var customer in Program.Customers)
            {

                var dropDown = new ToolStripDropDownButton();
                DecorateMenuItemNode(ref dropDown);
                dropDown.Text = customer.Name;
                dropDown.Tag = customer.SystemId.ToString();

                var handleWorkItems = new ToolStripButton();
                DecorateMenuItemNode(ref handleWorkItems);
                handleWorkItems.Text = "Alla aktiviteter";
                handleWorkItems.Tag = customer;
                handleWorkItems.Click += new EventHandler(HandleCustomerWorkItem);
                dropDown.DropDownItems.Add(handleWorkItems);

                var addWorkItems = new ToolStripDropDownButton();
                addWorkItems.Text = "Lägg till";

                var workItems = CreateItemTypeMenu(customer.SystemId);
                foreach (var workItem in workItems)
                {
                    addWorkItems.DropDownItems.Add(workItem);
                }


                dropDown.DropDownItems.Add(addWorkItems);
                dropDown.DropDownItems.Add(new ToolStripSeparator());

                foreach (var project in customer.Projects)
                {
                    var projectNode = new ToolStripDropDownButton();
                    DecorateMenuItemNode(ref projectNode);
                    projectNode.Text = project.Name;
                    projectNode.Tag = project;
                    if (project.ProjectType == "PandoNexisAccelerator")
                    {
                        var syncCode = new ToolStripButton();
                        DecorateMenuItemNode(ref syncCode);
                        syncCode.Text = "sync code";
                        syncCode.Tag = project;
                        syncCode.Click += new EventHandler(OpenCodeSync);
                        projectNode.DropDownItems.Add(syncCode);
                        projectNode.DropDownItems.Add(new ToolStripSeparator());
                    }

                    var handleProjectWorkItems = new ToolStripButton();
                    DecorateMenuItemNode(ref handleProjectWorkItems);
                    handleProjectWorkItems.Text = "Alla aktiviteter";
                    handleProjectWorkItems.Tag = project;
                    handleProjectWorkItems.Click += new EventHandler(HandleProjectWorkItem);
                    projectNode.DropDownItems.Add(handleProjectWorkItems);

                    var addProjectWorkItems = new ToolStripDropDownButton();
                    addProjectWorkItems.Text = "Lägg till";

                    workItems = CreateItemTypeMenu(project.SystemId);
                    foreach (var workItem in workItems)
                    {
                        addProjectWorkItems.DropDownItems.Add(workItem);
                    }
                    projectNode.DropDownItems.Add(addProjectWorkItems);

                    dropDown.DropDownItems.Add(projectNode);
                }
                toolStrip1.Items.Add(dropDown);
            }
        }

        private List<ToolStripButton> CreateItemTypeMenu(Guid organizationSystemId)
        {
            var menuList = new List<ToolStripButton>();
            foreach (var type in Program.ItemTypes)
            {
                ToolStripButton item = new ToolStripButton();
                DecorateMenuItemNode(ref item);
                var workItem = new WorkItem();
                workItem.OrganizationSystemId = organizationSystemId;
                workItem.ItemTypeSystemId = type.SystemId;
                item.Text = type.Name;
                item.Tag = workItem;
                item.Click += new EventHandler(AddWorkItem);

                menuList.Add(item);
            }


            return menuList;
        }

        private void DecorateMenuItemNode(ref ToolStripButton button)
        {
            button.Width = 150;
            button.TextAlign = ContentAlignment.MiddleLeft;
        }

        private void DecorateMenuItemNode(ref ToolStripDropDownButton dropDownButton, bool horisontal = false)
        {
            dropDownButton.Width = 150;
            dropDownButton.TextAlign = ContentAlignment.MiddleLeft;

        }
        private void HandleCustomerWorkItem(object? sender, EventArgs e)
        {
            var senderButton = (ToolStripButton)sender;
            var customer = senderButton.Tag as PilotCustomer;
            var frm = new Forms.WorkItems("CustomerSystemId", customer.SystemId);
            frm.Show();
        }
        private void HandleProjectWorkItem(object? sender, EventArgs e)
        {
            var senderButton = (ToolStripButton)sender;
            var project = senderButton.Tag as PilotProject;
            var frm = new Forms.WorkItems("ProjectSystemId", project.SystemId);
            frm.Show();
        }


        private void OpenCodeSync(object sender, EventArgs e)
        {
            var senderButton = (ToolStripButton)sender;
            var project = senderButton.Tag as PilotProject;
            var frm = new CustomerSourceCodeTool(project);
            frm.Show();
        }

        private void AddWorkItem(object sender, EventArgs e)
        {
            var senderButton = (ToolStripButton)sender;
            var workItem = senderButton.Tag as WorkItem;
            var frm = new HandleWorkItem(workItem);
            frm.Show();
        }

        private void btnToCodeGenerator_Click(object sender, EventArgs e)
        {
            var dlg = new Forms.CodeGenerator();
            dlg.ShowDialog();
        }


        private void bHandleAddOn_Click(object sender, EventArgs e)
        {
            var dlg = new Forms.HandleAddons();
            dlg.ShowDialog();
        }

        private void btnToOblivion_Click(object sender, EventArgs e)
        {
            var frm = new Forms.WorkItems(string.Empty, Guid.Empty);
            frm.Show();
        }

        private void bSettings_Click(object sender, EventArgs e)
        {
            var dlg = new Forms.Settings();
            dlg.ShowDialog();
        }

        private void bInvoicing_Click(object sender, EventArgs e)
        {
            var frm = new Forms.HandleInvoicing();
            frm.Show();
        }

        private void bInvoices_Click(object sender, EventArgs e)
        {
            var frm = new Forms.HandleInvoices();
            frm.Show();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            var frm = new Forms.WorkTimeCalender();
            frm.Show();
        }
    }
}
