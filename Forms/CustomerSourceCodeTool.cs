﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PilotDesktop.Settings.Constants;
using PilotDesktop.SourceCode.Services;

namespace PilotDesktop.Forms
{
    public partial class CustomerSourceCodeTool : Form
    {
        private readonly SourceCodeProjectService _sourceCodeProjectService;
        private readonly string _projectName;
        public CustomerSourceCodeTool(string projectName)
        {
            InitializeComponent();
            _sourceCodeProjectService = new SourceCodeProjectService();
            _projectName = projectName;
        }


        private void CreateProject(string masterProjectPath, string createProjectPath)
        {
            var masterProjectDirectoryPath = Path.GetDirectoryName(masterProjectPath);
            if (!Directory.Exists(createProjectPath))
            {
                Directory.CreateDirectory(createProjectPath);
            }
            FoldersAndFilesHelper.CopyFiles(masterProjectDirectoryPath, createProjectPath);
            FoldersAndFilesHelper.CreateSubFolders(masterProjectDirectoryPath, createProjectPath);
            _sourceCodeProjectService.CreateSlnFile(masterProjectPath, createProjectPath);
            _sourceCodeProjectService.CreateAddonProject(masterProjectDirectoryPath, createProjectPath);
            _sourceCodeProjectService.CreateSolutionProject(masterProjectDirectoryPath, createProjectPath);
        }
        private void AddAddOn(string masterProjectPath, string createProjectPath)
        {
            var masterProjectDirectoryPath = Path.GetDirectoryName(masterProjectPath);

            _sourceCodeProjectService.AddAddonToProject(masterProjectDirectoryPath,
                                                        createProjectPath);
        }
        private void bAddAddon_Click(object sender, EventArgs e)
        {
            AddAddOn(Program._pilotApplicationSettings.Settings[PilotApplicationSettingsConstants.MasterProject],
                          Path.Combine(Program._pilotApplicationSettings.Settings[PilotApplicationSettingsConstants.ProjectFolder], _projectName));
        }

        private void bCreateProject_Click(object sender, EventArgs e)
        {
            CreateProject(Program._pilotApplicationSettings.Settings[PilotApplicationSettingsConstants.MasterProject], 
                            Path.Combine(Program._pilotApplicationSettings.Settings[PilotApplicationSettingsConstants.ProjectFolder], _projectName));
        }
    }
}
