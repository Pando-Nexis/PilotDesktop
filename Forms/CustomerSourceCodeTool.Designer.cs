namespace PilotDesktop.Forms
{
    partial class CustomerSourceCodeTool
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
            this.bAddAddon = new System.Windows.Forms.Button();
            this.bCreateProject = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // bAddAddon
            // 
            this.bAddAddon.Location = new System.Drawing.Point(256, 148);
            this.bAddAddon.Name = "bAddAddon";
            this.bAddAddon.Size = new System.Drawing.Size(113, 54);
            this.bAddAddon.TabIndex = 7;
            this.bAddAddon.Text = "Lägg till Addon";
            this.bAddAddon.UseVisualStyleBackColor = true;
            this.bAddAddon.Click += new System.EventHandler(this.bAddAddon_Click);
            // 
            // bCreateProject
            // 
            this.bCreateProject.Location = new System.Drawing.Point(117, 148);
            this.bCreateProject.Name = "bCreateProject";
            this.bCreateProject.Size = new System.Drawing.Size(113, 54);
            this.bCreateProject.TabIndex = 6;
            this.bCreateProject.Text = "Skapa projekt";
            this.bCreateProject.UseVisualStyleBackColor = true;
            this.bCreateProject.Click += new System.EventHandler(this.bCreateProject_Click);
            // 
            // CustomerSourceCodeTool
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.bAddAddon);
            this.Controls.Add(this.bCreateProject);
            this.Name = "CustomerSourceCodeTool";
            this.Text = "CustomerSourceCodeTool";
            this.ResumeLayout(false);

        }

        #endregion

        private Button bAddAddon;
        private Button bCreateProject;
    }
}