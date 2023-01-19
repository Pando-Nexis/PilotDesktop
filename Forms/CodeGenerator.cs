using PilotDesktop.General.Services;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using static PilotDesktop.General.Services.CodeGeneratorService;
using static PilotDesktop.Program;
using static System.Environment;

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

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void lblTest_Click(object sender, EventArgs e)
        {

        }

        private void browseProjFolder_HelpRequest(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            ChoosePNLitiumProjectFolder();
        }


        private void button1_Click_2(object sender, EventArgs e)
        {
            ChoosePNLitiumProjectFolder();
        }

        private void ToolContainer_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblBtnChoosNewProj_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void lblBtnChoosNewProj_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ChoosePNLitiumProjectFolder(true);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void PNAddonId_TextChanged(object sender, EventArgs e)
        {
            if (!Global.ignoreChange)
            {
                lblAddonName.Text = "PN" + StringService.FixStringPascalCase(PNAddonId.Text);
                ValidateName(lblAddonName.Text);
            }
            Global.ignoreChange = false;
        }

        private void PNAddonId_Leave(object sender, EventArgs e)
        {
            var tempPascalCaseText = StringService.FixStringPascalCase(PNAddonId.Text);
            ValidateName(tempPascalCaseText);
            PNAddonId.Text = tempPascalCaseText;
            lblAddonName.Text = "PN" + tempPascalCaseText;

        }
        private void AddonType_Enter(object sender, EventArgs e)
        {

        }

        private void radioNone_CheckedChanged(object sender, EventArgs e)
        {
            SetGlobalVariables();
            ToggleRightPanel();
            UpdateTaskList();
        }

        private void radioPage_CheckedChanged(object sender, EventArgs e)
        {
            SetGlobalVariables();
            ToggleRightPanel();
            UpdateTaskList();
        }

        private void radioBlock_CheckedChanged(object sender, EventArgs e)
        {
            SetGlobalVariables();
            ToggleRightPanel();
            UpdateTaskList();
        }

        private void button1_Click_3(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("Alla Addonfiler kommer nu att skapas upp i projektet...",
                                     "Bekräfta för att forsätta... :)",
                                     MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                UpdateTaskList(true);
            }
        }

        private void checkBoxREACT_CheckedChanged(object sender, EventArgs e)
        {
            checkBoxREACT_Reducers.Enabled = checkBoxREACT.Checked;
            checkBoxREACT_API.Enabled = checkBoxREACT.Checked;

            UpdateTaskList();
        }

        private void checkBoxStyling_CheckedChanged(object sender, EventArgs e)
        {
            UpdateTaskList();
        }

        private void checkBoxToggleAll_CheckedChanged(object sender, EventArgs e)
        {
            var state = checkBoxToggleAll.Checked;

            foreach (Control cont in groupBoxProj.Controls)
            {
                ((CheckBox)cont).Checked = state;
            }
        }

        private void checkBoxREACT_Reducers_CheckedChanged(object sender, EventArgs e)
        {
            UpdateTaskList();
        }

        private void checkBoxREACT_API_CheckedChanged(object sender, EventArgs e)
        {
            UpdateTaskList();
        }

        private void checkBoxBuilders_CheckedChanged(object sender, EventArgs e)
        {
            UpdateTaskList();
        }

        private void checkBoxViewModels_CheckedChanged(object sender, EventArgs e)
        {
            UpdateTaskList();
        }

        private void checkBoxServices_CheckedChanged(object sender, EventArgs e)
        {
            UpdateTaskList();
        }

        private void checkBoxPageTemplate_CheckedChanged(object sender, EventArgs e)
        {
            UpdateTaskList();
        }

        private void checkBoxConstants_CheckedChanged(object sender, EventArgs e)
        {
            UpdateTaskList();
        }

        private void checkBoxNewFields_CheckedChanged(object sender, EventArgs e)
        {
            UpdateTaskList();
        }

        private void checkBoxWebsiteSettings_CheckedChanged(object sender, EventArgs e)
        {
            UpdateTaskList();
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
                    Global.ProjectDirectory = srcDir;
                    Global.PathProject = srcDir.FullName;
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
            ToolContainer.Panel2Collapsed = hidePanel;
            if (!hidePanel)
            {
                ToolContainer.Panel2.Show();
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
            if(Directory.Exists(Path.Combine(Global.PathProject, Global.PathDestinationPnAddonsExtensions, str)))
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
            var type = Global.AddonType ?? string.Empty;

            var addonName = lblAddonName.Text;// isCreate ? lblAddonName.Text : string.Empty;
            var addonNameKebabCase = StringService.ConvertStringToKebabCase(addonName); // isCreate ? ConvertStringToKebabCase(addonName) : string.Empty;
            
            TaskList.Clear();
           
            TaskList.SelectionBullet = true;

            if (!string.IsNullOrEmpty(type))
            {
                SetNewLine(type);
            }

            if (checkBoxStyling.Checked == true)
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


        private void SetNewLine(string text, bool isCreate = false)
        {
            TaskList.SelectionFont = new Font("Arial", 10);
            TaskList.SelectionColor = isCreate ? Color.LightGreen : Color.AntiqueWhite;
            TaskList.SelectedText = text + "\n";
        }
        
        private void SetGlobalVariables()
        {
            Global.AddonName = lblAddonName.Text;

            if (radioNone.Checked)
            {
                Global.AddonType = "Varken block eller sida";
                Global.MainType = "None";
            }
            else if (radioPage.Checked)
            {
                Global.AddonType = "Sidamall/Vy";
                Global.MainType = "Page";
            }
            else if (radioBlock.Checked)
            {
                Global.AddonType = Global.MainType = "Block";
            }

            Global.UseStyling = checkBoxStyling.Checked;
            Global.UseREACT = checkBoxStyling.Checked;
            Global.UseReducers = checkBoxREACT_Reducers.Checked;
            Global.UseApi = checkBoxREACT_API.Checked;
            Global.UseBuilders = checkBoxBuilders.Checked;
            Global.UseViewModels = checkBoxViewModels.Checked;
            Global.UseServices = checkBoxServices.Checked;
            Global.UsePageTemplate = checkBoxPageTemplate.Checked;
            Global.UseConstants = checkBoxConstants.Checked;
            Global.UseNewFields = checkBoxNewFields.Checked;
            Global.UseNewWebsiteSettings = checkBoxWebsiteSettings.Checked;
        }

        
    }
}

//PNAddonTemp 	// Replace
//pn-addon-temp // Replace CamelCase
//pn_addonTemp 	// Replace first letter small
//pn_addon_temp	// Replace all letters small