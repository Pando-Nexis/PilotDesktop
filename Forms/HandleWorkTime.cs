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

namespace PilotDesktop.Forms
{
    public partial class HandleWorkTime : Form
    {
        private Time _workTime;
        public HandleWorkTime(Time worktime)
        {
            InitializeComponent();
            _workTime = worktime;
        }

        private void bSplit_Click(object sender, EventArgs e)
        {
            var oldMinutes = _workTime.Amount;
            workedTimeCtrl1.SaveHoursWorked(_workTime.ItemSystemId);
            var  newTime = workedTimeCtrl1.GetData();
            if (newTime != null)
            {
                newTime.SystemId = Guid.NewGuid();
                newTime.Amount = oldMinutes - newTime.Amount;
                newTime.TimeFrom= newTime.TimeFrom.AddDays(1);
                newTime.TimeTo = newTime.TimeTo.AddDays(1);
                workedTimeCtrl1.SetData(newTime);
                workedTimeCtrl1.SaveHoursWorked(newTime.ItemSystemId);
            }
           

        }

        private void bSave_Click(object sender, EventArgs e)
        {
            workedTimeCtrl1.SaveHoursWorked(_workTime.ItemSystemId);
            _workTime = workedTimeCtrl1.GetData();
           
        }

        private void HandleWorkTime_Load(object sender, EventArgs e)
        {
            workedTimeCtrl1.SetData(_workTime);
        }
    }
}
