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
    public class ItemStatusService
    {
        private readonly ConnectToApi _connectToApi;
        public ItemStatusService()
        {
            _connectToApi = new ConnectToApi();
        }

        public async Task<List<ItemStatus>> GetAll()
        {

            var method = "getitemstatuses";
            string response = await _connectToApi.GetData(method, new Dictionary<string, string>());

            var result = JsonConvert.DeserializeObject<List<ItemStatus>>(response);

            return result;
        }
        public async Task<bool> AddOrUpdate(ItemStatus item)
        {
            var method = "addworkitem";
            
            string response = await _connectToApi.PostData(method, JsonConvert.SerializeObject(item) ,new Dictionary<string, string>());

            var result = JsonConvert.DeserializeObject<List<ItemStatus>>(response);

            return true;
        }
    }
}
