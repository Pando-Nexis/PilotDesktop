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
        public ItemTypeCtrl()
        {
            InitializeComponent();
        }

        private void ItemTypeCtrl_Load(object sender, EventArgs e)
        {
            LoadItemTypes(null);
        }
        public void LoadItemTypes(Guid? SelectedItemTypeSystemId)
        {
            cbItemType.Items.Clear();   
            foreach(var itemType in Program.ItemTypes)
            {
                cbItemType.Items.Add(itemType);
                if (SelectedItemTypeSystemId.HasValue && itemType.SystemId == SelectedItemTypeSystemId)
                    cbItemType.SelectedItem = itemType;
            }
        }
        public ItemType GetData()
        {
            if (cbItemType.SelectedItem != null)
            {
                return (ItemType)cbItemType.SelectedItem;
            }
            return null;
        }
    }
}
