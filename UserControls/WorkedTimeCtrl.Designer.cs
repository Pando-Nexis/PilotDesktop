namespace PilotDesktop.UserControls
{
    partial class WorkedTimeCtrl
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
            this.label3 = new System.Windows.Forms.Label();
            this.rtbComment = new System.Windows.Forms.RichTextBox();
            this.tbWorkedTime = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.bTimer = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.tbTotalTime = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 147);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 20);
            this.label3.TabIndex = 10;
            this.label3.Text = "Kommentar";
            // 
            // rtbComment
            // 
            this.rtbComment.Location = new System.Drawing.Point(94, 147);
            this.rtbComment.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rtbComment.Name = "rtbComment";
            this.rtbComment.Size = new System.Drawing.Size(275, 100);
            this.rtbComment.TabIndex = 9;
            this.rtbComment.Text = "";
            // 
            // tbWorkedTime
            // 
            this.tbWorkedTime.Location = new System.Drawing.Point(94, 64);
            this.tbWorkedTime.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbWorkedTime.Name = "tbWorkedTime";
            this.tbWorkedTime.Size = new System.Drawing.Size(51, 27);
            this.tbWorkedTime.TabIndex = 8;
            this.tbWorkedTime.TextChanged += new System.EventHandler(this.tbWorkedTime_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 20);
            this.label1.TabIndex = 7;
            this.label1.Text = "Arbetad tid";
            // 
            // dtpFrom
            // 
            this.dtpFrom.CustomFormat = "yyyy-MM-dd HH:mm";
            this.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFrom.Location = new System.Drawing.Point(200, 64);
            this.dtpFrom.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(169, 27);
            this.dtpFrom.TabIndex = 11;
            this.dtpFrom.ValueChanged += new System.EventHandler(this.dtpFrom_ValueChanged);
            // 
            // dtpTo
            // 
            this.dtpTo.CustomFormat = "yyyy-MM-dd HH:mm";
            this.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTo.Location = new System.Drawing.Point(200, 103);
            this.dtpTo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(169, 27);
            this.dtpTo.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(159, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 20);
            this.label2.TabIndex = 13;
            this.label2.Text = "Från";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(159, 111);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 20);
            this.label4.TabIndex = 14;
            this.label4.Text = "Till";
            // 
            // bTimer
            // 
            this.bTimer.Location = new System.Drawing.Point(15, 100);
            this.bTimer.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.bTimer.Name = "bTimer";
            this.bTimer.Size = new System.Drawing.Size(130, 31);
            this.bTimer.TabIndex = 15;
            this.bTimer.Text = "Starta timer";
            this.bTimer.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 13);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 20);
            this.label5.TabIndex = 16;
            this.label5.Text = "Total tid";
            // 
            // tbTotalTime
            // 
            this.tbTotalTime.Enabled = false;
            this.tbTotalTime.Location = new System.Drawing.Point(94, 9);
            this.tbTotalTime.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbTotalTime.Name = "tbTotalTime";
            this.tbTotalTime.Size = new System.Drawing.Size(113, 27);
            this.tbTotalTime.TabIndex = 17;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(226, 9);
            this.button2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(86, 31);
            this.button2.TabIndex = 18;
            this.button2.Text = "Visa lista";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(0, 33);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(369, 20);
            this.label6.TabIndex = 19;
            this.label6.Text = "____________________________________________________________";
            // 
            // WorkedTimeCtrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.button2);
            this.Controls.Add(this.tbTotalTime);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.bTimer);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtpTo);
            this.Controls.Add(this.dtpFrom);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.rtbComment);
            this.Controls.Add(this.tbWorkedTime);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label6);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "WorkedTimeCtrl";
            this.Size = new System.Drawing.Size(390, 261);
            this.Load += new System.EventHandler(this.WorkedTime_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label3;
        private RichTextBox rtbComment;
        private TextBox tbWorkedTime;
        private Label label1;
        private DateTimePicker dtpFrom;
        private DateTimePicker dtpTo;
        private Label label2;
        private Label label4;
        private Button bTimer;
        private Label label5;
        private TextBox tbTotalTime;
        private Button button2;
        private Label label6;
    }
}
