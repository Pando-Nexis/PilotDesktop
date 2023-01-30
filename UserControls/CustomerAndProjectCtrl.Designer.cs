namespace PilotDesktop.UserControls
{
    partial class CustomerAndProjectCtrl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ctrlCustomer = new PilotDesktop.UserControls.CustomerCtrl();
            this.ctrlProject = new PilotDesktop.UserControls.ProjectCtrl();
            this.SuspendLayout();
            // 
            // ctrlCustomer
            // 
            this.ctrlCustomer.Location = new System.Drawing.Point(3, 0);
            this.ctrlCustomer.Name = "ctrlCustomer";
            this.ctrlCustomer.Size = new System.Drawing.Size(360, 24);
            this.ctrlCustomer.TabIndex = 0;
            // 
            // ctrlProject
            // 
            this.ctrlProject.Location = new System.Drawing.Point(3, 26);
            this.ctrlProject.Name = "ctrlProject";
            this.ctrlProject.Size = new System.Drawing.Size(360, 24);
            this.ctrlProject.TabIndex = 1;
            // 
            // CustomerAndProjectCtrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ctrlProject);
            this.Controls.Add(this.ctrlCustomer);
            this.Name = "CustomerAndProjectCtrl";
            this.Size = new System.Drawing.Size(366, 51);
            this.Load += new System.EventHandler(this.CustomerAndProjectCtrl_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CustomerCtrl ctrlCustomer;
        private ProjectCtrl ctrlProject;
    }
}
