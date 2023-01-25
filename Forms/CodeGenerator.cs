using PilotDesktop.CodeGenerator.Models;
using PilotDesktop.General.Services;
using PilotDesktop.Settings.Constants;
using PilotDesktop.SourceCode.Constants;
using static PilotDesktop.General.Services.CodeGeneratorService;

namespace PilotDesktop.Forms
{
    public partial class CodeGenerator : Form
    {
        public CodeGenerator()
        {
            InitializeComponent();

            ToolContainer.Visible = false;
            panel_PNChooseFolder.Visible = true;
            ToolContainer.Panel2Collapsed = true;
            ToolContainer.Panel2.Hide();
            checkBoxREACT_Reducers.Enabled = false;
            checkBoxREACT_API.Enabled = false;
            btnCreate.Enabled = false;
            SetTemplatePath();
        }

        private void SelectDir_Load(object sender, EventArgs e)
        {
            lblFolderError.Text = "";
        }

        #region Events
        private void lblBtnChoosNewProj_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ChoosePNLitiumProjectFolder(true);
        }

        private void PNAddonId_TextChanged(object sender, EventArgs e)
        {
            if (!CodeGeneratorItem.ignoreChange)
            {

                var addonName = "PN" + StringService.FixStringPascalCase(PNAddonId.Text);
                lblAddonName.Text = addonName;
                CodeGeneratorItem.AddonName = addonName;
                ValidateName(addonName);
            }
            CodeGeneratorItem.ignoreChange = false;
            if (ToolContainer.Panel2Collapsed)
            {
                ToggleRightPanel();
            }
        }

        private void PNAddonId_Leave(object sender, EventArgs e)
        {
            var tempPascalCaseText = StringService.FixStringPascalCase(PNAddonId.Text);
            ValidateName(tempPascalCaseText);
            PNAddonId.Text = tempPascalCaseText;
            lblAddonName.Text = "PN" + tempPascalCaseText;

        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("ADDON '" + CodeGeneratorItem.AddonName + "' och alla dess filer kommer nu att skapas upp i projektet...",
                                     "Bekräfta för att forsätta skapa ADDON med namn '" + CodeGeneratorItem.AddonName + "'... :)",
                                     MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                UpdateTaskList(true);
            }
        }

        private void btnChooseProj_Click(object sender, EventArgs e)
        {
            ChoosePNLitiumProjectFolder();
        }

        private void checkBoxREACT_CheckedChanged(object sender, EventArgs e)
        {
            checkBoxREACT_Reducers.Enabled = checkBoxREACT.Checked;
            checkBoxREACT_API.Enabled = checkBoxREACT.Checked;

            UpdateTaskList();
            if (ToolContainer.Panel2Collapsed)
            {
                ToggleRightPanel();
            }
        }

        private void checkBoxStyling_CheckedChanged(object sender, EventArgs e)
        {
            UpdateTaskList();
            if (ToolContainer.Panel2Collapsed)
            {
                ToggleRightPanel();
            }
        }
        private void checkBoxToggleAll_CheckedChanged(object sender, EventArgs e)
        {
            var state = checkBoxToggleAll.Checked;

            foreach (Control cont in groupBoxProj.Controls)
            {
                ((CheckBox)cont).Checked = state;
            }
        }

        private void GeneralCheckedChanged(object sender, EventArgs e)
        {
            var chkBx = (CheckBox)sender;
            // Misc dependencies
            if (chkBx.Name == "checkBoxBuilders" && chkBx.Checked)
            {
                checkBoxViewModels.Checked = true;
                checkBoxConstants.Checked = true;
                return;
            }

            UpdateTaskList();
            if (ToolContainer.Panel2Collapsed)
            {
                ToggleRightPanel();
            }
        }
        private void checkBoxBlock_CheckedChanged(object sender, EventArgs e)
        {
            OnFormStateChanged();
        }

        #endregion Events


        private void OnFormStateChanged()
        {
            SetGlobalVariables();
            ToggleRightPanel();
            UpdateTaskList();
        }

        private void ChoosePNLitiumProjectFolder(bool openRightPane = false)
        {
            var dialog = new FolderBrowserDialog();
            //if (!dialog.SelectedPath.StartsWith(Program._pilotApplicationSettings.Settings[PilotApplicationSettingsConstants.ProjectFolder]))
            //    dialog.SelectedPath = Program._pilotApplicationSettings.Settings[PilotApplicationSettingsConstants.ProjectFolder];

            DialogResult result = dialog.ShowDialog();
            
            if (result == DialogResult.OK)
            {
                var srcDir = FilesAndFolderService.CheckPNLitiumDir(new DirectoryInfo(dialog.SelectedPath));
                if (srcDir == null)
                {
                    ToolContainer.Visible = false;
                    panel_PNChooseFolder.Visible = true;
                    lblFolderError.Text = "Projektet ser inte ut att innehålla Pandonexis Addons mapp? \nVänligen prova igen... :)";
                }
                else
                {
                    CodeGeneratorItem.ProjectDirectory = srcDir;
                    CodeGeneratorItem.PathProject = srcDir.FullName;
                    ToolContainer.BringToFront();
                    ToolContainer.Visible = true;
                    panel_PNChooseFolder.Visible = false;
                    if (!openRightPane)
                    {
                        ToolContainer.Panel2Collapsed = true;
                        ToolContainer.Panel2.Hide();
                    }
                    lblProjName.Text = srcDir.Parent.Name;
                    lblFolderError.Text = "";
                }
            }
        }
        private void ToggleRightPanel(bool hidePanel = false)
        {
            if (!hidePanel)
            {
                ToolContainer.Panel2.Show();
                ToolContainer.Panel2Collapsed = false;
            }
            else
            {
                ToolContainer.Panel2.Hide();
            }
        }
        private void ValidateName(string str)
        {
            labelErrNoAddonId.Visible = str.Length < 5;
            btnCreate.Enabled = str.Length > 4;
            // Check if exists in target project
            if (Directory.Exists(Path.Combine(CodeGeneratorItem.PathProject, ProjectConstants.AddOn, str)))
            {
                lblErrorAddonExistsInProject.Visible = true;
                btnCreate.Enabled = false;
            }
            else
            {
                lblErrorAddonExistsInProject.Visible = false;
                btnCreate.Enabled = true;
            }
        }

        private void UpdateTaskList(bool isCreate = false)
        {
            SetGlobalVariables();
            var type = CodeGeneratorItem.AddonType ?? string.Empty;
            var pnAddonExtensionsOptionList = new List<string>();
            var addonName = lblAddonName.Text;// isCreate ? lblAddonName.Text : string.Empty;
            var addonNameKebabCase = StringService.ConvertStringToKebabCase(addonName); // isCreate ? ConvertStringToKebabCase(addonName) : string.Empty;

            TaskList.Clear();

            TaskList.SelectionBullet = true;

            if (checkBoxIsSolution.Checked)
            {
                SetNewLine("Läggs i '_SOLUTION'", isCreate, true);
            }

            if (!string.IsNullOrEmpty(type))
            {
                SetNewLine("Typ: " + type, isCreate);
            }

            // Styling
            if (checkBoxStyling.Checked)
            {
                if (isCreate)
                {
                    var cssOptionList = new List<string>();
                    if (!CreateStructure(CodeGeneratorConstants.Path_StylesAddons, optionList:cssOptionList)) {
                        isCreate = false;
                        SetNewLine("SASS-struktur - ERROR", isCreate, isError : true);
                        return;
                    }
                }
                SetNewLine("SASS-struktur", isCreate);
            }
            // END Styling

            // REACT/JS
            if (checkBoxREACT.Checked)
            {
                var reactOptionList = new List<string>();

                SetNewLine("REACT-struktur", isCreate);
                if (checkBoxREACT_Reducers.Checked)
                {
                    SetNewLine("   ...med Reducers", isCreate);
                    AddToOptionsList(ref reactOptionList, "reducers");
                }
                
                if (checkBoxREACT_API.Checked)
                {
                    SetNewLine("   ...med API-Cntr", isCreate);
                    AddToOptionsList(ref reactOptionList, "Controllers\\Api");
                    AddToOptionsList(ref reactOptionList, "Actions");
                    if (isCreate && !CreateStructure(CodeGeneratorConstants.PathDestination_Api, optionList: reactOptionList))
                    {
                        isCreate = false;
                        SetNewLine("Controller-struktur API - ERROR", isCreate, isError: true);
                        return;
                    }
                }

                if (isCreate && !CreateStructure(CodeGeneratorConstants.Path_ScriptsAddons, optionList: reactOptionList))
                {
                    isCreate = false;
                    SetNewLine("JS-struktur - ERROR", isCreate, isError: true);
                    return;
                }
                // Add pandoNexis.js_merge
                AddToOptionsList(ref pnAddonExtensionsOptionList, FileTypeConstants.PandoNexisJsMerge);
            }
            // END REACT/JS


            var pnAddonMvcOptionList = new List<string>();
            if (checkBoxBuilders.Checked)
            {
                SetNewLine("Builders-grund", isCreate);                
                AddToOptionsList(ref pnAddonExtensionsOptionList, "Builders");
            }
            if (checkBoxViewModels.Checked)
            {
                SetNewLine("ViewModel-grund", isCreate);
                AddToOptionsList(ref pnAddonExtensionsOptionList, "ViewModels");
            }
            if (checkBoxServices.Checked)
            {
                SetNewLine("Service-grund", isCreate);
                AddToOptionsList(ref pnAddonExtensionsOptionList, "Services");
            }
            if (checkBoxPageTemplate.Checked)
            {
                SetNewLine("Sidmall-grund", isCreate);
                AddToOptionsList(ref pnAddonExtensionsOptionList, "Resources");
                AddToOptionsList(ref pnAddonExtensionsOptionList, "Definitions");
                AddToOptionsList(ref pnAddonExtensionsOptionList, "Pages");
                AddToOptionsList(ref pnAddonExtensionsOptionList, "PageTemplateSetup.cs");
                AddToOptionsList(ref pnAddonExtensionsOptionList, "Constants");
                AddToOptionsList(ref pnAddonExtensionsOptionList, "ViewModels");
                AddToOptionsList(ref pnAddonExtensionsOptionList, "views.txt");
                AddToOptionsList(ref pnAddonMvcOptionList, "Views");
            }
            if (checkBoxConstants.Checked)
            {
                SetNewLine("Konstanter-grund", isCreate);
                AddToOptionsList(ref pnAddonExtensionsOptionList, "Constants");
            }            
            if (checkBoxNewFields.Checked)
            {
                SetNewLine("Nya Fält-grund", isCreate);
                AddToOptionsList(ref pnAddonExtensionsOptionList, "Definitions");
                AddToOptionsList(ref pnAddonExtensionsOptionList, "Pages");
                AddToOptionsList(ref pnAddonExtensionsOptionList, "PageFieldDefinitionSetup.cs");
            }
            if (checkBoxWebsiteSettings.Checked)
            {
                SetNewLine("WebsiteSettings-grund", isCreate);
                AddToOptionsList(ref pnAddonExtensionsOptionList, "Definitions");
                AddToOptionsList(ref pnAddonExtensionsOptionList, "Websites");
                AddToOptionsList(ref pnAddonExtensionsOptionList, "Constants");
            }
            if (checkBoxWebsiteStrings.Checked)
            {
                SetNewLine("Websitesträngar-grund", isCreate);
                AddToOptionsList(ref pnAddonExtensionsOptionList, "Definitions");
                AddToOptionsList(ref pnAddonExtensionsOptionList, "WebsiteTexts");
            }

            // Create folder structure in PandoNexis:extensions.Addons Project
            // What folder is to be used? Block or ordinary?
            pnAddonExtensionsOptionList.Add((CodeGeneratorItem.MainType.Contains("Block") ? "PNBlock" : "") + addonName);
            if (isCreate && !CreateStructure(ProjectConstants.AddOn, optionList: pnAddonExtensionsOptionList))
            {
                isCreate = false;
                SetNewLine("Addons-Project - ERROR", isCreate, isError: true);
                return;
            }
            if (isCreate && pnAddonMvcOptionList.Count>0 && !CreateStructure(CodeGeneratorConstants.PathDestination_ViewsAddons, optionList: pnAddonMvcOptionList))
            {
                isCreate = false;
                SetNewLine("Addons-view - ERROR", isCreate, isError: true);
                return;
            }
        }

        /// <summary>
        /// Fill List of strings with name or part of unique pathways
        /// During rendering we look for and remove "pn_option_" from Folder/File-name
        /// For each Folder/File we look att the full Path and if name or path is found in the list, the folder/file is rendered
        /// </summary>
        /// <param name="optionsList"></param>
        /// <param name="value"></param>
        private void AddToOptionsList(ref List<string> optionsList, string value)
        {
            if(optionsList.Contains(value))
                return;
            optionsList.Add(value);
        }

        private void SetNewLine(string text, bool isCreate = false, bool isHighlight = false, bool isError = false)
        {   
            if (isHighlight)
            {
                TaskList.SelectionFont = new Font(TaskList.Font, FontStyle.Bold);
                TaskList.SelectionColor = Color.Gold;
            }
            else if (isError)
            {
                TaskList.SelectionFont = new Font(TaskList.Font, FontStyle.Bold);
                TaskList.SelectionColor = Color.Red;
            }
            else
            {
                TaskList.SelectionFont = new Font("Arial", 10);
                TaskList.SelectionColor = isCreate ? Color.LightGreen : Color.AntiqueWhite;
            }
            TaskList.SelectedText = text + "\n";
        }

        private void SetGlobalVariables()
        {
            CodeGeneratorItem.AddonName = lblAddonName.Text;
            
            if (checkBoxBlock.Checked)
            {
                CodeGeneratorItem.MainType = CodeGeneratorItem.MainType = "Block";
                CodeGeneratorItem.AddonType = "Detta gäller BLOCK";
            }
            else
            {
                CodeGeneratorItem.MainType = "None";
                CodeGeneratorItem.AddonType = "";
            }

            CodeGeneratorItem.UseStyling = checkBoxStyling.Checked;
            CodeGeneratorItem.UseREACT = checkBoxStyling.Checked;
            CodeGeneratorItem.UseReducers = checkBoxREACT_Reducers.Checked;
            CodeGeneratorItem.UseApi = checkBoxREACT_API.Checked;
            CodeGeneratorItem.UseBuilders = checkBoxBuilders.Checked;
            CodeGeneratorItem.UseViewModels = checkBoxViewModels.Checked;
            CodeGeneratorItem.UseServices = checkBoxServices.Checked;
            CodeGeneratorItem.UsePageTemplate = checkBoxPageTemplate.Checked;
            CodeGeneratorItem.UseConstants = checkBoxConstants.Checked;
            CodeGeneratorItem.UseNewFields = checkBoxNewFields.Checked;
            CodeGeneratorItem.UseNewWebsiteSettings = checkBoxWebsiteSettings.Checked;
            CodeGeneratorItem.UseSolutionInseadOfAddons = checkBoxIsSolution.Checked;
        }
    }
}