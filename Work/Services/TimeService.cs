using Newtonsoft.Json;
using PilotDesktop.Pilot.Objects;
using PilotDesktop.Pilot.Services;
using PilotDesktop.Work.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace PilotDesktop.Work.Services
{
    public class TimeService
    {
        private readonly ConnectToApi _connectToApi;
        private Guid _workTimeSystemId;
        private Guid _invoiceWorkTimeSystemId;
        public TimeService()
        {
            _connectToApi = new ConnectToApi();
            LoadConstants();
        }
        public void LoadConstants()
        {
            _workTimeSystemId = Program.TimeTypes.FirstOrDefault(i => i.Name == "Worked")?.SystemId == null
                                            ? Guid.Empty :
                                            Program.TimeTypes.FirstOrDefault(i => i.Name == "Worked").SystemId;

            _invoiceWorkTimeSystemId = Program.TimeStatuses?.FirstOrDefault(i => i.Name == "Invoiced")?.SystemId == null
                                            ? Guid.Empty :
                                            Program.TimeStatuses.FirstOrDefault(i => i.Name == "Invoiced").SystemId;
        }
        public async Task<List<Time>> GetAll()
        {

            var method = "getalltime";
            string response = await _connectToApi.GetData(method, new Dictionary<string, string>());

            var result = JsonConvert.DeserializeObject<List<Time>>(response);

            return result;
        }
        public async Task<List<Time>> AddOrUpdate(Time item)
        {
            var method = "addtime";

            string response = await _connectToApi.PostData(method, JsonConvert.SerializeObject(item), new Dictionary<string, string>());

            var result = JsonConvert.DeserializeObject<List<Time>>(response);

            return result;
        }

        public decimal GetHours(int minutes)
        {
            return (decimal)minutes / 60;
        }
        public int GetMinutesFromHours(decimal hours)
        {
            return (int)(hours * 60);
        }

        public bool IsValidForInvoicing(DateTime dtFrom, DateTime dtTo, Time time)
        {
            
            if (time.TimeTypeSystemId==_workTimeSystemId && dtFrom <= time.TimeFrom && dtTo >= time.TimeFrom)
                return true;
            return false;
        }

        public async void Invoice(Time time)
        {
            time.TimeStatusSystemId = _invoiceWorkTimeSystemId;
            await AddOrUpdate(time);
        }
    }
}
