using Newtonsoft.Json;
using PilotDesktop.Forms;
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
    public class WorkItemService
    {
        private readonly ConnectToApi _connectToApi;
        public WorkItemService()
        {
            _connectToApi = new ConnectToApi();
        }

        public async Task<List<WorkItem>> GetAll()
        {

            var method = "getworkitems";
            string response = await _connectToApi.GetData(method, new Dictionary<string, string>());

            var result = JsonConvert.DeserializeObject<List<WorkItem>>(response);

            return result;
        }
        public async Task<List<WorkItem>> AddOrUpdate(WorkItem item)
        {
            var method = "addworkitem";

            string response = await _connectToApi.PostData(method, JsonConvert.SerializeObject(item), new Dictionary<string, string>());

            var result = JsonConvert.DeserializeObject<List<WorkItem>>(response);
            if (result != null)
            {
                return result;
            }
            else
                return null;
        }
        public Time GetEstimatedTime(Guid workItemSystemId, ref List<Time> times)
        {
            var estimateSystemId = Program.TimeTypes.FirstOrDefault(i => i.Name == "Estimated")?.SystemId ?? Guid.Empty;
            return Program.Times.FirstOrDefault(i => i.ItemSystemId == workItemSystemId && i.TimeTypeSystemId == estimateSystemId) ?? new Time() { ItemSystemId = workItemSystemId, TimeTypeSystemId = estimateSystemId };
        }

        public List<Time> GetWorkedTime(Guid workItemSystemId, ref List<Time> times)
        {
            var workedSystemId = Program.TimeTypes.FirstOrDefault(i => i.Name == "Worked")?.SystemId ?? Guid.Empty;
            return Program.Times.Where(i => i.ItemSystemId == workItemSystemId && i.TimeTypeSystemId == workedSystemId).ToList() ?? new List<Time>();
        }
        public List<Time> GetInvoicedTime(Guid workItemSystemId, ref List<Time> times)
        {
            var invoiceSystemId = Program.TimeTypes.FirstOrDefault(i => i.Name == "Invoice")?.SystemId ?? Guid.Empty;
            return Program.Times.Where(i => i.ItemSystemId == workItemSystemId && i.TimeTypeSystemId == invoiceSystemId).ToList() ?? new List<Time>();
        }
        public List<Time> GetWorkedTimeInvoiced(Guid workItemSystemId, ref List<Time> times)
        {
            var workedSystemId = Program.TimeTypes.FirstOrDefault(i => i.Name == "Worked")?.SystemId ?? Guid.Empty;
            var invoicedSystemId = Program.TimeStatuses.FirstOrDefault(i => i.Name == "Invoiced")?.SystemId ?? Guid.Empty;
            return Program.Times.Where(i => i.ItemSystemId == workItemSystemId && i.TimeTypeSystemId == workedSystemId&& i.TimeStatusSystemId==invoicedSystemId).ToList() ?? new List<Time>();
        }
        public int GetSumWorkedTime(Guid workItemSystemId, ref List<Time> times)
        {
            return GetWorkedTime(workItemSystemId, ref times).Sum(i => i.Amount);
        }
        public int GetSumWorkedTime(Guid workItemSystemId, ref List<Time> times, DateTime dateFrom, DateTime dateTo)
        {
            return GetWorkedTime(workItemSystemId, ref times).Where(i => i.TimeFrom >= dateFrom && i.TimeFrom <= dateTo).Sum(i => i.Amount);
        }
        public int GetSumWorkedTimeInvoiced(Guid workItemSystemId, ref List<Time> times, DateTime dateFrom, DateTime dateTo)
        {
            return GetWorkedTimeInvoiced(workItemSystemId, ref times).Where(i => i.TimeFrom >= dateFrom && i.TimeFrom <= dateTo).Sum(i => i.Amount);
        }
        public List<WorkItem> GetWorkItemsForTimePeriod(DateTime dateFrom, DateTime dateTo)
        {
            var workedSystemId = Program.TimeTypes.FirstOrDefault(i => i.Name == "Worked")?.SystemId ?? Guid.Empty;

            var workItemsId = Program.Times
                                    .Where(i => i.TimeTypeSystemId == workedSystemId && i.TimeFrom >= dateFrom && i.TimeFrom <= dateTo)
                                    .Select(j => j.ItemSystemId)
                                    .Distinct();

            return (from workItemId in workItemsId
                    let workItem = Program.WorkItems.List.FirstOrDefault(i => i.SystemId == workItemId)
                    where workItem != null
                    select workItem).ToList();
        }

        internal ListViewItem.ListViewSubItem GetProjectName(WorkItem item)
        {
            throw new NotImplementedException();
        }

        public WorkItem Get(Guid SystemID)
        {
            return Program.WorkItems?.List?.FirstOrDefault(i => i.SystemId == SystemID);
        }
    }
}
