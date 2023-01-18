using Newtonsoft.Json;
using PilotDesktop.Pilot.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PilotDesktop.Pilot.Services
{
    public class PilotCustomerService
    {
        private readonly ConnectToApi _connectToApi;
        public PilotCustomerService()
        {

            _connectToApi = new ConnectToApi();

        }
        public async Task<List<PilotCustomer>> GetCustomers()
        {

            var method = "getcustomers";
            string response = await _connectToApi.GetData(method, new Dictionary<string, string>());

            var result = JsonConvert.DeserializeObject<List<PilotCustomer>>(response);

            return result;
        }

    }
}