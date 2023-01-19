namespace PilotDesktop.Forms
{
    partial class Settings
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Settings));
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbApiSecret = new System.Windows.Forms.TextBox();
            this.tbBaseUrl = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.bMasterProject = new System.Windows.Forms.Button();
            this.tbMasterProject = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.bSelectProjectFolder = new System.Windows.Forms.Button();
            this.tbProjectFolder = new System.Windows.Forms.TextBox();
            this.bSave = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label4.Location = new System.Drawing.Point(27, 160);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 19);
            this.label4.TabIndex = 20;
            this.label4.Text = "Api secret";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label3.Location = new System.Drawing.Point(24, 120);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 17);
            this.label3.TabIndex = 19;
            this.label3.Text = "Base url";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // tbApiSecret
            // 
            this.tbApiSecret.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbApiSecret.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbApiSecret.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tbApiSecret.ForeColor = System.Drawing.Color.DimGray;
            this.tbApiSecret.Location = new System.Drawing.Point(112, 159);
            this.tbApiSecret.Name = "tbApiSecret";
            this.tbApiSecret.Size = new System.Drawing.Size(389, 25);
            this.tbApiSecret.TabIndex = 18;
            // 
            // tbBaseUrl
            // 
            this.tbBaseUrl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbBaseUrl.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbBaseUrl.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tbBaseUrl.ForeColor = System.Drawing.Color.DimGray;
            this.tbBaseUrl.Location = new System.Drawing.Point(112, 116);
            this.tbBaseUrl.Name = "tbBaseUrl";
            this.tbBaseUrl.Size = new System.Drawing.Size(389, 25);
            this.tbBaseUrl.TabIndex = 17;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label2.Location = new System.Drawing.Point(26, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 15);
            this.label2.TabIndex = 16;
            this.label2.Text = "Master project";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // bMasterProject
            // 
            this.bMasterProject.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bMasterProject.BackgroundImage = global::PilotDesktop.Properties.Resources.GlassButtonGeneral1;
            this.bMasterProject.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bMasterProject.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bMasterProject.Location = new System.Drawing.Point(517, 70);
            this.bMasterProject.Name = "bMasterProject";
            this.bMasterProject.Size = new System.Drawing.Size(46, 32);
            this.bMasterProject.TabIndex = 15;
            this.bMasterProject.Text = "...";
            this.bMasterProject.UseVisualStyleBackColor = true;
            this.bMasterProject.Click += new System.EventHandler(this.bMasterProject_Click);
            // 
            // tbMasterProject
            // 
            this.tbMasterProject.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbMasterProject.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbMasterProject.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tbMasterProject.ForeColor = System.Drawing.Color.DimGray;
            this.tbMasterProject.Location = new System.Drawing.Point(110, 73);
            this.tbMasterProject.Name = "tbMasterProject";
            this.tbMasterProject.Size = new System.Drawing.Size(391, 25);
            this.tbMasterProject.TabIndex = 14;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label1.Location = new System.Drawing.Point(26, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Projekt folder";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // bSelectProjectFolder
            // 
            this.bSelectProjectFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bSelectProjectFolder.BackgroundImage = global::PilotDesktop.Properties.Resources.GlassButtonGeneral1;
            this.bSelectProjectFolder.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bSelectProjectFolder.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bSelectProjectFolder.Location = new System.Drawing.Point(517, 27);
            this.bSelectProjectFolder.Name = "bSelectProjectFolder";
            this.bSelectProjectFolder.Size = new System.Drawing.Size(46, 32);
            this.bSelectProjectFolder.TabIndex = 12;
            this.bSelectProjectFolder.Text = "...";
            this.bSelectProjectFolder.UseVisualStyleBackColor = true;
            this.bSelectProjectFolder.Click += new System.EventHandler(this.bSelectProjectFolder_Click);
            // 
            // tbProjectFolder
            // 
            this.tbProjectFolder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbProjectFolder.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbProjectFolder.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tbProjectFolder.ForeColor = System.Drawing.Color.DimGray;
            this.tbProjectFolder.Location = new System.Drawing.Point(110, 30);
            this.tbProjectFolder.Name = "tbProjectFolder";
            this.tbProjectFolder.Size = new System.Drawing.Size(391, 25);
            this.tbProjectFolder.TabIndex = 11;
            // 
            // bSave
            // 
            this.bSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bSave.BackColor = System.Drawing.Color.Transparent;
            this.bSave.BackgroundImage = global::PilotDesktop.Properties.Resources.GlassButtonDark;
            this.bSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bSave.FlatAppearance.BorderColor = System.Drawing.Color.SeaShell;
            this.bSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bSave.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.bSave.Location = new System.Drawing.Point(379, 212);
            this.bSave.Name = "bSave";
            this.bSave.Size = new System.Drawing.Size(122, 38);
            this.bSave.TabIndex = 21;
            this.bSave.Text = "Spara";
            this.bSave.UseVisualStyleBackColor = false;
            this.bSave.Click += new System.EventHandler(this.bSave_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::PilotDesktop.Properties.Resources.PandoNexisHeroDark;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.bSave);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbApiSecret);
            this.Controls.Add(this.tbBaseUrl);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.bMasterProject);
            this.Controls.Add(this.tbMasterProject);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.bSelectProjectFolder);
            this.Controls.Add(this.tbProjectFolder);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Settings";
            this.Opacity = 0.98D;
            this.Text = "Settings";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Settings_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label4;
        private Label label3;
        private TextBox tbApiSecret;
        private TextBox tbBaseUrl;
        private Label label2;
        private Button bMasterProject;
        private TextBox tbMasterProject;
        private Label label1;
        private Button bSelectProjectFolder;
        private TextBox tbProjectFolder;
        private Button bSave;
        private FolderBrowserDialog folderBrowserDialog1;
        private OpenFileDialog openFileDialog1;
    }
}