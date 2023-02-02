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
        public ItemStatusCtrl()
        {
            InitializeComponent();
        }

        private void ItemStatusCtrl_Load(object sender, EventArgs e)
        {
            LoadItemStatuses(null);
        }
        public void LoadItemStatuses(Guid? SelectedItemStatusSystemId)
        {
            cbItemStatus.Items.Clear();
            foreach (var ItemStatus in Program.ItemStatuses)
            {
                cbItemStatus.Items.Add(ItemStatus);
                if (SelectedItemStatusSystemId.HasValue && ItemStatus.SystemId == SelectedItemStatusSystemId)
                    cbItemStatus.SelectedItem = ItemStatus;
            }
        }
        public ItemStatus GetData()
        {
            if (cbItemStatus.SelectedItem != null)
            {
                return (ItemStatus)cbItemStatus.SelectedItem;
            }
            return null;
        }
    }
}
