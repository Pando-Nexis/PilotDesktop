namespace PilotDesktop.UserControls
{
    partial class ItemStatusCtrl
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
            this.cbItemStatus = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cbItemStatus
            // 
            this.cbItemStatus.DropDownWidth = 283;
            this.cbItemStatus.FormattingEnabled = true;
            this.cbItemStatus.Location = new System.Drawing.Point(77, 0);
            this.cbItemStatus.Name = "cbItemStatus";
            this.cbItemStatus.Size = new System.Drawing.Size(283, 23);
            this.cbItemStatus.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(0, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(25, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Status";
            // 
            // ItemTypeCtrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbItemStatus);
            this.Name = "ItemStatusCtrl";
            this.Size = new System.Drawing.Size(360, 24);
            this.Load += new System.EventHandler(this.ItemStatusCtrl_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ComboBox cbItemStatus;
        private Label label1;
    }
}
