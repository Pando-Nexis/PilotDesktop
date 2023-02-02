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
            this.tabCtrl = new System.Windows.Forms.TabControl();
            this.tabTimes = new System.Windows.Forms.TabPage();
            this.tabDescription = new System.Windows.Forms.TabPage();
            this.tabChildren = new System.Windows.Forms.TabPage();
            this.bAddSubActivities = new System.Windows.Forms.Button();
            this.lvItems = new System.Windows.Forms.ListView();
            this.itemStatusCtrl1 = new PilotDesktop.UserControls.ItemStatusCtrl();
            this.tabCtrl.SuspendLayout();
            this.tabTimes.SuspendLayout();
            this.tabDescription.SuspendLayout();
            this.tabChildren.SuspendLayout();
            this.SuspendLayout();
            // 
            // bSave
            // 
            this.bSave.Location = new System.Drawing.Point(601, 535);
            this.bSave.Name = "bSave";
            this.bSave.Size = new System.Drawing.Size(75, 23);
            this.bSave.TabIndex = 2;
            this.bSave.Text = "Spara";
            this.bSave.UseVisualStyleBackColor = true;
            this.bSave.Click += new System.EventHandler(this.bSave_Click);
            // 
            // customerAndProjectCtrl1
            // 
            this.customerAndProjectCtrl1.Location = new System.Drawing.Point(393, 11);
            this.customerAndProjectCtrl1.Name = "customerAndProjectCtrl1";
            this.customerAndProjectCtrl1.Size = new System.Drawing.Size(366, 51);
            this.customerAndProjectCtrl1.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "Titel";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 15);
            this.label2.TabIndex = 5;
            this.label2.Text = "Beskrivning";
            // 
            // tbTitle
            // 
            this.tbTitle.Location = new System.Drawing.Point(91, 11);
            this.tbTitle.Name = "tbTitle";
            this.tbTitle.Size = new System.Drawing.Size(282, 23);
            this.tbTitle.TabIndex = 6;
            // 
            // rtbDescription
            // 
            this.rtbDescription.Location = new System.Drawing.Point(103, 39);
            this.rtbDescription.Name = "rtbDescription";
            this.rtbDescription.Size = new System.Drawing.Size(282, 283);
            this.rtbDescription.TabIndex = 7;
            this.rtbDescription.Text = "";
            // 
            // itemTypeCtrl1
            // 
            this.itemTypeCtrl1.Location = new System.Drawing.Point(13, 40);
            this.itemTypeCtrl1.Name = "itemTypeCtrl1";
            this.itemTypeCtrl1.Size = new System.Drawing.Size(360, 24);
            this.itemTypeCtrl1.TabIndex = 8;
            // 
            // estimatedTime1
            // 
            this.estimatedTime1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.estimatedTime1.Location = new System.Drawing.Point(6, 15);
            this.estimatedTime1.Name = "estimatedTime1";
            this.estimatedTime1.Size = new System.Drawing.Size(308, 115);
            this.estimatedTime1.TabIndex = 9;
            // 
            // workedTime1
            // 
            this.workedTime1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.workedTime1.Location = new System.Drawing.Point(6, 136);
            this.workedTime1.Name = "workedTime1";
            this.workedTime1.Size = new System.Drawing.Size(308, 193);
            this.workedTime1.TabIndex = 10;
            // 
            // bNew
            // 
            this.bNew.Location = new System.Drawing.Point(682, 535);
            this.bNew.Name = "bNew";
            this.bNew.Size = new System.Drawing.Size(75, 23);
            this.bNew.TabIndex = 11;
            this.bNew.Text = "Ny";
            this.bNew.UseVisualStyleBackColor = true;
            this.bNew.Click += new System.EventHandler(this.bNew_Click);
            // 
            // tabCtrl
            // 
            this.tabCtrl.Controls.Add(this.tabTimes);
            this.tabCtrl.Controls.Add(this.tabDescription);
            this.tabCtrl.Controls.Add(this.tabChildren);
            this.tabCtrl.Location = new System.Drawing.Point(3, 108);
            this.tabCtrl.Name = "tabCtrl";
            this.tabCtrl.SelectedIndex = 0;
            this.tabCtrl.Size = new System.Drawing.Size(759, 421);
            this.tabCtrl.TabIndex = 12;
            // 
            // tabTimes
            // 
            this.tabTimes.Controls.Add(this.estimatedTime1);
            this.tabTimes.Controls.Add(this.workedTime1);
            this.tabTimes.Location = new System.Drawing.Point(4, 24);
            this.tabTimes.Name = "tabTimes";
            this.tabTimes.Padding = new System.Windows.Forms.Padding(3);
            this.tabTimes.Size = new System.Drawing.Size(751, 393);
            this.tabTimes.TabIndex = 0;
            this.tabTimes.Text = "Tid";
            this.tabTimes.UseVisualStyleBackColor = true;
            // 
            // tabDescription
            // 
            this.tabDescription.Controls.Add(this.rtbDescription);
            this.tabDescription.Controls.Add(this.label2);
            this.tabDescription.Location = new System.Drawing.Point(4, 24);
            this.tabDescription.Name = "tabDescription";
            this.tabDescription.Padding = new System.Windows.Forms.Padding(3);
            this.tabDescription.Size = new System.Drawing.Size(751, 393);
            this.tabDescription.TabIndex = 1;
            this.tabDescription.Text = "Beskrivning";
            this.tabDescription.UseVisualStyleBackColor = true;
            // 
            // tabChildren
            // 
            this.tabChildren.Controls.Add(this.bAddSubActivities);
            this.tabChildren.Controls.Add(this.lvItems);
            this.tabChildren.Location = new System.Drawing.Point(4, 24);
            this.tabChildren.Name = "tabChildren";
            this.tabChildren.Size = new System.Drawing.Size(751, 393);
            this.tabChildren.TabIndex = 2;
            this.tabChildren.Text = "Del aktiviteter";
            this.tabChildren.UseVisualStyleBackColor = true;
            // 
            // bAddSubActivities
            // 
            this.bAddSubActivities.Location = new System.Drawing.Point(614, 330);
            this.bAddSubActivities.Name = "bAddSubActivities";
            this.bAddSubActivities.Size = new System.Drawing.Size(75, 23);
            this.bAddSubActivities.TabIndex = 1;
            this.bAddSubActivities.Text = "Lägg till";
            this.bAddSubActivities.UseVisualStyleBackColor = true;
            this.bAddSubActivities.Click += new System.EventHandler(this.bAddSubActivities_Click);
            // 
            // lvItems
            // 
            this.lvItems.FullRowSelect = true;
            this.lvItems.GridLines = true;
            this.lvItems.Location = new System.Drawing.Point(22, 28);
            this.lvItems.MultiSelect = false;
            this.lvItems.Name = "lvItems";
            this.lvItems.Size = new System.Drawing.Size(667, 296);
            this.lvItems.TabIndex = 0;
            this.lvItems.UseCompatibleStateImageBehavior = false;
            this.lvItems.View = System.Windows.Forms.View.Details;
            // 
            // itemStatusCtrl1
            // 
            this.itemStatusCtrl1.Location = new System.Drawing.Point(13, 70);
            this.itemStatusCtrl1.Name = "itemStatusCtrl1";
            this.itemStatusCtrl1.Size = new System.Drawing.Size(360, 24);
            this.itemStatusCtrl1.TabIndex = 13;
            // 
            // HandleWorkItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(768, 565);
            this.Controls.Add(this.itemStatusCtrl1);
            this.Controls.Add(this.tabCtrl);
            this.Controls.Add(this.bNew);
            this.Controls.Add(this.itemTypeCtrl1);
            this.Controls.Add(this.tbTitle);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.customerAndProjectCtrl1);
            this.Controls.Add(this.bSave);
            this.Name = "HandleWorkItem";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "HandleWorkItems";
            this.Load += new System.EventHandler(this.HandleWorkItems_Load);
            this.tabCtrl.ResumeLayout(false);
            this.tabTimes.ResumeLayout(false);
            this.tabDescription.ResumeLayout(false);
            this.tabDescription.PerformLayout();
            this.tabChildren.ResumeLayout(false);
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
        private TabControl tabCtrl;
        private TabPage tabTimes;
        private TabPage tabDescription;
        private UserControls.ItemStatusCtrl itemStatusCtrl1;
        private TabPage tabChildren;
        private ListView lvItems;
        private Button bAddSubActivities;
    }
}