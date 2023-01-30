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
    public class ItemTypeService
    {
        private readonly ConnectToApi _connectToApi;
        public ItemTypeService()
        {
            _connectToApi = new ConnectToApi();
        }

        public async Task<List<ItemType>> GetAll()
        {

            var method = "getitemtypes";
            string response = await _connectToApi.GetData(method, new Dictionary<string, string>());

            var result = JsonConvert.DeserializeObject<List<ItemType>>(response);

            return result;
        }
        public async Task<bool> AddOrUpdate(ItemType item)
        {
            var method = "addworkitem";
            
            string response = await _connectToApi.PostData(method, JsonConvert.SerializeObject(item) ,new Dictionary<string, string>());

            var result = JsonConvert.DeserializeObject<List<ItemType>>(response);

            return true;
        }
    }
}
