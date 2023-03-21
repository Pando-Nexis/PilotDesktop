using Newtonsoft.Json;
using PilotDesktop.Pilot.Objects;
using PilotDesktop.Work.Objects;
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
            
            return result.OrderBy(i=>i.Name).ToList();
        }
        public bool GetCustomerAndProject(WorkItem workItem, out PilotCustomer customer, out PilotProject project)
        {
            customer = null;
            project = null;
            return GetCustomerAndProject(Program.Customers, workItem.OrganizationSystemId, out customer, out project);
        }
        public bool GetCustomerAndProject(List<PilotCustomer> customers, Guid organizationSystemId, out PilotCustomer customer, out PilotProject project)
        {
            if (organizationSystemId != Guid.Empty)
            {
                foreach(var cust in customers)
                {
                    if (cust.SystemId== organizationSystemId)
                    {
                        customer = cust;
                        project = null;
                        return true;
                    }
                    foreach(var proj in cust.Projects)
                    {
                        if (proj.SystemId== organizationSystemId)
                        {
                            customer = cust;
                            project = proj;
                            return true;
                        }
                    }
                }
            }
            customer = null;
            project = null;
           return false;

        }

    }
}