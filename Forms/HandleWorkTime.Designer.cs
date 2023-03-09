namespace PilotDesktop.Forms
{
    partial class HandleWorkTime
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
            this.workedTimeCtrl1 = new PilotDesktop.UserControls.WorkedTimeCtrl();
            this.bSave = new System.Windows.Forms.Button();
            this.bSplit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // workedTimeCtrl1
            // 
            this.workedTimeCtrl1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.workedTimeCtrl1.Location = new System.Drawing.Point(12, 13);
            this.workedTimeCtrl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.workedTimeCtrl1.Name = "workedTimeCtrl1";
            this.workedTimeCtrl1.Size = new System.Drawing.Size(388, 271);
            this.workedTimeCtrl1.TabIndex = 0;
            // 
            // bSave
            // 
            this.bSave.Location = new System.Drawing.Point(306, 291);
            this.bSave.Name = "bSave";
            this.bSave.Size = new System.Drawing.Size(94, 29);
            this.bSave.TabIndex = 1;
            this.bSave.Text = "Spara";
            this.bSave.UseVisualStyleBackColor = true;
            this.bSave.Click += new System.EventHandler(this.bSave_Click);
            // 
            // bSplit
            // 
            this.bSplit.Location = new System.Drawing.Point(169, 291);
            this.bSplit.Name = "bSplit";
            this.bSplit.Size = new System.Drawing.Size(94, 29);
            this.bSplit.TabIndex = 2;
            this.bSplit.Text = "Splitta";
            this.bSplit.UseVisualStyleBackColor = true;
            this.bSplit.Click += new System.EventHandler(this.bSplit_Click);
            // 
            // HandleWorkTime
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(418, 332);
            this.Controls.Add(this.bSplit);
            this.Controls.Add(this.bSave);
            this.Controls.Add(this.workedTimeCtrl1);
            this.Name = "HandleWorkTime";
            this.Text = "HandleWorkTime";
            this.Load += new System.EventHandler(this.HandleWorkTime_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private UserControls.WorkedTimeCtrl workedTimeCtrl1;
        private Button bSave;
        private Button bSplit;
    }
}