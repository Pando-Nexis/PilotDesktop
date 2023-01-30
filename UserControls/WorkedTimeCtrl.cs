using PilotDesktop.Work.Objects;
using PilotDesktop.Work.Services;
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
    public partial class WorkedTimeCtrl : UserControl
    {
        private List<Time> _time = new List<Time>();
        private TimeService _timeService = new TimeService();
        public WorkedTimeCtrl()
        {
            InitializeComponent();
        }

        private void WorkedTime_Load(object sender, EventArgs e)
        {

        }
        public void SetData(List<Time> times)
        {
            tbTotalTime.Text = _timeService.GetHours(times.Sum(i=>i.Amount)).ToString();

        }
    }
}
