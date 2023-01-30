namespace PilotDesktop.UserControls
{
    partial class EstimatedTimeCtrl
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
            this.label1 = new System.Windows.Forms.Label();
            this.tbEstimate = new System.Windows.Forms.TextBox();
            this.tbRisk = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.rtbComment = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tbMax = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Estimat";
            // 
            // tbEstimate
            // 
            this.tbEstimate.Enabled = false;
            this.tbEstimate.Location = new System.Drawing.Point(82, 5);
            this.tbEstimate.Name = "tbEstimate";
            this.tbEstimate.Size = new System.Drawing.Size(45, 23);
            this.tbEstimate.TabIndex = 1;
            this.tbEstimate.TextChanged += new System.EventHandler(this.tbEstimate_TextChanged);
            this.tbEstimate.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tbExtimate_KeyUp);
            // 
            // tbRisk
            // 
            this.tbRisk.Enabled = false;
            this.tbRisk.Location = new System.Drawing.Point(172, 5);
            this.tbRisk.Name = "tbRisk";
            this.tbRisk.Size = new System.Drawing.Size(45, 23);
            this.tbRisk.TabIndex = 4;
            this.tbRisk.TextChanged += new System.EventHandler(this.tbRisk_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(138, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Risk";
            // 
            // rtbComment
            // 
            this.rtbComment.Enabled = false;
            this.rtbComment.Location = new System.Drawing.Point(82, 34);
            this.rtbComment.Name = "rtbComment";
            this.rtbComment.Size = new System.Drawing.Size(222, 76);
            this.rtbComment.TabIndex = 5;
            this.rtbComment.Text = "";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 37);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 15);
            this.label3.TabIndex = 6;
            this.label3.Text = "Kommentar";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(223, 8);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 15);
            this.label4.TabIndex = 7;
            this.label4.Text = "Max";
            // 
            // tbMax
            // 
            this.tbMax.Enabled = false;
            this.tbMax.Location = new System.Drawing.Point(259, 5);
            this.tbMax.Name = "tbMax";
            this.tbMax.Size = new System.Drawing.Size(45, 23);
            this.tbMax.TabIndex = 8;
            // 
            // EstimatedTime
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.tbMax);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.rtbComment);
            this.Controls.Add(this.tbRisk);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbEstimate);
            this.Controls.Add(this.label1);
            this.Name = "EstimatedTime";
            this.Size = new System.Drawing.Size(310, 115);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private TextBox tbEstimate;
        private TextBox tbRisk;
        private Label label2;
        private RichTextBox rtbComment;
        private Label label3;
        private Label label4;
        private TextBox tbMax;
    }
}
