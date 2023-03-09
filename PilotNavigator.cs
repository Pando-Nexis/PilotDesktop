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
                GetCustomers();
                Program.WorkItems.List = await _workItemService.GetAll();
                Program.ItemStatuses = await _itemStatusService.GetAll();
                Program.ItemTypes = await _itemTypeService.GetAll();
                Program.Times = await _timeService.GetAll();
                Program.TimeStatuses = await _timeStatusService.GetAll();
                Program.TimeTypes = await _timeTypeService.GetAll();
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
                    }

                    projectNode.DropDownItems.Add(new ToolStripSeparator());

                    var handleProjectWorkItems = new ToolStripButton();
                    DecorateMenuItemNode(ref handleProjectWorkItems);
                    handleProjectWorkItems.Text = "Akitiviteter";
                    handleProjectWorkItems.Tag = project;
                    handleProjectWorkItems.Click += new EventHandler(HandleProjectWorkItem);
                    projectNode.DropDownItems.Add(handleProjectWorkItems);

                    var addProjectWorkItems = new ToolStripDropDownButton();
                    addProjectWorkItems.Text = "Lägg till";

                    var addProjectWorkItemEpic = new ToolStripButton();
                    DecorateMenuItemNode(ref addProjectWorkItemEpic);
                    addProjectWorkItemEpic.Text = "Epic";
                    addProjectWorkItemEpic.Tag = project;
                    addProjectWorkItemEpic.Click += new EventHandler(AddProjectWorkItemEpic);
                    addProjectWorkItems.DropDownItems.Add(addProjectWorkItemEpic);

                    var addProjectWorkItemStory = new ToolStripButton();
                    DecorateMenuItemNode(ref addProjectWorkItemStory);
                    addProjectWorkItemStory.Text = "Story";
                    addProjectWorkItemStory.Tag = project;
                    addProjectWorkItemStory.Click += new EventHandler(AddProjectWorkItemStory);
                    addProjectWorkItems.DropDownItems.Add(addProjectWorkItemStory);

                    var addProjectWorkItemTask = new ToolStripButton();
                    DecorateMenuItemNode(ref addProjectWorkItemTask);
                    addProjectWorkItemTask.Text = "Task";
                    addProjectWorkItemTask.Tag = project;
                    addProjectWorkItemTask.Click += new EventHandler(AddProjectWorkItemTask);
                    addProjectWorkItems.DropDownItems.Add(addProjectWorkItemTask);

                    projectNode.DropDownItems.Add(addProjectWorkItems);


                    dropDown.DropDownItems.Add(projectNode);
                }
                dropDown.DropDownItems.Add(new ToolStripSeparator());

                var handleWorkItems = new ToolStripButton();
                DecorateMenuItemNode(ref handleWorkItems);
                handleWorkItems.Text = "Akitiviteter";
                handleWorkItems.Tag = customer;
                handleWorkItems.Click += new EventHandler(HandleCustomerWorkItem);
                dropDown.DropDownItems.Add(handleWorkItems);

                var addWorkItems = new ToolStripDropDownButton();
                addWorkItems.Text = "Lägg till";

                var addWorkItemEpic = new ToolStripButton();
                DecorateMenuItemNode(ref addWorkItemEpic);
                addWorkItemEpic.Text = "Epic";
                addWorkItemEpic.Tag = customer;
                addWorkItemEpic.Click += new EventHandler(AddCustomerWorkItemEpic);
                addWorkItems.DropDownItems.Add(addWorkItemEpic);

                var addWorkItemStory = new ToolStripButton();
                DecorateMenuItemNode(ref addWorkItemStory);
                addWorkItemStory.Text = "Story";
                addWorkItemStory.Tag = customer;
                addWorkItemStory.Click += new EventHandler(AddCustomerWorkItemStory);
                addWorkItems.DropDownItems.Add(addWorkItemStory);

                var addWorkItemTask = new ToolStripButton();
                DecorateMenuItemNode(ref addWorkItemTask);
                addWorkItemTask.Text = "Task";
                addWorkItemTask.Tag = customer;
                addWorkItemTask.Click += new EventHandler(AddCustomerWorkItemTask);
                addWorkItems.DropDownItems.Add(addWorkItemTask);

                dropDown.DropDownItems.Add(addWorkItems);


                toolStrip1.Items.Add(dropDown);
            }
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
        private void AddCustomerWorkItemTask(object sender, EventArgs e)
        {
            var senderButton = (ToolStripButton)sender;
            var customer = senderButton.Tag as PilotCustomer;
            var workItem = new WorkItem();
            workItem.OrganizationSystemId = customer.SystemId;
            workItem.ItemTypeSystemId = Program.ItemTypes?.FirstOrDefault(i => i.Name == "Task")?.SystemId ?? Guid.Empty;
            workItem.ItemStatusSystemId = Program.ItemStatuses?.FirstOrDefault(i => i.Name == "Ny")?.SystemId ?? Guid.Empty;
            var frm = new HandleWorkItem(workItem);
            frm.Show();
        }
        private void AddCustomerWorkItemStory(object sender, EventArgs e)
        {
            var senderButton = (ToolStripButton)sender;
            var customer = senderButton.Tag as PilotCustomer;
            var workItem = new WorkItem();
            workItem.OrganizationSystemId = customer.SystemId;
            workItem.ItemTypeSystemId = Program.ItemTypes?.FirstOrDefault(i => i.Name == "Story")?.SystemId ?? Guid.Empty;
            workItem.ItemStatusSystemId = Program.ItemStatuses?.FirstOrDefault(i => i.Name == "Ny")?.SystemId ?? Guid.Empty;
            var frm = new HandleWorkItem(workItem);
            frm.Show();
        }
        private void AddCustomerWorkItemEpic(object sender, EventArgs e)
        {
            var senderButton = (ToolStripButton)sender;
            var customer = senderButton.Tag as PilotCustomer;
            var workItem = new WorkItem();
            workItem.OrganizationSystemId = customer.SystemId;
            workItem.ItemTypeSystemId = Program.ItemTypes?.FirstOrDefault(i => i.Name == "Epic")?.SystemId ?? Guid.Empty;
            workItem.ItemStatusSystemId = Program.ItemStatuses?.FirstOrDefault(i => i.Name == "Ny")?.SystemId ?? Guid.Empty;
            var frm = new HandleWorkItem(workItem);
            frm.Show();
        }

        private void AddProjectWorkItemTask(object sender, EventArgs e)
        {
            var senderButton = (ToolStripButton)sender;
            var project = senderButton.Tag as PilotProject;
            var workItem = new WorkItem();
            workItem.OrganizationSystemId = project.SystemId;
            workItem.ItemTypeSystemId = Program.ItemTypes?.FirstOrDefault(i => i.Name == "Task")?.SystemId ?? Guid.Empty;
            workItem.ItemStatusSystemId = Program.ItemStatuses?.FirstOrDefault(i => i.Name == "Ny")?.SystemId ?? Guid.Empty;
            var frm = new HandleWorkItem(workItem);
            frm.Show();
        }
        private void AddProjectWorkItemStory(object sender, EventArgs e)
        {
            var senderButton = (ToolStripButton)sender;
            var project = senderButton.Tag as PilotProject;
            var workItem = new WorkItem();
            workItem.OrganizationSystemId = project.SystemId;
            workItem.ItemTypeSystemId = Program.ItemTypes?.FirstOrDefault(i => i.Name == "Story")?.SystemId ?? Guid.Empty;
            workItem.ItemStatusSystemId = Program.ItemStatuses?.FirstOrDefault(i => i.Name == "Ny")?.SystemId ?? Guid.Empty;
            var frm = new HandleWorkItem(workItem);
            frm.Show();
        }
        private void AddProjectWorkItemEpic(object sender, EventArgs e)
        {
            var senderButton = (ToolStripButton)sender;
            var project = senderButton.Tag as PilotProject;
            var workItem = new WorkItem();
            workItem.OrganizationSystemId = project.SystemId;
            workItem.ItemTypeSystemId = Program.ItemTypes?.FirstOrDefault(i => i.Name == "Epic")?.SystemId ?? Guid.Empty;
            workItem.ItemStatusSystemId = Program.ItemStatuses?.FirstOrDefault(i => i.Name == "Ny")?.SystemId ?? Guid.Empty;
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
            var frm  = new Forms.HandleInvoicing();
            frm.Show();
        }

        private void bInvoices_Click(object sender, EventArgs e)
        {
            var frm = new Forms.HandleInvoices();
            frm.Show();
        }
    }
}
