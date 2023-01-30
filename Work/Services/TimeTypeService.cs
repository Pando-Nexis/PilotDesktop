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
    public class TimeTypeService
    {
        private readonly ConnectToApi _connectToApi;
        public TimeTypeService()
        {
            _connectToApi = new ConnectToApi();
        }

        public async Task<List<TimeType>> GetAll()
        {

            var method = "gettimetypes";
            string response = await _connectToApi.GetData(method, new Dictionary<string, string>());

            var result = JsonConvert.DeserializeObject<List<TimeType>>(response);

            return result;
        }
        //public async Task<bool> AddOrUpdate(TimeType item)
        //{
        //    var method = "addworkitem";
            
        //    string response = await _connectToApi.PostData(method, JsonConvert.SerializeObject(item) ,new Dictionary<string, string>());

        //    var result = JsonConvert.DeserializeObject<List<TimeType>>(response);

        //    return true;
        //}
    }
}
