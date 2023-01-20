using Newtonsoft.Json;
using PilotDesktop.Pilot.Objects;
using PilotDesktop.Pilot.Services;
using Solution.Extensions.PNPilot.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PilotDesktop.WorkItems.Services
{
    public class WorkItemService
    {
        private readonly ConnectToApi _connectToApi;
        public WorkItemService()
        {
            _connectToApi = new ConnectToApi();
        }

        public async Task<List<WorkItem>> GetWorkItems()
        {

            var method = "getworkitems";
            string response = await _connectToApi.GetData(method, new Dictionary<string, string>());

            var result = JsonConvert.DeserializeObject<List<WorkItem>>(response);

            return result;
        }
    }
}
