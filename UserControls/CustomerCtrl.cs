using PilotDesktop.Pilot.Objects;
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
    public partial class CustomerCtrl : UserControl
    {
        public CustomerCtrl()
        {
            InitializeComponent();
        }

        private void CustomerCtrl_Load(object sender, EventArgs e)
        {
            LoadCustomers(null);
        }
        public void LoadCustomers(Guid? selectedCustomerSystemId)
        {
            cbCustomer.Items.Clear();
            foreach(var customer in Program.Customers)
            {
                cbCustomer.Items.Add(customer);
                if (selectedCustomerSystemId.HasValue && customer.SystemId == selectedCustomerSystemId)
                {
                    cbCustomer.SelectedItem = customer;
                }

            }
        }

        public PilotCustomer GetData()
        {
            if (cbCustomer.SelectedItem!=null)
            {
                return (PilotCustomer)cbCustomer.SelectedItem;
            }
            return null;
        }
        private void cbCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {
            RaiseIndexChanged(e);

        }
        #region Eventhandlers
        public event EventHandler OnIndexChanged;
        public virtual void RaiseIndexChanged(EventArgs ea)
        {
            var handler = OnIndexChanged;
            if (OnIndexChanged != null)
                OnIndexChanged(this, ea);
        }

       

        //public string GetSelectedText()
        //{
        //    return ((Project)cbProject.SelectedItem)?.ToString() ?? "";
        //}
        #endregion
    }
}
