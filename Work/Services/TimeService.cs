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
        public TimeService()
        {
            _connectToApi = new ConnectToApi();
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
            
            string response = await _connectToApi.PostData(method, JsonConvert.SerializeObject(item) ,new Dictionary<string, string>());

            var result = JsonConvert.DeserializeObject<List<Time>>(response);

            return result;
        }

        public decimal GetHours(int minutes)
        {
            return minutes / 60;
        }
        public int GetMinutesFromHours(decimal hours)
        {
            return (int)hours*60;
        }
       
    }
}
