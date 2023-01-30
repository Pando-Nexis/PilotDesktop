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
            this.label3.Location = new System.Drawing.Point(3, 110);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 15);
            this.label3.TabIndex = 10;
            this.label3.Text = "Kommentar";
            // 
            // rtbComment
            // 
            this.rtbComment.Enabled = false;
            this.rtbComment.Location = new System.Drawing.Point(82, 110);
            this.rtbComment.Name = "rtbComment";
            this.rtbComment.Size = new System.Drawing.Size(222, 76);
            this.rtbComment.TabIndex = 9;
            this.rtbComment.Text = "";
            // 
            // tbWorkedTime
            // 
            this.tbWorkedTime.Enabled = false;
            this.tbWorkedTime.Location = new System.Drawing.Point(82, 48);
            this.tbWorkedTime.Name = "tbWorkedTime";
            this.tbWorkedTime.Size = new System.Drawing.Size(45, 23);
            this.tbWorkedTime.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 15);
            this.label1.TabIndex = 7;
            this.label1.Text = "Arbetad tid";
            // 
            // dtpFrom
            // 
            this.dtpFrom.CustomFormat = "yyyy-MM-dd hh:mm";
            this.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFrom.Location = new System.Drawing.Point(175, 48);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(129, 23);
            this.dtpFrom.TabIndex = 11;
            // 
            // dtpTo
            // 
            this.dtpTo.CustomFormat = "yyyy-MM-dd hh:mm";
            this.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTo.Location = new System.Drawing.Point(175, 77);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(129, 23);
            this.dtpTo.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(139, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 15);
            this.label2.TabIndex = 13;
            this.label2.Text = "Från";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(139, 83);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(22, 15);
            this.label4.TabIndex = 14;
            this.label4.Text = "Till";
            // 
            // bTimer
            // 
            this.bTimer.Location = new System.Drawing.Point(13, 75);
            this.bTimer.Name = "bTimer";
            this.bTimer.Size = new System.Drawing.Size(114, 23);
            this.bTimer.TabIndex = 15;
            this.bTimer.Text = "Starta timer";
            this.bTimer.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 10);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 15);
            this.label5.TabIndex = 16;
            this.label5.Text = "Total tid";
            // 
            // tbTotalTime
            // 
            this.tbTotalTime.Enabled = false;
            this.tbTotalTime.Location = new System.Drawing.Point(82, 7);
            this.tbTotalTime.Name = "tbTotalTime";
            this.tbTotalTime.Size = new System.Drawing.Size(99, 23);
            this.tbTotalTime.TabIndex = 17;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(198, 7);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 18;
            this.button2.Text = "Visa lista";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(0, 25);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(307, 15);
            this.label6.TabIndex = 19;
            this.label6.Text = "____________________________________________________________";
            // 
            // WorkedTimeCtrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
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
            this.Name = "WorkedTimeCtrl";
            this.Size = new System.Drawing.Size(308, 193);
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
