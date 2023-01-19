using PilotDesktop.Pilot.Services;
using PilotDesktop.SourceCode.Constants;
using PilotDesktop.SourceCode.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectAnalyser.Services
{
    public class AddOnService
    {
        public ConnectToApi _connectToApi;
        public AddOnService()
        {
            _connectToApi = new ConnectToApi();
        }
        public async Task<bool> IsRegistered(string AddOnId)
        {

            var parameters = new Dictionary<string, string>();
            parameters.Add("addonid", AddOnId);

            string result =  await _connectToApi.GetData("addonexists",parameters);
            return result=="true";
            
        }

        public async Task<bool> RegisterAddOn(string AddOnId)
        {

            var parameters = new Dictionary<string, string>();
            parameters.Add("addonid", AddOnId);

            string v = await _connectToApi.GetData("registeraddon", parameters);
            return !string.IsNullOrEmpty("");
        }

        public void GetAddonsForTreeView(string Name,string AddonProjectPath, ref TreeNode treeNode)
        {

            treeNode.Name= Name;
            treeNode.Tag = Path.Combine(AddonProjectPath, Name);
            treeNode.Text= Name;
            var addOnSourceNode = new TreeNode();
            addOnSourceNode.Text = Path.Combine(ProjectConstants.AddOn, Name);
            FoldersAndFilesHelper.GetFoldersAndFilesForTreeView(Path.Combine(AddonProjectPath, Name), ref addOnSourceNode);


            treeNode.Nodes.Add(addOnSourceNode);
        }
        
    }
}
