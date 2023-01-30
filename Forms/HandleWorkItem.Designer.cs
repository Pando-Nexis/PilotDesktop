namespace PilotDesktop.Forms
{
    partial class HandleWorkItem
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
            this.bSave = new System.Windows.Forms.Button();
            this.customerAndProjectCtrl1 = new PilotDesktop.UserControls.CustomerAndProjectCtrl();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbTitle = new System.Windows.Forms.TextBox();
            this.rtbDescription = new System.Windows.Forms.RichTextBox();
            this.itemTypeCtrl1 = new PilotDesktop.UserControls.ItemTypeCtrl();
            this.estimatedTime1 = new PilotDesktop.UserControls.EstimatedTimeCtrl();
            this.workedTime1 = new PilotDesktop.UserControls.WorkedTimeCtrl();
            this.bNew = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // bSave
            // 
            this.bSave.Location = new System.Drawing.Point(568, 395);
            this.bSave.Name = "bSave";
            this.bSave.Size = new System.Drawing.Size(75, 23);
            this.bSave.TabIndex = 2;
            this.bSave.Text = "Spara";
            this.bSave.UseVisualStyleBackColor = true;
            this.bSave.Click += new System.EventHandler(this.bSave_Click);
            // 
            // customerAndProjectCtrl1
            // 
            this.customerAndProjectCtrl1.Location = new System.Drawing.Point(29, 55);
            this.customerAndProjectCtrl1.Name = "customerAndProjectCtrl1";
            this.customerAndProjectCtrl1.Size = new System.Drawing.Size(366, 51);
            this.customerAndProjectCtrl1.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "Titel";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(35, 137);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 15);
            this.label2.TabIndex = 5;
            this.label2.Text = "Beskrivning";
            // 
            // tbTitle
            // 
            this.tbTitle.Location = new System.Drawing.Point(110, 26);
            this.tbTitle.Name = "tbTitle";
            this.tbTitle.Size = new System.Drawing.Size(282, 23);
            this.tbTitle.TabIndex = 6;
            // 
            // rtbDescription
            // 
            this.rtbDescription.Location = new System.Drawing.Point(109, 140);
            this.rtbDescription.Name = "rtbDescription";
            this.rtbDescription.Size = new System.Drawing.Size(282, 283);
            this.rtbDescription.TabIndex = 7;
            this.rtbDescription.Text = "";
            // 
            // itemTypeCtrl1
            // 
            this.itemTypeCtrl1.Location = new System.Drawing.Point(32, 110);
            this.itemTypeCtrl1.Name = "itemTypeCtrl1";
            this.itemTypeCtrl1.Size = new System.Drawing.Size(360, 24);
            this.itemTypeCtrl1.TabIndex = 8;
            // 
            // estimatedTime1
            // 
            this.estimatedTime1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.estimatedTime1.Location = new System.Drawing.Point(416, 19);
            this.estimatedTime1.Name = "estimatedTime1";
            this.estimatedTime1.Size = new System.Drawing.Size(308, 115);
            this.estimatedTime1.TabIndex = 9;
            // 
            // workedTime1
            // 
            this.workedTime1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.workedTime1.Location = new System.Drawing.Point(416, 140);
            this.workedTime1.Name = "workedTime1";
            this.workedTime1.Size = new System.Drawing.Size(308, 193);
            this.workedTime1.TabIndex = 10;
            // 
            // bNew
            // 
            this.bNew.Location = new System.Drawing.Point(649, 395);
            this.bNew.Name = "bNew";
            this.bNew.Size = new System.Drawing.Size(75, 23);
            this.bNew.TabIndex = 11;
            this.bNew.Text = "Ny";
            this.bNew.UseVisualStyleBackColor = true;
            this.bNew.Click += new System.EventHandler(this.bNew_Click);
            // 
            // HandleWorkItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(749, 430);
            this.Controls.Add(this.bNew);
            this.Controls.Add(this.workedTime1);
            this.Controls.Add(this.estimatedTime1);
            this.Controls.Add(this.itemTypeCtrl1);
            this.Controls.Add(this.rtbDescription);
            this.Controls.Add(this.tbTitle);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.customerAndProjectCtrl1);
            this.Controls.Add(this.bSave);
            this.Name = "HandleWorkItem";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "HandleWorkItems";
            this.Load += new System.EventHandler(this.HandleWorkItems_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Button bSave;
        private UserControls.CustomerAndProjectCtrl customerAndProjectCtrl1;
        private Label label1;
        private Label label2;
        private TextBox tbTitle;
        private RichTextBox rtbDescription;
        private UserControls.ItemTypeCtrl itemTypeCtrl1;
        private UserControls.EstimatedTimeCtrl estimatedTime1;
        private UserControls.WorkedTimeCtrl workedTime1;
        private Button bNew;
    }
}