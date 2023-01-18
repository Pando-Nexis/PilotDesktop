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
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(27, 160);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 15);
            this.label4.TabIndex = 20;
            this.label4.Text = "Api secret";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 116);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 15);
            this.label3.TabIndex = 19;
            this.label3.Text = "Base url";
            // 
            // tbApiSecret
            // 
            this.tbApiSecret.Location = new System.Drawing.Point(112, 155);
            this.tbApiSecret.Name = "tbApiSecret";
            this.tbApiSecret.Size = new System.Drawing.Size(355, 23);
            this.tbApiSecret.TabIndex = 18;
            // 
            // tbBaseUrl
            // 
            this.tbBaseUrl.Location = new System.Drawing.Point(112, 113);
            this.tbBaseUrl.Name = "tbBaseUrl";
            this.tbBaseUrl.Size = new System.Drawing.Size(355, 23);
            this.tbBaseUrl.TabIndex = 17;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 15);
            this.label2.TabIndex = 16;
            this.label2.Text = "Master project";
            // 
            // bMasterProject
            // 
            this.bMasterProject.Location = new System.Drawing.Point(473, 72);
            this.bMasterProject.Name = "bMasterProject";
            this.bMasterProject.Size = new System.Drawing.Size(29, 23);
            this.bMasterProject.TabIndex = 15;
            this.bMasterProject.Text = "...";
            this.bMasterProject.UseVisualStyleBackColor = true;
            this.bMasterProject.Click += new System.EventHandler(this.bMasterProject_Click);
            // 
            // tbMasterProject
            // 
            this.tbMasterProject.Location = new System.Drawing.Point(110, 72);
            this.tbMasterProject.Name = "tbMasterProject";
            this.tbMasterProject.Size = new System.Drawing.Size(357, 23);
            this.tbMasterProject.TabIndex = 14;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 15);
            this.label1.TabIndex = 13;
            this.label1.Text = "Projekt folder";
            // 
            // bSelectProjectFolder
            // 
            this.bSelectProjectFolder.Location = new System.Drawing.Point(473, 27);
            this.bSelectProjectFolder.Name = "bSelectProjectFolder";
            this.bSelectProjectFolder.Size = new System.Drawing.Size(29, 23);
            this.bSelectProjectFolder.TabIndex = 12;
            this.bSelectProjectFolder.Text = "...";
            this.bSelectProjectFolder.UseVisualStyleBackColor = true;
            this.bSelectProjectFolder.Click += new System.EventHandler(this.bSelectProjectFolder_Click);
            // 
            // tbProjectFolder
            // 
            this.tbProjectFolder.Location = new System.Drawing.Point(110, 27);
            this.tbProjectFolder.Name = "tbProjectFolder";
            this.tbProjectFolder.Size = new System.Drawing.Size(357, 23);
            this.tbProjectFolder.TabIndex = 11;
            // 
            // bSave
            // 
            this.bSave.Location = new System.Drawing.Point(427, 305);
            this.bSave.Name = "bSave";
            this.bSave.Size = new System.Drawing.Size(75, 34);
            this.bSave.TabIndex = 21;
            this.bSave.Text = "Spara";
            this.bSave.UseVisualStyleBackColor = true;
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
            this.Name = "Settings";
            this.Text = "Settings";
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