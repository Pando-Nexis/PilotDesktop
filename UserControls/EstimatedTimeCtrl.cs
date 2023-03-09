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
    public partial class EstimatedTimeCtrl : UserControl
    {
        private Time _time = new Time();
        private TimeService _timeService = new TimeService();
        public EstimatedTimeCtrl()
        {
            InitializeComponent();
        }

        public void SetData(Time time)
        {
            if (time != null)
            {
                _time = time;
                if (_time.ItemSystemId != Guid.Empty)
                {
                    tbEstimate.Text = _timeService.GetHours(_time.Amount).ToString("0.##");
                    tbRisk.Text = _time.Risk.ToString("0.##");
                    tbMax.Text = (_timeService.GetHours(_time.Amount) * _time.Risk).ToString("0.##");
                    rtbComment.Text = _time.TimeComment;

                    tbEstimate.Enabled = true;
                    tbRisk.Enabled = true;
                    rtbComment.Enabled = true;
                }
            }
        }

        private void tbEstimate_TextChanged(object sender, EventArgs e)
        {
            CalculateMax();
        }
        private void tbExtimate_KeyUp(object sender, EventArgs e)
        {
            if (tbEstimate.Text != "")
            {
                var value = decimal.MinValue;
                if (!decimal.TryParse(tbEstimate.Text, out value))
                    tbEstimate.Text = "";
                if (value < 0)
                    tbEstimate.Text = "";
            }

        }

        private void tbRisk_TextChanged(object sender, EventArgs e)
        {
            CalculateMax();
        }
        private void CalculateMax()
        {
            if (decimal.TryParse(tbEstimate.Text, out decimal estimate))
            {
                if (decimal.TryParse(tbRisk.Text, out decimal risk))
                {
                    if (risk == 0)
                        risk = 1;
                    tbMax.Text = (estimate * risk).ToString();
                    return;
                }
                tbMax.Text = tbEstimate.Text;
            }
        }
        public async void SaveEstimate(Guid workItemSystemId)
        {
            if (decimal.TryParse(tbEstimate.Text, out decimal estimate))
            {
                _time.ItemSystemId = workItemSystemId;
                _time.Amount = _timeService.GetMinutesFromHours(estimate);

                decimal.TryParse(tbRisk.Text, out decimal risk);
                _time.Risk = risk==0?1:risk;
                _time.TimeComment = rtbComment.Text;
                var list = await _timeService.AddOrUpdate(_time);
                if (list != null)
                {
                    Program.Times = list;
                    _time = Program.Times.FirstOrDefault(i => i.SystemId == _time.SystemId);

                    SetData(_time);
                }
            }
        }

      
    }
}
