using PilotDesktop.CodeGenerator.Models;
using PilotDesktop.General.Services;
using static PilotDesktop.General.Services.CodeGeneratorService;

namespace PilotDesktop.Forms
{
    public partial class CodeGenerator : Form
    {
        public CodeGenerator()
        {
            InitializeComponent();

            ToolContainer.Visible = false;
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

        private void radioType_CheckedChanged(object sender, EventArgs e)
        {
            OnFormStateChanged();
        }

        private void OnFormStateChanged()
        {
            SetGlobalVariables();
            ToggleRightPanel();
            UpdateTaskList();
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
            UpdateTaskList();
            if (ToolContainer.Panel2Collapsed)
            {
                ToggleRightPanel();
            }
        }

        private void ChoosePNLitiumProjectFolder(bool openRightPane = false)
        {
            var dialog = new FolderBrowserDialog();
            DialogResult result = dialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                var srcDir = FilesAndFolderService.CheckPNLitiumDir(new DirectoryInfo(dialog.SelectedPath));
                if (srcDir == null)
                {
                    ToolContainer.Visible = false;
                    lblFolderError.Text = "Projektet ser inte ut att innehålla Pandonexis Addons mapp? \nVänligen prova igen... :)";
                }
                else
                {
                    CodeGeneratorItem.ProjectDirectory = srcDir;
                    CodeGeneratorItem.PathProject = srcDir.FullName;
                    ToolContainer.BringToFront();

                    ToolContainer.Visible = true;
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
            if (Directory.Exists(Path.Combine(CodeGeneratorItem.PathProject, CodeGeneratorConstants.PathDestinationPnAddonsExtensions, str)))
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
                SetNewLine("Typ: " + type);
            }


            if (checkBoxStyling.Checked)
            {           
                if (isCreate)
                {
                    CreateStylingStructure();
                }
                SetNewLine("SASS-struktur", isCreate);
            }

            if (checkBoxREACT.Checked)
            {
                SetNewLine("REACT-struktur");
                if (checkBoxREACT_Reducers.Checked)
                {
                    SetNewLine("   ...med Reducers");
                }
                if (checkBoxREACT_API.Checked)
                {
                    SetNewLine("   ...med API-Cntr");
                }
            }

            if (checkBoxBuilders.Checked)
            {
                SetNewLine("Builders-grund");
            }
            if (checkBoxViewModels.Checked)
            {
                SetNewLine("ViewModel-grund");
            }
            if (checkBoxServices.Checked)
            {
                SetNewLine("Service-grund");
            }
            if (checkBoxPageTemplate.Checked)
            {
                SetNewLine("Sidmall-grund");
            }
            if (checkBoxConstants.Checked)
            {
                SetNewLine("Konstanter-grund");
            }
            if (checkBoxNewFields.Checked)
            {
                SetNewLine("Nya Fält-grund");
            }
            if (checkBoxWebsiteSettings.Checked)
            {
                SetNewLine("WebsiteSettings-grund");
            }
        }

        private void SetNewLine(string text, bool isCreate = false, bool isHighlight = false)
        {   
            if (isHighlight)
            {
                TaskList.SelectionFont = new Font(TaskList.Font, FontStyle.Bold);
                TaskList.SelectionColor = Color.Gold;
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

            if (radioNone.Checked)
            {
                CodeGeneratorItem.AddonType = "Varken block eller sida";
                CodeGeneratorItem.MainType = "None";
            }
            else if (radioPage.Checked)
            {
                CodeGeneratorItem.AddonType = "Sidamall/Vy";
                CodeGeneratorItem.MainType = "Page";
            }
            else if (radioBlock.Checked)
            {
                CodeGeneratorItem.AddonType = CodeGeneratorItem.MainType = "Block";
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
            CodeGeneratorItem.PlaceInSolution = checkBoxIsSolution.Checked;
        }
    }
}