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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustomerSourceCodeTool));
            this.bAddAddon = new System.Windows.Forms.Button();
            this.bCreateProject = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // bAddAddon
            // 
            this.bAddAddon.BackColor = System.Drawing.Color.Transparent;
            this.bAddAddon.BackgroundImage = global::PilotDesktop.Properties.Resources.GlassButton2;
            this.bAddAddon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bAddAddon.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bAddAddon.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.bAddAddon.Location = new System.Drawing.Point(360, 130);
            this.bAddAddon.Name = "bAddAddon";
            this.bAddAddon.Size = new System.Drawing.Size(113, 54);
            this.bAddAddon.TabIndex = 7;
            this.bAddAddon.Text = "Lägg till Addon";
            this.bAddAddon.UseVisualStyleBackColor = false;
            this.bAddAddon.Click += new System.EventHandler(this.bAddAddon_Click);
            // 
            // bCreateProject
            // 
            this.bCreateProject.BackColor = System.Drawing.Color.Transparent;
            this.bCreateProject.BackgroundImage = global::PilotDesktop.Properties.Resources.GlassButtonGeneral;
            this.bCreateProject.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bCreateProject.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bCreateProject.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.bCreateProject.Location = new System.Drawing.Point(195, 130);
            this.bCreateProject.Name = "bCreateProject";
            this.bCreateProject.Size = new System.Drawing.Size(113, 54);
            this.bCreateProject.TabIndex = 6;
            this.bCreateProject.Text = "Skapa projekt";
            this.bCreateProject.UseVisualStyleBackColor = false;
            this.bCreateProject.Click += new System.EventHandler(this.bCreateProject_Click);
            // 
            // CustomerSourceCodeTool
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::PilotDesktop.Properties.Resources.PandoNexisHero;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(828, 389);
            this.Controls.Add(this.bAddAddon);
            this.Controls.Add(this.bCreateProject);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CustomerSourceCodeTool";
            this.Opacity = 0.98D;
            this.Text = "CustomerSourceCodeTool";
            this.TopMost = true;
            this.ResumeLayout(false);

        }

        #endregion

        private Button bAddAddon;
        private Button bCreateProject;
    }
}