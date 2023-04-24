namespace PilotDesktop.Forms
{
    partial class WorkTimeCalender
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
            this.customerAndProjectCtrl1 = new PilotDesktop.UserControls.CustomerAndProjectCtrl();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.bRefresh = new System.Windows.Forms.Button();
            this.tbOpenWorkItem = new System.Windows.Forms.TextBox();
            this.bOpen = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // customerAndProjectCtrl1
            // 
            this.customerAndProjectCtrl1.Location = new System.Drawing.Point(315, 13);
            this.customerAndProjectCtrl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.customerAndProjectCtrl1.Name = "customerAndProjectCtrl1";
            this.customerAndProjectCtrl1.Size = new System.Drawing.Size(522, 85);
            this.customerAndProjectCtrl1.TabIndex = 0;
            this.customerAndProjectCtrl1.OnIndexChanged += new System.EventHandler(this.customerAndProjectCtrl1_OnIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(56, 60);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 20);
            this.label4.TabIndex = 18;
            this.label4.Text = "Till";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(56, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 20);
            this.label2.TabIndex = 17;
            this.label2.Text = "Från";
            // 
            // dtpTo
            // 
            this.dtpTo.CustomFormat = "yyyy-MM-dd HH:mm";
            this.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTo.Location = new System.Drawing.Point(97, 52);
            this.dtpTo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(169, 27);
            this.dtpTo.TabIndex = 16;
            this.dtpTo.ValueChanged += new System.EventHandler(this.dtpTo_ValueChanged);
            // 
            // dtpFrom
            // 
            this.dtpFrom.CustomFormat = "yyyy-MM-dd HH:mm";
            this.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFrom.Location = new System.Drawing.Point(97, 13);
            this.dtpFrom.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(169, 27);
            this.dtpFrom.TabIndex = 15;
            this.dtpFrom.ValueChanged += new System.EventHandler(this.dtpFrom_ValueChanged);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(22, 105);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 29;
            this.dataGridView1.Size = new System.Drawing.Size(1450, 610);
            this.dataGridView1.TabIndex = 19;
            // 
            // bRefresh
            // 
            this.bRefresh.Location = new System.Drawing.Point(1346, 60);
            this.bRefresh.Name = "bRefresh";
            this.bRefresh.Size = new System.Drawing.Size(94, 29);
            this.bRefresh.TabIndex = 20;
            this.bRefresh.Text = "Uppdatera";
            this.bRefresh.UseVisualStyleBackColor = true;
            this.bRefresh.Click += new System.EventHandler(this.bRefresh_Click);
            // 
            // tbOpenWorkItem
            // 
            this.tbOpenWorkItem.Location = new System.Drawing.Point(1247, 18);
            this.tbOpenWorkItem.Name = "tbOpenWorkItem";
            this.tbOpenWorkItem.Size = new System.Drawing.Size(84, 27);
            this.tbOpenWorkItem.TabIndex = 21;
            // 
            // bOpen
            // 
            this.bOpen.Location = new System.Drawing.Point(1346, 16);
            this.bOpen.Name = "bOpen";
            this.bOpen.Size = new System.Drawing.Size(94, 29);
            this.bOpen.TabIndex = 22;
            this.bOpen.Text = "Öppna";
            this.bOpen.UseVisualStyleBackColor = true;
            this.bOpen.Click += new System.EventHandler(this.bOpen_Click);
            // 
            // WorkTimeCalender
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1484, 727);
            this.Controls.Add(this.bOpen);
            this.Controls.Add(this.tbOpenWorkItem);
            this.Controls.Add(this.bRefresh);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtpTo);
            this.Controls.Add(this.dtpFrom);
            this.Controls.Add(this.customerAndProjectCtrl1);
            this.Name = "WorkTimeCalender";
            this.Text = "WorkTimeCalender";
            this.Load += new System.EventHandler(this.WorkTimeCalender_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private UserControls.CustomerAndProjectCtrl customerAndProjectCtrl1;
        private Label label4;
        private Label label2;
        private DateTimePicker dtpTo;
        private DateTimePicker dtpFrom;
        private DataGridView dataGridView1;
        private Button bRefresh;
        private TextBox tbOpenWorkItem;
        private Button bOpen;
    }
}