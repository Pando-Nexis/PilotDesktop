﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PilotDesktop.Pilot.Objects;
using PilotDesktop.Settings.Constants;
using PilotDesktop.SourceCode.Constants;
using PilotDesktop.SourceCode.Services;

namespace PilotDesktop.Forms
{
    public partial class CustomerSourceCodeTool : Form
    {
        private readonly SourceCodeProjectService _sourceCodeProjectService;
        private readonly PilotProject _project;
        private  List<string> _addons = new List<string>();
        public CustomerSourceCodeTool(PilotProject project)
        {
            InitializeComponent();
            _sourceCodeProjectService = new SourceCodeProjectService();
            _project = project;
            Text = $"Skapa eller uppdatera {_project.Name}";
        }


        private void CreateProject(string masterProjectPath, string createProjectPath)
        {
            if (string.IsNullOrEmpty(tbManuelAddon.Text))
            {
                _addons = _project.AddOns;
            }
            else
            {
                _addons.Add(tbManuelAddon.Text);
            }
            var masterProjectDirectoryPath = Path.GetDirectoryName(masterProjectPath);
            if (!Directory.Exists(createProjectPath))
            {
                Directory.CreateDirectory(createProjectPath);
            }
            FoldersAndFilesHelper.CopyFiles(masterProjectDirectoryPath, createProjectPath);
            FoldersAndFilesHelper.CreateSubFolders(masterProjectDirectoryPath, createProjectPath);
            _sourceCodeProjectService.CreateSlnFile(masterProjectPath, createProjectPath);
            _sourceCodeProjectService.CreateAddonProject(masterProjectDirectoryPath, createProjectPath, _addons);
            _sourceCodeProjectService.CreateSolutionProject(masterProjectDirectoryPath, createProjectPath);

            ProcessStartInfo processInfo;
            Process process;
            processInfo = new ProcessStartInfo("cmd.exe", "/K " + Path.Combine(createProjectPath, FolderConstants.Src, FileTypeConstants.BuildClientBat));
            processInfo.CreateNoWindow = true;
            processInfo.UseShellExecute = true;

            process = Process.Start(processInfo);

        }
        private void AddAddOn(string masterProjectPath, string createProjectPath)
        {
            if (string.IsNullOrEmpty(tbManuelAddon.Text))
            {
                _addons = _project.AddOns;
            }
            else
            {
                _addons.Add(tbManuelAddon.Text);
            }
            var masterProjectDirectoryPath = Path.GetDirectoryName(masterProjectPath);

            _sourceCodeProjectService.AddAddonToProject(masterProjectDirectoryPath, createProjectPath, _addons);
        }
        private void bAddAddon_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbManuelAddon.Text))
            {
                _addons = _project.AddOns;
            }
            else
            {
                _addons.Add(tbManuelAddon.Text);
            }
            Cursor.Current = Cursors.WaitCursor;

            AddAddOn(Program._pilotApplicationSettings.Settings[PilotApplicationSettingsConstants.MasterProject],
                          Path.Combine(Program._pilotApplicationSettings.Settings[PilotApplicationSettingsConstants.ProjectFolder], _project.Name));

            Cursor.Current = Cursors.Default;
        }

        private void bCreateProject_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            CreateProject(Program._pilotApplicationSettings.Settings[PilotApplicationSettingsConstants.MasterProject],
                            Path.Combine(Program._pilotApplicationSettings.Settings[PilotApplicationSettingsConstants.ProjectFolder], _project.Name));

            Cursor.Current = Cursors.Default;
        }
    }
}
