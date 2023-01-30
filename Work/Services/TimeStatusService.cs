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
    public class TimeStatusService
    {
        private readonly ConnectToApi _connectToApi;
        public TimeStatusService()
        {
            _connectToApi = new ConnectToApi();
        }

        public async Task<List<TimeStatus>> GetAll()
        {

            var method = "gettimestatuses";
            string response = await _connectToApi.GetData(method, new Dictionary<string, string>());

            var result = JsonConvert.DeserializeObject<List<TimeStatus>>(response);

            return result;
        }
        //public async Task<bool> AddOrUpdate(WorkItem item)
        //{
        //    var method = "addworkitem";
            
        //    string response = await _connectToApi.PostData(method, JsonConvert.SerializeObject(item) ,new Dictionary<string, string>());

        //    var result = JsonConvert.DeserializeObject<List<TimeStatus>>(response);

        //    return true;
        //}
    }
}
