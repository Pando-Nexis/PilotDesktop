using PilotDesktop.Pilot.Objects;
using PilotDesktop.Settings.Constants;
using PilotDesktop.SourceCode.Services;

namespace PilotDesktop.Forms
{
    public partial class CustomerSourceCodeTool : Form
    {
        private readonly SourceCodeProjectService _sourceCodeProjectService;
        private readonly PilotProject _project;
        public CustomerSourceCodeTool(PilotProject project)
        {
            InitializeComponent();
            _sourceCodeProjectService = new SourceCodeProjectService();
            _project = project;
            Text = $"Skapa eller uppdatera {_project.Name}";
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
                          Path.Combine(Program._pilotApplicationSettings.Settings[PilotApplicationSettingsConstants.ProjectFolder], _project.Name));
        }

        private void bCreateProject_Click(object sender, EventArgs e)
        {
            CreateProject(Program._pilotApplicationSettings.Settings[PilotApplicationSettingsConstants.MasterProject], 
                            Path.Combine(Program._pilotApplicationSettings.Settings[PilotApplicationSettingsConstants.ProjectFolder], _project.Name));
        }
    }
}
