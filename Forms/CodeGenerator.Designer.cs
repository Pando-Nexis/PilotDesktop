namespace PilotDesktop.Forms
{
    partial class CodeGenerator
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CodeGenerator));
            this.projFolder = new System.Windows.Forms.FolderBrowserDialog();
            this.btnChooseProj = new System.Windows.Forms.Button();
            this.lblFolderError = new System.Windows.Forms.Label();
            this.panel_PNChooseFolder = new System.Windows.Forms.Panel();
            this.ToolContainer = new System.Windows.Forms.SplitContainer();
            this.LeftToolPanel = new System.Windows.Forms.Panel();
            this.ProjNameBar = new System.Windows.Forms.Panel();
            this.lblBtnChoosNewProj = new System.Windows.Forms.LinkLabel();
            this.lblProjName = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.checkBoxStyling = new System.Windows.Forms.CheckBox();
            this.checkBoxREACT = new System.Windows.Forms.CheckBox();
            this.groupBoxProj = new System.Windows.Forms.GroupBox();
            this.checkBoxWebsiteSettings = new System.Windows.Forms.CheckBox();
            this.checkBoxToggleAll = new System.Windows.Forms.CheckBox();
            this.checkBoxNewFields = new System.Windows.Forms.CheckBox();
            this.checkBoxConstants = new System.Windows.Forms.CheckBox();
            this.checkBoxPageTemplate = new System.Windows.Forms.CheckBox();
            this.checkBoxServices = new System.Windows.Forms.CheckBox();
            this.checkBoxViewModels = new System.Windows.Forms.CheckBox();
            this.checkBoxBuilders = new System.Windows.Forms.CheckBox();
            this.groupBoxREACT = new System.Windows.Forms.GroupBox();
            this.checkBoxREACT_API = new System.Windows.Forms.CheckBox();
            this.checkBoxREACT_Reducers = new System.Windows.Forms.CheckBox();
            this.AddonType = new System.Windows.Forms.GroupBox();
            this.radioNone = new System.Windows.Forms.RadioButton();
            this.radioBlock = new System.Windows.Forms.RadioButton();
            this.radioPage = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblErrorAddonExistsInProject = new System.Windows.Forms.Label();
            this.labelErrNoAddonId = new System.Windows.Forms.Label();
            this.PNAddonId = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.RightToolPanel = new System.Windows.Forms.Panel();
            this.btnCreate = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.lblAddonName = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.TaskList = new System.Windows.Forms.RichTextBox();
            this.panel_PNChooseFolder.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ToolContainer)).BeginInit();
            this.ToolContainer.Panel1.SuspendLayout();
            this.ToolContainer.Panel2.SuspendLayout();
            this.ToolContainer.SuspendLayout();
            this.LeftToolPanel.SuspendLayout();
            this.ProjNameBar.SuspendLayout();
            this.groupBoxProj.SuspendLayout();
            this.groupBoxREACT.SuspendLayout();
            this.AddonType.SuspendLayout();
            this.panel1.SuspendLayout();
            this.RightToolPanel.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // projFolder
            // 
            // 
            // btnChooseProj
            // 
            this.btnChooseProj.AccessibleName = "";
            this.btnChooseProj.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.btnChooseProj.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnChooseProj.BackColor = System.Drawing.Color.Transparent;
            this.btnChooseProj.BackgroundImage = global::PilotDesktop.Properties.Resources.GlassButton2;
            this.btnChooseProj.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnChooseProj.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnChooseProj.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnChooseProj.FlatAppearance.BorderSize = 0;
            this.btnChooseProj.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Navy;
            this.btnChooseProj.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btnChooseProj.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnChooseProj.ForeColor = System.Drawing.Color.AntiqueWhite;
            this.btnChooseProj.Location = new System.Drawing.Point(288, 190);
            this.btnChooseProj.Name = "btnChooseProj";
            this.btnChooseProj.Size = new System.Drawing.Size(197, 74);
            this.btnChooseProj.TabIndex = 2;
            this.btnChooseProj.Text = "Välj PN-Litium projekt";
            this.btnChooseProj.UseVisualStyleBackColor = false;
            // 
            // lblFolderError
            // 
            this.lblFolderError.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFolderError.BackColor = System.Drawing.Color.Transparent;
            this.lblFolderError.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblFolderError.Location = new System.Drawing.Point(3, 60);
            this.lblFolderError.Name = "lblFolderError";
            this.lblFolderError.Size = new System.Drawing.Size(794, 127);
            this.lblFolderError.TabIndex = 4;
            this.lblFolderError.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel_PNChooseFolder
            // 
            this.panel_PNChooseFolder.BackgroundImage = global::PilotDesktop.Properties.Resources.PandoNexisHero;
            this.panel_PNChooseFolder.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.panel_PNChooseFolder.Controls.Add(this.ToolContainer);
            this.panel_PNChooseFolder.Controls.Add(this.btnChooseProj);
            this.panel_PNChooseFolder.Controls.Add(this.lblFolderError);
            this.panel_PNChooseFolder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_PNChooseFolder.Location = new System.Drawing.Point(0, 0);
            this.panel_PNChooseFolder.Name = "panel_PNChooseFolder";
            this.panel_PNChooseFolder.Size = new System.Drawing.Size(800, 450);
            this.panel_PNChooseFolder.TabIndex = 5;
            // 
            // ToolContainer
            // 
            this.ToolContainer.BackColor = System.Drawing.Color.Transparent;
            this.ToolContainer.BackgroundImage = global::PilotDesktop.Properties.Resources.PandoNexisHeroDark;
            this.ToolContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ToolContainer.Location = new System.Drawing.Point(0, 0);
            this.ToolContainer.Name = "ToolContainer";
            // 
            // ToolContainer.Panel1
            // 
            this.ToolContainer.Panel1.AutoScroll = true;
            this.ToolContainer.Panel1.Controls.Add(this.LeftToolPanel);
            // 
            // ToolContainer.Panel2
            // 
            this.ToolContainer.Panel2.Controls.Add(this.RightToolPanel);
            this.ToolContainer.Size = new System.Drawing.Size(800, 450);
            this.ToolContainer.SplitterDistance = 623;
            this.ToolContainer.TabIndex = 5;
            this.ToolContainer.Visible = false;
            // 
            // LeftToolPanel
            // 
            this.LeftToolPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LeftToolPanel.BackColor = System.Drawing.Color.Transparent;
            this.LeftToolPanel.Controls.Add(this.ProjNameBar);
            this.LeftToolPanel.Controls.Add(this.checkBoxStyling);
            this.LeftToolPanel.Controls.Add(this.checkBoxREACT);
            this.LeftToolPanel.Controls.Add(this.groupBoxProj);
            this.LeftToolPanel.Controls.Add(this.groupBoxREACT);
            this.LeftToolPanel.Controls.Add(this.AddonType);
            this.LeftToolPanel.Controls.Add(this.panel1);
            this.LeftToolPanel.Location = new System.Drawing.Point(0, 0);
            this.LeftToolPanel.Name = "LeftToolPanel";
            this.LeftToolPanel.Size = new System.Drawing.Size(624, 450);
            this.LeftToolPanel.TabIndex = 4;
            // 
            // ProjNameBar
            // 
            this.ProjNameBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ProjNameBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.ProjNameBar.Controls.Add(this.lblBtnChoosNewProj);
            this.ProjNameBar.Controls.Add(this.lblProjName);
            this.ProjNameBar.Controls.Add(this.label2);
            this.ProjNameBar.Location = new System.Drawing.Point(0, 0);
            this.ProjNameBar.Name = "ProjNameBar";
            this.ProjNameBar.Size = new System.Drawing.Size(624, 34);
            this.ProjNameBar.TabIndex = 1;
            // 
            // lblBtnChoosNewProj
            // 
            this.lblBtnChoosNewProj.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblBtnChoosNewProj.AutoSize = true;
            this.lblBtnChoosNewProj.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.lblBtnChoosNewProj.Location = new System.Drawing.Point(462, 8);
            this.lblBtnChoosNewProj.Name = "lblBtnChoosNewProj";
            this.lblBtnChoosNewProj.Size = new System.Drawing.Size(149, 15);
            this.lblBtnChoosNewProj.TabIndex = 3;
            this.lblBtnChoosNewProj.TabStop = true;
            this.lblBtnChoosNewProj.Text = "Välj nytt PN-Litium-projekt";
            this.lblBtnChoosNewProj.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblProjName
            // 
            this.lblProjName.AutoSize = true;
            this.lblProjName.Font = new System.Drawing.Font("Papyrus", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.lblProjName.ForeColor = System.Drawing.Color.PowderBlue;
            this.lblProjName.Location = new System.Drawing.Point(144, 5);
            this.lblProjName.Name = "lblProjName";
            this.lblProjName.Size = new System.Drawing.Size(24, 25);
            this.lblProjName.TabIndex = 1;
            this.lblProjName.Text = "...";
            // 
            // label2
            // 
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(3, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(135, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Valt PN-Litium Projekt:";
            // 
            // checkBoxStyling
            // 
            this.checkBoxStyling.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxStyling.AutoSize = true;
            this.checkBoxStyling.ForeColor = System.Drawing.Color.White;
            this.checkBoxStyling.Location = new System.Drawing.Point(535, 144);
            this.checkBoxStyling.Name = "checkBoxStyling";
            this.checkBoxStyling.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.checkBoxStyling.Size = new System.Drawing.Size(67, 19);
            this.checkBoxStyling.TabIndex = 12;
            this.checkBoxStyling.Text = "?Styling";
            this.checkBoxStyling.UseVisualStyleBackColor = true;
            this.checkBoxStyling.CheckedChanged += new System.EventHandler(this.checkBoxStyling_CheckedChanged);
            // 
            // checkBoxREACT
            // 
            this.checkBoxREACT.AutoSize = true;
            this.checkBoxREACT.ForeColor = System.Drawing.Color.White;
            this.checkBoxREACT.Location = new System.Drawing.Point(22, 144);
            this.checkBoxREACT.Name = "checkBoxREACT";
            this.checkBoxREACT.Size = new System.Drawing.Size(66, 19);
            this.checkBoxREACT.TabIndex = 11;
            this.checkBoxREACT.Text = "REACT?";
            this.checkBoxREACT.UseVisualStyleBackColor = true;
            this.checkBoxREACT.CheckedChanged += new System.EventHandler(this.checkBoxREACT_CheckedChanged);
            // 
            // groupBoxProj
            // 
            this.groupBoxProj.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxProj.Controls.Add(this.checkBoxWebsiteSettings);
            this.groupBoxProj.Controls.Add(this.checkBoxToggleAll);
            this.groupBoxProj.Controls.Add(this.checkBoxNewFields);
            this.groupBoxProj.Controls.Add(this.checkBoxConstants);
            this.groupBoxProj.Controls.Add(this.checkBoxPageTemplate);
            this.groupBoxProj.Controls.Add(this.checkBoxServices);
            this.groupBoxProj.Controls.Add(this.checkBoxViewModels);
            this.groupBoxProj.Controls.Add(this.checkBoxBuilders);
            this.groupBoxProj.ForeColor = System.Drawing.Color.White;
            this.groupBoxProj.Location = new System.Drawing.Point(228, 171);
            this.groupBoxProj.Name = "groupBoxProj";
            this.groupBoxProj.Size = new System.Drawing.Size(384, 267);
            this.groupBoxProj.TabIndex = 9;
            this.groupBoxProj.TabStop = false;
            this.groupBoxProj.Text = "PandoNexis.AddOns.Extensions";
            // 
            // checkBoxWebsiteSettings
            // 
            this.checkBoxWebsiteSettings.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxWebsiteSettings.AutoSize = true;
            this.checkBoxWebsiteSettings.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.checkBoxWebsiteSettings.Location = new System.Drawing.Point(20, 182);
            this.checkBoxWebsiteSettings.Name = "checkBoxWebsiteSettings";
            this.checkBoxWebsiteSettings.Size = new System.Drawing.Size(143, 19);
            this.checkBoxWebsiteSettings.TabIndex = 8;
            this.checkBoxWebsiteSettings.Text = "Website-inställningar?";
            this.checkBoxWebsiteSettings.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.checkBoxWebsiteSettings.UseVisualStyleBackColor = true;
            this.checkBoxWebsiteSettings.CheckedChanged += new System.EventHandler(this.GeneralCheckedChanged);
            // 
            // checkBoxToggleAll
            // 
            this.checkBoxToggleAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxToggleAll.AutoSize = true;
            this.checkBoxToggleAll.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.checkBoxToggleAll.ForeColor = System.Drawing.Color.PeachPuff;
            this.checkBoxToggleAll.Location = new System.Drawing.Point(244, 19);
            this.checkBoxToggleAll.Name = "checkBoxToggleAll";
            this.checkBoxToggleAll.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.checkBoxToggleAll.Size = new System.Drawing.Size(129, 17);
            this.checkBoxToggleAll.TabIndex = 7;
            this.checkBoxToggleAll.Text = "Toggle all these boxes";
            this.checkBoxToggleAll.UseVisualStyleBackColor = true;
            this.checkBoxToggleAll.CheckedChanged += new System.EventHandler(this.checkBoxToggleAll_CheckedChanged);
            // 
            // checkBoxNewFields
            // 
            this.checkBoxNewFields.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxNewFields.AutoSize = true;
            this.checkBoxNewFields.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.checkBoxNewFields.Location = new System.Drawing.Point(170, 141);
            this.checkBoxNewFields.Name = "checkBoxNewFields";
            this.checkBoxNewFields.Size = new System.Drawing.Size(127, 19);
            this.checkBoxNewFields.TabIndex = 6;
            this.checkBoxNewFields.Text = "Nya Block/Sid-fält?";
            this.checkBoxNewFields.UseVisualStyleBackColor = true;
            this.checkBoxNewFields.CheckedChanged += new System.EventHandler(this.GeneralCheckedChanged);
            // 
            // checkBoxConstants
            // 
            this.checkBoxConstants.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxConstants.AutoSize = true;
            this.checkBoxConstants.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.checkBoxConstants.Location = new System.Drawing.Point(20, 141);
            this.checkBoxConstants.Name = "checkBoxConstants";
            this.checkBoxConstants.Size = new System.Drawing.Size(142, 19);
            this.checkBoxConstants.TabIndex = 5;
            this.checkBoxConstants.Text = "Använder Konstanter?";
            this.checkBoxConstants.UseVisualStyleBackColor = true;
            this.checkBoxConstants.CheckedChanged += new System.EventHandler(this.GeneralCheckedChanged);
            // 
            // checkBoxPageTemplate
            // 
            this.checkBoxPageTemplate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxPageTemplate.AutoSize = true;
            this.checkBoxPageTemplate.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.checkBoxPageTemplate.Location = new System.Drawing.Point(170, 103);
            this.checkBoxPageTemplate.Name = "checkBoxPageTemplate";
            this.checkBoxPageTemplate.Size = new System.Drawing.Size(143, 19);
            this.checkBoxPageTemplate.TabIndex = 4;
            this.checkBoxPageTemplate.Text = "Nya Sid/Sidmall/Vyer?";
            this.checkBoxPageTemplate.UseVisualStyleBackColor = true;
            this.checkBoxPageTemplate.CheckedChanged += new System.EventHandler(this.GeneralCheckedChanged);
            // 
            // checkBoxServices
            // 
            this.checkBoxServices.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxServices.AutoSize = true;
            this.checkBoxServices.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.checkBoxServices.Location = new System.Drawing.Point(20, 103);
            this.checkBoxServices.Name = "checkBoxServices";
            this.checkBoxServices.Size = new System.Drawing.Size(127, 19);
            this.checkBoxServices.TabIndex = 3;
            this.checkBoxServices.Text = "Använder Services?";
            this.checkBoxServices.UseVisualStyleBackColor = true;
            this.checkBoxServices.CheckedChanged += new System.EventHandler(this.GeneralCheckedChanged);
            // 
            // checkBoxViewModels
            // 
            this.checkBoxViewModels.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxViewModels.AutoSize = true;
            this.checkBoxViewModels.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.checkBoxViewModels.Location = new System.Drawing.Point(170, 64);
            this.checkBoxViewModels.Name = "checkBoxViewModels";
            this.checkBoxViewModels.Size = new System.Drawing.Size(149, 19);
            this.checkBoxViewModels.TabIndex = 2;
            this.checkBoxViewModels.Text = "Använder ViewModels?";
            this.checkBoxViewModels.UseVisualStyleBackColor = true;
            this.checkBoxViewModels.CheckedChanged += new System.EventHandler(this.GeneralCheckedChanged);
            // 
            // checkBoxBuilders
            // 
            this.checkBoxBuilders.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxBuilders.AutoSize = true;
            this.checkBoxBuilders.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.checkBoxBuilders.Location = new System.Drawing.Point(20, 64);
            this.checkBoxBuilders.Name = "checkBoxBuilders";
            this.checkBoxBuilders.Size = new System.Drawing.Size(130, 19);
            this.checkBoxBuilders.TabIndex = 1;
            this.checkBoxBuilders.Text = "Använder  Builders?";
            this.checkBoxBuilders.UseVisualStyleBackColor = true;
            this.checkBoxBuilders.CheckedChanged += new System.EventHandler(this.GeneralCheckedChanged);
            // 
            // groupBoxREACT
            // 
            this.groupBoxREACT.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBoxREACT.Controls.Add(this.checkBoxREACT_API);
            this.groupBoxREACT.Controls.Add(this.checkBoxREACT_Reducers);
            this.groupBoxREACT.ForeColor = System.Drawing.Color.White;
            this.groupBoxREACT.Location = new System.Drawing.Point(12, 171);
            this.groupBoxREACT.Name = "groupBoxREACT";
            this.groupBoxREACT.Size = new System.Drawing.Size(210, 267);
            this.groupBoxREACT.TabIndex = 8;
            this.groupBoxREACT.TabStop = false;
            this.groupBoxREACT.Text = "REACT";
            // 
            // checkBoxREACT_API
            // 
            this.checkBoxREACT_API.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxREACT_API.AutoSize = true;
            this.checkBoxREACT_API.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.checkBoxREACT_API.Location = new System.Drawing.Point(19, 103);
            this.checkBoxREACT_API.Name = "checkBoxREACT_API";
            this.checkBoxREACT_API.Size = new System.Drawing.Size(159, 19);
            this.checkBoxREACT_API.TabIndex = 1;
            this.checkBoxREACT_API.Text = "Använder API-controller?";
            this.checkBoxREACT_API.UseVisualStyleBackColor = true;
            this.checkBoxREACT_API.CheckedChanged += new System.EventHandler(this.GeneralCheckedChanged);
            // 
            // checkBoxREACT_Reducers
            // 
            this.checkBoxREACT_Reducers.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxREACT_Reducers.AutoSize = true;
            this.checkBoxREACT_Reducers.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.checkBoxREACT_Reducers.Location = new System.Drawing.Point(19, 64);
            this.checkBoxREACT_Reducers.Name = "checkBoxREACT_Reducers";
            this.checkBoxREACT_Reducers.Size = new System.Drawing.Size(177, 19);
            this.checkBoxREACT_Reducers.TabIndex = 0;
            this.checkBoxREACT_Reducers.Text = "Använder Reducers (Redux)?";
            this.checkBoxREACT_Reducers.UseVisualStyleBackColor = true;
            this.checkBoxREACT_Reducers.CheckedChanged += new System.EventHandler(this.GeneralCheckedChanged);
            // 
            // AddonType
            // 
            this.AddonType.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.AddonType.Controls.Add(this.radioNone);
            this.AddonType.Controls.Add(this.radioBlock);
            this.AddonType.Controls.Add(this.radioPage);
            this.AddonType.ForeColor = System.Drawing.Color.White;
            this.AddonType.Location = new System.Drawing.Point(87, 76);
            this.AddonType.Name = "AddonType";
            this.AddonType.Size = new System.Drawing.Size(451, 58);
            this.AddonType.TabIndex = 7;
            this.AddonType.TabStop = false;
            this.AddonType.Text = "Addon-typ";
            // 
            // radioNone
            // 
            this.radioNone.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.radioNone.AutoSize = true;
            this.radioNone.ForeColor = System.Drawing.Color.White;
            this.radioNone.Location = new System.Drawing.Point(233, 22);
            this.radioNone.Name = "radioNone";
            this.radioNone.Size = new System.Drawing.Size(214, 19);
            this.radioNone.TabIndex = 6;
            this.radioNone.TabStop = true;
            this.radioNone.Text = "Inkluderar varken block eller sidmall";
            this.radioNone.UseVisualStyleBackColor = true;
            this.radioNone.CheckedChanged += new System.EventHandler(this.radioNone_CheckedChanged);
            // 
            // radioBlock
            // 
            this.radioBlock.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.radioBlock.AutoSize = true;
            this.radioBlock.ForeColor = System.Drawing.Color.White;
            this.radioBlock.Location = new System.Drawing.Point(15, 22);
            this.radioBlock.Name = "radioBlock";
            this.radioBlock.Size = new System.Drawing.Size(54, 19);
            this.radioBlock.TabIndex = 4;
            this.radioBlock.TabStop = true;
            this.radioBlock.Text = "Block";
            this.radioBlock.UseVisualStyleBackColor = true;
            this.radioBlock.CheckedChanged += new System.EventHandler(this.radioBlock_CheckedChanged);
            // 
            // radioPage
            // 
            this.radioPage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.radioPage.AutoSize = true;
            this.radioPage.ForeColor = System.Drawing.Color.White;
            this.radioPage.Location = new System.Drawing.Point(89, 22);
            this.radioPage.Name = "radioPage";
            this.radioPage.Size = new System.Drawing.Size(119, 19);
            this.radioPage.TabIndex = 5;
            this.radioPage.TabStop = true;
            this.radioPage.Text = "Inkluderar sidmall";
            this.radioPage.UseVisualStyleBackColor = true;
            this.radioPage.CheckedChanged += new System.EventHandler(this.radioPage_CheckedChanged);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.Lavender;
            this.panel1.Controls.Add(this.lblErrorAddonExistsInProject);
            this.panel1.Controls.Add(this.labelErrNoAddonId);
            this.panel1.Controls.Add(this.PNAddonId);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(0, 31);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(624, 37);
            this.panel1.TabIndex = 3;
            // 
            // lblErrorAddonExistsInProject
            // 
            this.lblErrorAddonExistsInProject.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblErrorAddonExistsInProject.BackColor = System.Drawing.Color.White;
            this.lblErrorAddonExistsInProject.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblErrorAddonExistsInProject.ForeColor = System.Drawing.Color.Red;
            this.lblErrorAddonExistsInProject.Location = new System.Drawing.Point(404, 2);
            this.lblErrorAddonExistsInProject.Name = "lblErrorAddonExistsInProject";
            this.lblErrorAddonExistsInProject.Size = new System.Drawing.Size(206, 33);
            this.lblErrorAddonExistsInProject.TabIndex = 6;
            this.lblErrorAddonExistsInProject.Text = "Ett Addon med detta namn existerar redan i projektet!!!!";
            this.lblErrorAddonExistsInProject.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblErrorAddonExistsInProject.Visible = false;
            // 
            // labelErrNoAddonId
            // 
            this.labelErrNoAddonId.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelErrNoAddonId.AutoSize = true;
            this.labelErrNoAddonId.BackColor = System.Drawing.Color.White;
            this.labelErrNoAddonId.ForeColor = System.Drawing.Color.Red;
            this.labelErrNoAddonId.Location = new System.Drawing.Point(460, 11);
            this.labelErrNoAddonId.Name = "labelErrNoAddonId";
            this.labelErrNoAddonId.Size = new System.Drawing.Size(149, 15);
            this.labelErrNoAddonId.TabIndex = 5;
            this.labelErrNoAddonId.Text = "Inget ADDON-namn valt!!!!";
            this.labelErrNoAddonId.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // PNAddonId
            // 
            this.PNAddonId.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PNAddonId.BackColor = System.Drawing.Color.White;
            this.PNAddonId.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.PNAddonId.Location = new System.Drawing.Point(163, 3);
            this.PNAddonId.Name = "PNAddonId";
            this.PNAddonId.Size = new System.Drawing.Size(458, 33);
            this.PNAddonId.TabIndex = 2;
            this.PNAddonId.TextChanged += new System.EventHandler(this.PNAddonId_TextChanged);
            this.PNAddonId.Leave += new System.EventHandler(this.PNAddonId_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.ForeColor = System.Drawing.Color.DarkGoldenrod;
            this.label3.Location = new System.Drawing.Point(130, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 25);
            this.label3.TabIndex = 4;
            this.label3.Text = "PN";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Lavender;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(24, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "Addon-ID/Namn:";
            // 
            // RightToolPanel
            // 
            this.RightToolPanel.BackColor = System.Drawing.Color.Transparent;
            this.RightToolPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.RightToolPanel.Controls.Add(this.btnCreate);
            this.RightToolPanel.Controls.Add(this.label5);
            this.RightToolPanel.Controls.Add(this.lblAddonName);
            this.RightToolPanel.Controls.Add(this.panel2);
            this.RightToolPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RightToolPanel.Location = new System.Drawing.Point(0, 0);
            this.RightToolPanel.Name = "RightToolPanel";
            this.RightToolPanel.Size = new System.Drawing.Size(173, 450);
            this.RightToolPanel.TabIndex = 0;
            // 
            // btnCreate
            // 
            this.btnCreate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCreate.BackColor = System.Drawing.Color.Transparent;
            this.btnCreate.BackgroundImage = global::PilotDesktop.Properties.Resources.GlassButtonDark;
            this.btnCreate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCreate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCreate.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnCreate.FlatAppearance.BorderSize = 0;
            this.btnCreate.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SlateBlue;
            this.btnCreate.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MidnightBlue;
            this.btnCreate.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnCreate.ForeColor = System.Drawing.Color.LightCyan;
            this.btnCreate.Location = new System.Drawing.Point(-2, 386);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(173, 64);
            this.btnCreate.TabIndex = 2;
            this.btnCreate.Text = "Skapa grund i projektet";
            this.btnCreate.UseVisualStyleBackColor = false;
            this.btnCreate.Click += new System.EventHandler(this.button1_Click_3);
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(166, 34);
            this.label5.TabIndex = 1;
            this.label5.Text = "...kommer att skapa...";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblAddonName
            // 
            this.lblAddonName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblAddonName.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblAddonName.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblAddonName.Location = new System.Drawing.Point(2, 39);
            this.lblAddonName.Name = "lblAddonName";
            this.lblAddonName.Size = new System.Drawing.Size(166, 21);
            this.lblAddonName.TabIndex = 0;
            this.lblAddonName.Text = "...";
            this.lblAddonName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.Black;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.TaskList);
            this.panel2.Location = new System.Drawing.Point(6, 74);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(156, 296);
            this.panel2.TabIndex = 4;
            // 
            // TaskList
            // 
            this.TaskList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TaskList.BackColor = System.Drawing.Color.Black;
            this.TaskList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TaskList.BulletIndent = 16;
            this.TaskList.Location = new System.Drawing.Point(17, 13);
            this.TaskList.Margin = new System.Windows.Forms.Padding(23);
            this.TaskList.Name = "TaskList";
            this.TaskList.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.TaskList.Size = new System.Drawing.Size(127, 268);
            this.TaskList.TabIndex = 3;
            this.TaskList.Text = "";
            // 
            // CodeGenerator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImage = global::PilotDesktop.Properties.Resources.PandoNexisHero;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel_PNChooseFolder);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.SystemColors.Control;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CodeGenerator";
            this.Opacity = 0.98D;
            this.Text = "Pando Nexis Code Generator";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.SelectDir_Load);
            this.panel_PNChooseFolder.ResumeLayout(false);
            this.ToolContainer.Panel1.ResumeLayout(false);
            this.ToolContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ToolContainer)).EndInit();
            this.ToolContainer.ResumeLayout(false);
            this.LeftToolPanel.ResumeLayout(false);
            this.LeftToolPanel.PerformLayout();
            this.ProjNameBar.ResumeLayout(false);
            this.ProjNameBar.PerformLayout();
            this.groupBoxProj.ResumeLayout(false);
            this.groupBoxProj.PerformLayout();
            this.groupBoxREACT.ResumeLayout(false);
            this.groupBoxREACT.PerformLayout();
            this.AddonType.ResumeLayout(false);
            this.AddonType.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.RightToolPanel.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private FolderBrowserDialog projFolder;
        private Button btnChooseProj;
        private Label lblFolderError;
        private Panel panel_PNChooseFolder;
        private SplitContainer ToolContainer;
        private Panel LeftToolPanel;
        private Panel ProjNameBar;
        private Label label2;
        private Label lblProjName;
        private Panel RightToolPanel;
        private LinkLabel lblBtnChoosNewProj;
        private Panel panel1;
        private Label label1;
        private TextBox PNAddonId;
        private Label label3;
        private Label lblAddonName;
        private Label label5;
        private RadioButton radioNone;
        private RadioButton radioPage;
        private RadioButton radioBlock;
        private GroupBox AddonType;
        private CheckBox checkBoxStyling;
        private CheckBox checkBoxREACT;
        private GroupBox groupBoxProj;
        private GroupBox groupBoxREACT;
        private Label labelErrNoAddonId;
        private Button btnCreate;
        private CheckBox checkBoxREACT_API;
        private CheckBox checkBoxREACT_Reducers;
        private RichTextBox TaskList;
        private Panel panel2;
        private CheckBox checkBoxPageTemplate;
        private CheckBox checkBoxServices;
        private CheckBox checkBoxViewModels;
        private CheckBox checkBoxBuilders;
        private CheckBox checkBoxToggleAll;
        private CheckBox checkBoxNewFields;
        private CheckBox checkBoxConstants;
        private CheckBox checkBoxWebsiteSettings;
        private Label lblErrorAddonExistsInProject;
    }
}