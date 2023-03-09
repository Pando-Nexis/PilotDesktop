using PilotDesktop.Pilot.Objects;
using PilotDesktop.Work.Objects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.DirectoryServices.ActiveDirectory;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PilotDesktop.UserControls
{
    public partial class ItemStatusCtrl : UserControl
    {
        private Guid _incommingSystemId = Guid.Empty;
        public ItemStatusCtrl()
        {
            InitializeComponent();
        }

        private void ItemStatusCtrl_Load(object sender, EventArgs e)
        {
            LoadItemStatuses(null);
        }
        public void LoadItemStatuses(Guid? selectedItemStatusSystemId)
        {

            if (selectedItemStatusSystemId.HasValue)
            {
                _incommingSystemId = (Guid)selectedItemStatusSystemId;
            }

            cbItemStatus.Items.Clear();
            foreach (var ItemStatus in Program.ItemStatuses)
            {
                cbItemStatus.Items.Add(ItemStatus);
                if (selectedItemStatusSystemId.HasValue && ItemStatus.SystemId == selectedItemStatusSystemId)
                    cbItemStatus.SelectedItem = ItemStatus;
            }
        }
        public ItemStatus GetData()
        {
            if (cbItemStatus.SelectedItem != null)
            {
                return (ItemStatus)cbItemStatus.SelectedItem;
            }
       
            if (_incommingSystemId != Guid.Empty)
                return Program.ItemStatuses?.FirstOrDefault(i => i.SystemId == _incommingSystemId);

            return null;
        }
    }
}
