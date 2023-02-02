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
        private TimeTypeService _timeTypeService = new TimeTypeService();
        private Guid _estimatedTimeSystemId = Guid.Empty;

        public WorkedTimeCtrl()
        {
            InitializeComponent();
            _estimatedTimeSystemId = Program.TimeTypes.FirstOrDefault(i => i.Name == "Worked")?.SystemId ?? Guid.Empty;
        }

        private void WorkedTime_Load(object sender, EventArgs e)
        {

        }
        public void SetData(List<Time> times)
        {
            tbTotalTime.Text = _timeService.GetHours(times.Sum(i=>i.Amount)).ToString();
            tbWorkedTime.Text = "";
            rtbComment.Text = "";

        }
        public async void SaveHoursWorked(Guid workItemSystemId)
        {
            if (decimal.TryParse(tbWorkedTime.Text, out decimal workedTime))
            {
                var time = new Time() 
                { 
                ItemSystemId = workItemSystemId, 
                TimeTypeSystemId = _estimatedTimeSystemId
                };

                time.ItemSystemId = workItemSystemId;
                time.Amount = _timeService.GetMinutesFromHours(workedTime);

                time.TimeComment = rtbComment.Text;
                var list = await _timeService.AddOrUpdate(time);
                if (list != null)
                {
                    Program.Times = list;
                    _time = Program.Times.Where(i => i.ItemSystemId == time.ItemSystemId && i.TimeTypeSystemId==_estimatedTimeSystemId).ToList();

                    SetData(_time);
                }
            }
        }
    }
}
