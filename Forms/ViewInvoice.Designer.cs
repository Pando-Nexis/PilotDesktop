namespace PilotDesktop.Forms
{
    partial class ViewInvoice
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
            this.bToExcel = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // bToExcel
            // 
            this.bToExcel.Location = new System.Drawing.Point(939, 26);
            this.bToExcel.Name = "bToExcel";
            this.bToExcel.Size = new System.Drawing.Size(94, 29);
            this.bToExcel.TabIndex = 18;
            this.bToExcel.Text = "Till excel";
            this.bToExcel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.bToExcel.UseVisualStyleBackColor = true;
            this.bToExcel.Click += new System.EventHandler(this.bToExcel_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(23, 56);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 29;
            this.dataGridView1.Size = new System.Drawing.Size(910, 555);
            this.dataGridView1.TabIndex = 19;
            // 
            // ViewInvoice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1064, 623);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.bToExcel);
            this.Name = "ViewInvoice";
            this.Text = "Invoice";
            this.Load += new System.EventHandler(this.HandleInvoicing_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Button bToExcel;
        private DataGridView dataGridView1;
    }
}