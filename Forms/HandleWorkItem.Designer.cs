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
            this.tbTitle = new System.Windows.Forms.TextBox();
            this.itemTypeCtrl1 = new PilotDesktop.UserControls.ItemTypeCtrl();
            this.estimatedTime1 = new PilotDesktop.UserControls.EstimatedTimeCtrl();
            this.workedTime1 = new PilotDesktop.UserControls.WorkedTimeCtrl();
            this.bNew = new System.Windows.Forms.Button();
            this.tabCtrl = new System.Windows.Forms.TabControl();
            this.tabGeneral = new System.Windows.Forms.TabPage();
            this.tabDescription = new System.Windows.Forms.TabPage();
            this.tabChildren = new System.Windows.Forms.TabPage();
            this.bAddSubActivities = new System.Windows.Forms.Button();
            this.lvItems = new System.Windows.Forms.ListView();
            this.tabWorkTime = new System.Windows.Forms.TabPage();
            this.bAddTime = new System.Windows.Forms.Button();
            this.lvWorkTime = new System.Windows.Forms.ListView();
            this.tabInvoices = new System.Windows.Forms.TabPage();
            this.lvInvoice = new System.Windows.Forms.ListView();
            this.itemStatusCtrl1 = new PilotDesktop.UserControls.ItemStatusCtrl();
            this.rtbDescription = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tabCtrl.SuspendLayout();
            this.tabGeneral.SuspendLayout();
            this.tabChildren.SuspendLayout();
            this.tabWorkTime.SuspendLayout();
            this.tabInvoices.SuspendLayout();
            this.SuspendLayout();
            // 
            // bSave
            // 
            this.bSave.Location = new System.Drawing.Point(687, 713);
            this.bSave.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.bSave.Name = "bSave";
            this.bSave.Size = new System.Drawing.Size(86, 31);
            this.bSave.TabIndex = 2;
            this.bSave.Text = "Spara";
            this.bSave.UseVisualStyleBackColor = true;
            this.bSave.Click += new System.EventHandler(this.bSave_Click);
            // 
            // customerAndProjectCtrl1
            // 
            this.customerAndProjectCtrl1.Location = new System.Drawing.Point(449, 15);
            this.customerAndProjectCtrl1.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.customerAndProjectCtrl1.Name = "customerAndProjectCtrl1";
            this.customerAndProjectCtrl1.Size = new System.Drawing.Size(418, 68);
            this.customerAndProjectCtrl1.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "Titel";
            // 
            // tbTitle
            // 
            this.tbTitle.Location = new System.Drawing.Point(104, 15);
            this.tbTitle.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbTitle.Name = "tbTitle";
            this.tbTitle.Size = new System.Drawing.Size(322, 27);
            this.tbTitle.TabIndex = 6;
            // 
            // itemTypeCtrl1
            // 
            this.itemTypeCtrl1.Location = new System.Drawing.Point(15, 53);
            this.itemTypeCtrl1.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.itemTypeCtrl1.Name = "itemTypeCtrl1";
            this.itemTypeCtrl1.Size = new System.Drawing.Size(411, 32);
            this.itemTypeCtrl1.TabIndex = 8;
            // 
            // estimatedTime1
            // 
            this.estimatedTime1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.estimatedTime1.Location = new System.Drawing.Point(3, 28);
            this.estimatedTime1.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.estimatedTime1.Name = "estimatedTime1";
            this.estimatedTime1.Size = new System.Drawing.Size(352, 153);
            this.estimatedTime1.TabIndex = 9;
            // 
            // workedTime1
            // 
            this.workedTime1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.workedTime1.Location = new System.Drawing.Point(10, 200);
            this.workedTime1.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.workedTime1.Name = "workedTime1";
            this.workedTime1.Size = new System.Drawing.Size(389, 257);
            this.workedTime1.TabIndex = 10;
            // 
            // bNew
            // 
            this.bNew.Location = new System.Drawing.Point(779, 713);
            this.bNew.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.bNew.Name = "bNew";
            this.bNew.Size = new System.Drawing.Size(86, 31);
            this.bNew.TabIndex = 11;
            this.bNew.Text = "Ny";
            this.bNew.UseVisualStyleBackColor = true;
            this.bNew.Click += new System.EventHandler(this.bNew_Click);
            // 
            // tabCtrl
            // 
            this.tabCtrl.Controls.Add(this.tabGeneral);
            this.tabCtrl.Controls.Add(this.tabDescription);
            this.tabCtrl.Controls.Add(this.tabChildren);
            this.tabCtrl.Controls.Add(this.tabWorkTime);
            this.tabCtrl.Controls.Add(this.tabInvoices);
            this.tabCtrl.Location = new System.Drawing.Point(0, 144);
            this.tabCtrl.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabCtrl.Name = "tabCtrl";
            this.tabCtrl.SelectedIndex = 0;
            this.tabCtrl.Size = new System.Drawing.Size(867, 561);
            this.tabCtrl.TabIndex = 12;
            this.tabCtrl.SelectedIndexChanged += new System.EventHandler(this.tabCtrl_SelectedIndexChanged);
            // 
            // tabGeneral
            // 
            this.tabGeneral.Controls.Add(this.rtbDescription);
            this.tabGeneral.Controls.Add(this.label2);
            this.tabGeneral.Controls.Add(this.estimatedTime1);
            this.tabGeneral.Controls.Add(this.workedTime1);
            this.tabGeneral.Location = new System.Drawing.Point(4, 29);
            this.tabGeneral.Name = "tabGeneral";
            this.tabGeneral.Size = new System.Drawing.Size(859, 528);
            this.tabGeneral.TabIndex = 3;
            this.tabGeneral.Text = "Allmänt";
            this.tabGeneral.UseVisualStyleBackColor = true;
            // 
            // tabDescription
            // 
            this.tabDescription.Location = new System.Drawing.Point(4, 29);
            this.tabDescription.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabDescription.Name = "tabDescription";
            this.tabDescription.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabDescription.Size = new System.Drawing.Size(859, 528);
            this.tabDescription.TabIndex = 1;
            this.tabDescription.Text = "Beskrivning";
            this.tabDescription.UseVisualStyleBackColor = true;
            // 
            // tabChildren
            // 
            this.tabChildren.Controls.Add(this.bAddSubActivities);
            this.tabChildren.Controls.Add(this.lvItems);
            this.tabChildren.Location = new System.Drawing.Point(4, 29);
            this.tabChildren.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabChildren.Name = "tabChildren";
            this.tabChildren.Size = new System.Drawing.Size(859, 528);
            this.tabChildren.TabIndex = 2;
            this.tabChildren.Text = "Del aktiviteter";
            this.tabChildren.UseVisualStyleBackColor = true;
            // 
            // bAddSubActivities
            // 
            this.bAddSubActivities.Location = new System.Drawing.Point(752, 438);
            this.bAddSubActivities.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.bAddSubActivities.Name = "bAddSubActivities";
            this.bAddSubActivities.Size = new System.Drawing.Size(86, 31);
            this.bAddSubActivities.TabIndex = 1;
            this.bAddSubActivities.Text = "Lägg till";
            this.bAddSubActivities.UseVisualStyleBackColor = true;
            this.bAddSubActivities.Click += new System.EventHandler(this.bAddSubActivities_Click);
            // 
            // lvItems
            // 
            this.lvItems.FullRowSelect = true;
            this.lvItems.GridLines = true;
            this.lvItems.Location = new System.Drawing.Point(25, 37);
            this.lvItems.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lvItems.MultiSelect = false;
            this.lvItems.Name = "lvItems";
            this.lvItems.Size = new System.Drawing.Size(813, 393);
            this.lvItems.TabIndex = 0;
            this.lvItems.UseCompatibleStateImageBehavior = false;
            this.lvItems.View = System.Windows.Forms.View.Details;
            this.lvItems.DoubleClick += new System.EventHandler(this.lvItems_DoubleClick);
            // 
            // tabWorkTime
            // 
            this.tabWorkTime.Controls.Add(this.bAddTime);
            this.tabWorkTime.Controls.Add(this.lvWorkTime);
            this.tabWorkTime.Location = new System.Drawing.Point(4, 29);
            this.tabWorkTime.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabWorkTime.Name = "tabWorkTime";
            this.tabWorkTime.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabWorkTime.Size = new System.Drawing.Size(859, 528);
            this.tabWorkTime.TabIndex = 0;
            this.tabWorkTime.Text = "Arbetad tid";
            this.tabWorkTime.UseVisualStyleBackColor = true;
            // 
            // bAddTime
            // 
            this.bAddTime.Location = new System.Drawing.Point(740, 86);
            this.bAddTime.Name = "bAddTime";
            this.bAddTime.Size = new System.Drawing.Size(94, 29);
            this.bAddTime.TabIndex = 4;
            this.bAddTime.Text = "Lägg till tid";
            this.bAddTime.UseVisualStyleBackColor = true;
            this.bAddTime.Click += new System.EventHandler(this.bAddTime_Click);
            // 
            // lvWorkTime
            // 
            this.lvWorkTime.FullRowSelect = true;
            this.lvWorkTime.GridLines = true;
            this.lvWorkTime.Location = new System.Drawing.Point(11, 81);
            this.lvWorkTime.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lvWorkTime.Name = "lvWorkTime";
            this.lvWorkTime.Size = new System.Drawing.Size(715, 419);
            this.lvWorkTime.TabIndex = 3;
            this.lvWorkTime.UseCompatibleStateImageBehavior = false;
            this.lvWorkTime.View = System.Windows.Forms.View.Details;
            this.lvWorkTime.SelectedIndexChanged += new System.EventHandler(this.lvWorkTime_SelectedIndexChanged);
            this.lvWorkTime.DoubleClick += new System.EventHandler(this.lvWorkTime_DoubleClick);
            // 
            // tabInvoices
            // 
            this.tabInvoices.Controls.Add(this.lvInvoice);
            this.tabInvoices.Location = new System.Drawing.Point(4, 29);
            this.tabInvoices.Name = "tabInvoices";
            this.tabInvoices.Size = new System.Drawing.Size(859, 528);
            this.tabInvoices.TabIndex = 4;
            this.tabInvoices.Text = "Fakturor";
            this.tabInvoices.UseVisualStyleBackColor = true;
            // 
            // lvInvoice
            // 
            this.lvInvoice.FullRowSelect = true;
            this.lvInvoice.GridLines = true;
            this.lvInvoice.Location = new System.Drawing.Point(25, 55);
            this.lvInvoice.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lvInvoice.Name = "lvInvoice";
            this.lvInvoice.Size = new System.Drawing.Size(701, 419);
            this.lvInvoice.TabIndex = 4;
            this.lvInvoice.UseCompatibleStateImageBehavior = false;
            this.lvInvoice.View = System.Windows.Forms.View.Details;
            this.lvInvoice.SelectedIndexChanged += new System.EventHandler(this.lvInvoice_SelectedIndexChanged);
            this.lvInvoice.DoubleClick += new System.EventHandler(this.lvInvoice_DoubleClick);
            // 
            // itemStatusCtrl1
            // 
            this.itemStatusCtrl1.Location = new System.Drawing.Point(15, 93);
            this.itemStatusCtrl1.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.itemStatusCtrl1.Name = "itemStatusCtrl1";
            this.itemStatusCtrl1.Size = new System.Drawing.Size(411, 32);
            this.itemStatusCtrl1.TabIndex = 13;
            // 
            // rtbDescription
            // 
            this.rtbDescription.Location = new System.Drawing.Point(466, 38);
            this.rtbDescription.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rtbDescription.Name = "rtbDescription";
            this.rtbDescription.Size = new System.Drawing.Size(370, 469);
            this.rtbDescription.TabIndex = 12;
            this.rtbDescription.Text = "";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(381, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 20);
            this.label2.TabIndex = 11;
            this.label2.Text = "Beskrivning";
            // 
            // HandleWorkItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(878, 753);
            this.Controls.Add(this.itemStatusCtrl1);
            this.Controls.Add(this.tabCtrl);
            this.Controls.Add(this.bNew);
            this.Controls.Add(this.itemTypeCtrl1);
            this.Controls.Add(this.tbTitle);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.customerAndProjectCtrl1);
            this.Controls.Add(this.bSave);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "HandleWorkItem";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "HandleWorkItems";
            this.Load += new System.EventHandler(this.HandleWorkItems_Load);
            this.tabCtrl.ResumeLayout(false);
            this.tabGeneral.ResumeLayout(false);
            this.tabGeneral.PerformLayout();
            this.tabChildren.ResumeLayout(false);
            this.tabWorkTime.ResumeLayout(false);
            this.tabInvoices.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Button bSave;
        private UserControls.CustomerAndProjectCtrl customerAndProjectCtrl1;
        private Label label1;
        private TextBox tbTitle;
        private UserControls.ItemTypeCtrl itemTypeCtrl1;
        private UserControls.EstimatedTimeCtrl estimatedTime1;
        private UserControls.WorkedTimeCtrl workedTime1;
        private Button bNew;
        private TabControl tabCtrl;
        private TabPage tabWorkTime;
        private TabPage tabDescription;
        private UserControls.ItemStatusCtrl itemStatusCtrl1;
        private TabPage tabChildren;
        private ListView lvItems;
        private Button bAddSubActivities;
        private TabPage tabGeneral;
        private ListView lvWorkTime;
        private Button bAddTime;
        private TabPage tabInvoices;
        private ListView lvInvoice;
        private RichTextBox rtbDescription;
        private Label label2;
    }
}