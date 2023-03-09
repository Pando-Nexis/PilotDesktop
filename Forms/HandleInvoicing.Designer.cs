namespace PilotDesktop.Forms
{
    partial class HandleInvoicing
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
            this.lvItems = new System.Windows.Forms.ListView();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.customerCtrl1 = new PilotDesktop.UserControls.CustomerCtrl();
            this.bInvoice = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lvItems
            // 
            this.lvItems.FullRowSelect = true;
            this.lvItems.GridLines = true;
            this.lvItems.Location = new System.Drawing.Point(12, 107);
            this.lvItems.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lvItems.Name = "lvItems";
            this.lvItems.Size = new System.Drawing.Size(1597, 472);
            this.lvItems.TabIndex = 2;
            this.lvItems.UseCompatibleStateImageBehavior = false;
            this.lvItems.View = System.Windows.Forms.View.Details;
            this.lvItems.DoubleClick += new System.EventHandler(this.lvItems_DoubleClick);
            // 
            // dtpTo
            // 
            this.dtpTo.CustomFormat = "yyyy-MM-dd HH:mm";
            this.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTo.Location = new System.Drawing.Point(508, 52);
            this.dtpTo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(169, 27);
            this.dtpTo.TabIndex = 14;
            // 
            // dtpFrom
            // 
            this.dtpFrom.CustomFormat = "yyyy-MM-dd HH:mm";
            this.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFrom.Location = new System.Drawing.Point(508, 13);
            this.dtpFrom.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(169, 27);
            this.dtpFrom.TabIndex = 13;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(455, 52);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 20);
            this.label4.TabIndex = 16;
            this.label4.Text = "Till";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(455, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 20);
            this.label2.TabIndex = 15;
            this.label2.Text = "Från";
            // 
            // customerCtrl1
            // 
            this.customerCtrl1.Location = new System.Drawing.Point(15, 13);
            this.customerCtrl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.customerCtrl1.Name = "customerCtrl1";
            this.customerCtrl1.Size = new System.Drawing.Size(514, 40);
            this.customerCtrl1.TabIndex = 17;
            this.customerCtrl1.OnIndexChanged += new System.EventHandler(this.customerCtrl1_OnIndexChanged);
            // 
            // bInvoice
            // 
            this.bInvoice.Location = new System.Drawing.Point(715, 50);
            this.bInvoice.Name = "bInvoice";
            this.bInvoice.Size = new System.Drawing.Size(94, 29);
            this.bInvoice.TabIndex = 18;
            this.bInvoice.Text = "Fakturera";
            this.bInvoice.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.bInvoice.UseVisualStyleBackColor = true;
            this.bInvoice.Click += new System.EventHandler(this.bInvoice_Click);
            // 
            // HandleInvoicing
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1649, 623);
            this.Controls.Add(this.bInvoice);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtpTo);
            this.Controls.Add(this.dtpFrom);
            this.Controls.Add(this.lvItems);
            this.Controls.Add(this.customerCtrl1);
            this.Name = "HandleInvoicing";
            this.Text = "HandleInvoicing";
            this.Load += new System.EventHandler(this.HandleInvoicing_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ListView lvItems;
        private DateTimePicker dtpTo;
        private DateTimePicker dtpFrom;
        private Label label4;
        private Label label2;
        private UserControls.CustomerCtrl customerCtrl1;
        private Button bInvoice;
    }
}