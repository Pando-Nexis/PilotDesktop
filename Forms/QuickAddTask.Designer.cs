namespace PilotDesktop.Forms
{
    partial class QuickAddTask
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
            this.itemStatusCtrl1 = new PilotDesktop.UserControls.ItemStatusCtrl();
            this.itemTypeCtrl1 = new PilotDesktop.UserControls.ItemTypeCtrl();
            this.tbTitle = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.bSave = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // itemStatusCtrl1
            // 
            this.itemStatusCtrl1.Location = new System.Drawing.Point(16, 71);
            this.itemStatusCtrl1.Name = "itemStatusCtrl1";
            this.itemStatusCtrl1.Size = new System.Drawing.Size(360, 24);
            this.itemStatusCtrl1.TabIndex = 17;
            // 
            // itemTypeCtrl1
            // 
            this.itemTypeCtrl1.Location = new System.Drawing.Point(16, 41);
            this.itemTypeCtrl1.Name = "itemTypeCtrl1";
            this.itemTypeCtrl1.Size = new System.Drawing.Size(360, 24);
            this.itemTypeCtrl1.TabIndex = 16;
            // 
            // tbTitle
            // 
            this.tbTitle.Location = new System.Drawing.Point(94, 12);
            this.tbTitle.Name = "tbTitle";
            this.tbTitle.Size = new System.Drawing.Size(282, 23);
            this.tbTitle.TabIndex = 15;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 15);
            this.label1.TabIndex = 14;
            this.label1.Text = "Titel";
            // 
            // bSave
            // 
            this.bSave.Location = new System.Drawing.Point(301, 112);
            this.bSave.Name = "bSave";
            this.bSave.Size = new System.Drawing.Size(75, 23);
            this.bSave.TabIndex = 18;
            this.bSave.Text = "Spara";
            this.bSave.UseVisualStyleBackColor = true;
            this.bSave.Click += new System.EventHandler(this.bSave_Click);
            // 
            // QuickAddTask
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(385, 143);
            this.Controls.Add(this.bSave);
            this.Controls.Add(this.itemStatusCtrl1);
            this.Controls.Add(this.itemTypeCtrl1);
            this.Controls.Add(this.tbTitle);
            this.Controls.Add(this.label1);
            this.Name = "QuickAddTask";
            this.Text = "QuickAddTask";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private UserControls.ItemStatusCtrl itemStatusCtrl1;
        private UserControls.ItemTypeCtrl itemTypeCtrl1;
        private TextBox tbTitle;
        private Label label1;
        private Button bSave;
    }
}