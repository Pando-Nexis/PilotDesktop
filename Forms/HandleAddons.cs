using PilotDesktop.Settings.Constants;
using PilotDesktop.Settings.Objects;
using PilotDesktop.SourceCode.Constants;
using PilotDesktop.SourceCode.Services;
using ProjectAnalyser.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PilotDesktop.Forms
{
    public partial class HandleAddons : Form
    {
        private readonly SourceCodeProjectService _sourceCodeProjectService;
        private readonly PilotApplicationSettings _pilotApplicationSettings;
        private readonly AddOnService _addOnService;


        public HandleAddons()
        {
            InitializeComponent();
            _sourceCodeProjectService = new SourceCodeProjectService();
            _pilotApplicationSettings = Program._pilotApplicationSettings;
            _addOnService = new AddOnService();
        }

        private void LoadAddons()
        {
            var addonProjectPath = FoldersAndFilesHelper.GetFolderPath(_pilotApplicationSettings.Settings[PilotApplicationSettingsConstants.MasterProject]);
            addonProjectPath = Path.Combine(addonProjectPath, FolderConstants.Src, ProjectConstants.AddOn);

            var addons = _sourceCodeProjectService.GetAddons(addonProjectPath);

            foreach (var addon in addons)
            {
                var treeNode = new TreeNode();
                _addOnService.GetAddonsForTreeView(addon, addonProjectPath, ref treeNode);
                tvAddons.Nodes.Add(treeNode);


            }
        }
        private async void Reggad(string addon)
        {
            if (await _addOnService.IsRegistered(addon))
            {
                bRegister.Text = "är registrerad";
                bRegister.Enabled = false;
            }
            else
            {
                bRegister.Text = "registrera addon";
                bRegister.Enabled = true;

            }

        }
        private void tvAddons_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (tvAddons.SelectedNode != null)
            {
                tbAddOn.Text = tvAddons.SelectedNode.Text;
                Reggad(tbAddOn.Text);
            }
        }

        private async void bRegister_Click(object sender, EventArgs e)
        {
            await _addOnService.RegisterAddOn(tbAddOn.Text);

            Reggad(tbAddOn.Text);
        }

        private void HandleAddons_Load(object sender, EventArgs e)
        {
            LoadAddons();
        }
    }
}
