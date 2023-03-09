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
        private Guid _workedTimeSystemId = Guid.Empty;
        private Time _selectedTime;

        public WorkedTimeCtrl()
        {
            InitializeComponent();
            _workedTimeSystemId = Program.TimeTypes.FirstOrDefault(i => i.Name == "Worked")?.SystemId ?? Guid.Empty;
        }

        private void WorkedTime_Load(object sender, EventArgs e)
        {

        }
        public void SetData(List<Time> times)
        {
            tbTotalTime.Text = _timeService.GetHours(times.Sum(i => i.Amount)).ToString();
            tbWorkedTime.Text = "";
            rtbComment.Text = "";

        }
        public void SetData(Time time)
        {
            _selectedTime = time;
            _time = Program.Times.Where(i => i.ItemSystemId == _selectedTime.ItemSystemId && i.TimeTypeSystemId == _workedTimeSystemId).ToList();
            SetData(_time);

            tbTotalTime.Visible = false;
            tbWorkedTime.Text = _timeService.GetHours(_selectedTime.Amount).ToString();
            rtbComment.Text = _selectedTime.TimeComment;
            dtpFrom.Value = _selectedTime.TimeFrom;
            dtpTo.Value = _selectedTime.TimeTo;

        }
        public async void SaveHoursWorked(Guid workItemSystemId)
        {
            if (decimal.TryParse(tbWorkedTime.Text, out decimal workedTime))
            {
                var resetData = true;
                if (_selectedTime == null)
                {
                    _selectedTime = new Time()
                    {
                        ItemSystemId = workItemSystemId,
                        TimeTypeSystemId = _workedTimeSystemId,
                        TimeStatusSystemId = Program.TimeStatuses.FirstOrDefault(i => i.Name == "New").SystemId,
                    };
                }
                _selectedTime.ItemSystemId = workItemSystemId;
                _selectedTime.Amount = _timeService.GetMinutesFromHours(workedTime);
                _selectedTime.TimeFrom = dtpFrom.Value;
                _selectedTime.TimeTo = dtpTo.Value;
                _selectedTime.TimeComment = rtbComment.Text;
                var list = await _timeService.AddOrUpdate(_selectedTime);
                if (list != null)
                {
                    Program.Times = list;
                    _time = Program.Times.Where(i => i.ItemSystemId == _selectedTime.ItemSystemId && i.TimeTypeSystemId == _workedTimeSystemId).ToList();

                    if (resetData)
                    {
                        SetData(_selectedTime);
                    }
                    else
                    {
                        SetData(_time);
                    }
                }
            }
        }

        private void tbWorkedTime_TextChanged(object sender, EventArgs e)
        {
            if (Decimal.TryParse(tbWorkedTime.Text, out decimal hours))
            {
                var minutes = (int)hours * 60;
                dtpTo.Value = dtpFrom.Value.AddMinutes(minutes);
            }
        }

        private void dtpFrom_ValueChanged(object sender, EventArgs e)
        {
            if (Decimal.TryParse(tbWorkedTime.Text, out decimal hours))
            {
                var minutes = (int)hours * 60;
                dtpTo.Value = dtpFrom.Value.AddMinutes(minutes);
            }
        }

        public Time GetData()
        {
            return _selectedTime;
        }
    }
}
