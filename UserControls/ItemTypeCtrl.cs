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
    public partial class ItemTypeCtrl : UserControl
    {
        private Guid _incommingSystemId = Guid.Empty;
        public ItemTypeCtrl()
        {
            InitializeComponent();
        }

        private void ItemTypeCtrl_Load(object sender, EventArgs e)
        {
            LoadItemTypes(null);
        }
        public void LoadItemTypes(Guid? selectedItemTypeSystemId)
        {
            if (selectedItemTypeSystemId.HasValue)
            {
                _incommingSystemId = (Guid)selectedItemTypeSystemId;
            }
            cbItemType.Items.Clear();
            foreach (var itemType in Program.ItemTypes)
            {
                cbItemType.Items.Add(itemType);
                if (selectedItemTypeSystemId.HasValue && itemType.SystemId == selectedItemTypeSystemId)
                    cbItemType.SelectedItem = itemType;
            }
        }
        public ItemType GetData()
        {
            if (cbItemType.SelectedItem != null)
            {
                return (ItemType)cbItemType.SelectedItem;
            }
            if (_incommingSystemId != Guid.Empty)
                return Program.ItemTypes?.FirstOrDefault(i => i.SystemId == _incommingSystemId);
            return null;
        }
    }
}
