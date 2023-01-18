using PilotDesktop.Settings.Constants;
using PilotDesktop.Settings.Objects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PilotDesktop.Settings.Services;

namespace PilotDesktop.Forms
{
    public partial class Settings : Form
    {
        private readonly PilotApplicationSettingsService _pilotApplicationSettingsService;
        public Settings()
        {
            InitializeComponent();
            _pilotApplicationSettingsService = new PilotApplicationSettingsService();
        }

        private void bSave_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(tbProjectFolder.Text))
            {
                if (Program._pilotApplicationSettings.Settings.ContainsKey(PilotApplicationSettingsConstants.ProjectFolder))
                    Program._pilotApplicationSettings.Settings[PilotApplicationSettingsConstants.ProjectFolder] = tbProjectFolder.Text;
                else
                    Program._pilotApplicationSettings.Settings.Add(PilotApplicationSettingsConstants.ProjectFolder, tbProjectFolder.Text);
            }

            if (!string.IsNullOrWhiteSpace(tbMasterProject.Text))
            {
                if (Program._pilotApplicationSettings.Settings.ContainsKey(PilotApplicationSettingsConstants.MasterProject))
                    Program._pilotApplicationSettings.Settings[PilotApplicationSettingsConstants.MasterProject] = tbMasterProject.Text;
                else
                    Program._pilotApplicationSettings.Settings.Add(PilotApplicationSettingsConstants.MasterProject, tbMasterProject.Text);
            }

            if (!string.IsNullOrWhiteSpace(tbBaseUrl.Text))
            {
                if (Program._pilotApplicationSettings.Settings.ContainsKey(PilotApplicationSettingsConstants.BaseUrl))
                    Program._pilotApplicationSettings.Settings[PilotApplicationSettingsConstants.BaseUrl] = tbBaseUrl.Text;
                else
                    Program._pilotApplicationSettings.Settings.Add(PilotApplicationSettingsConstants.BaseUrl, tbBaseUrl.Text);
            }

            if (!string.IsNullOrWhiteSpace(tbApiSecret.Text))
            {
                if (Program._pilotApplicationSettings.Settings.ContainsKey(PilotApplicationSettingsConstants.ApiSecret))
                    Program._pilotApplicationSettings.Settings[PilotApplicationSettingsConstants.ApiSecret] = tbApiSecret.Text;
                else
                    Program._pilotApplicationSettings.Settings.Add(PilotApplicationSettingsConstants.ApiSecret, tbApiSecret.Text);
            }

            _pilotApplicationSettingsService.SaveSettings(Program._pilotApplicationSettings);
            DialogResult = DialogResult.OK;
            Close();
        }
        private void LoadData()
        {
            if (Program._pilotApplicationSettings.Settings != null)
            {
                if (Program._pilotApplicationSettings.Settings.ContainsKey(PilotApplicationSettingsConstants.ProjectFolder))
                {
                    tbProjectFolder.Text = Program._pilotApplicationSettings.Settings[PilotApplicationSettingsConstants.ProjectFolder];
                    if (string.IsNullOrEmpty(tbProjectFolder.Text))
                        folderBrowserDialog1.SelectedPath = tbProjectFolder.Text;
                }
                if (Program._pilotApplicationSettings.Settings.ContainsKey(PilotApplicationSettingsConstants.MasterProject))
                {
                    tbMasterProject.Text = Program._pilotApplicationSettings.Settings[PilotApplicationSettingsConstants.MasterProject];
                    if (string.IsNullOrEmpty(tbMasterProject.Text))
                        openFileDialog1.FileName = tbMasterProject.Text;
                }

                if (Program._pilotApplicationSettings.Settings.ContainsKey(PilotApplicationSettingsConstants.BaseUrl))
                {
                    tbBaseUrl.Text = Program._pilotApplicationSettings.Settings[PilotApplicationSettingsConstants.BaseUrl];

                }

                if (Program._pilotApplicationSettings.Settings.ContainsKey(PilotApplicationSettingsConstants.ApiSecret))
                {
                    tbApiSecret.Text = Program._pilotApplicationSettings.Settings[PilotApplicationSettingsConstants.ApiSecret];

                }
            }
        }

        private void bSelectProjectFolder_Click(object sender, EventArgs e)
        {

            if (folderBrowserDialog1.ShowDialog(this) == DialogResult.OK)
            {
                tbProjectFolder.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void bMasterProject_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog(this) == DialogResult.OK)
            {
                tbMasterProject.Text = openFileDialog1.FileName;
            }
        }

        private void Settings_Load(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
