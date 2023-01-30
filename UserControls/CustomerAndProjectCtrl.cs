using PilotDesktop.Pilot.Objects;
using PilotDesktop.Pilot.Services;
using PilotDesktop.Work.Objects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PilotDesktop.UserControls
{
    public partial class CustomerAndProjectCtrl : UserControl
    {
        private readonly PilotCustomerService _pilotCustomerService = new PilotCustomerService();
        public CustomerAndProjectCtrl()
        {
            InitializeComponent();
            ctrlCustomer.OnIndexChanged += new System.EventHandler(this.ctrlCustomer_IndexChanged);
        }

        private void ctrlCustomer_IndexChanged(object sender, EventArgs e)
        {
            var customer = ctrlCustomer.GetData();
            if (customer != null)
            {
                ctrlProject.LoadProjects(customer.Projects, null);
            }
        }

        private void CustomerAndProjectCtrl_Load(object sender, EventArgs e)
        {

        }
        public Guid GetSelectedSystemId()
        {
            var project = ctrlProject.GetData();
            if (project!=null)
            {
                return project.SystemId;
            }
            var customer = ctrlCustomer.GetData();
            if (customer != null)
            {
                return customer.SystemId;
            }
            return Guid.Empty;
        }

        internal void SetData(Guid organizationSystemId)
        {
            PilotCustomer customer;
            PilotProject project;

            if (_pilotCustomerService.GetCustomerAndProject(Program.Customers, organizationSystemId,out customer, out project))
            {
                if (customer!=null) 
                {
                    ctrlCustomer.LoadCustomers(customer.SystemId);
                }
                if (project!=null)
                {
                    ctrlProject.LoadProjects(project.SystemId);
                }
            }
        }
    }
}
