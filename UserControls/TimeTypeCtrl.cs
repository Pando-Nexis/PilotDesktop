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
    public partial class TimeTypeCtrl : UserControl
    {
        public TimeTypeCtrl()
        {
            InitializeComponent();
        }

        private void TimeTypeCtrl_Load(object sender, EventArgs e)
        {

        }

        private void cbTimeType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void LoadTimeTypes()
        {
            foreach (var timeType in Program.TimeTypes)
            {
                cbTimeType.Items.Add(timeType);
            }
        }
        public TimeType GetData()
        {
            if (cbTimeType.SelectedItem != null)
            {
                return (TimeType)cbTimeType.SelectedItem;
            }
            return null;
        }
    }
}
