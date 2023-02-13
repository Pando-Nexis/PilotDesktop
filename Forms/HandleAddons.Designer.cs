namespace PilotDesktop.Forms
{
    partial class HandleAddons
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
            this.tvAddons = new System.Windows.Forms.TreeView();
            this.bRegister = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tbAddOn = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // tvAddons
            // 
            this.tvAddons.Location = new System.Drawing.Point(23, 27);
            this.tvAddons.Name = "tvAddons";
            this.tvAddons.Size = new System.Drawing.Size(281, 374);
            this.tvAddons.TabIndex = 1;
            this.tvAddons.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvAddons_AfterSelect);
            // 
            // bRegister
            // 
            this.bRegister.Enabled = false;
            this.bRegister.Location = new System.Drawing.Point(640, 27);
            this.bRegister.Name = "bRegister";
            this.bRegister.Size = new System.Drawing.Size(133, 23);
            this.bRegister.TabIndex = 6;
            this.bRegister.Text = "Kontrollerar status";
            this.bRegister.UseVisualStyleBackColor = true;
            this.bRegister.Click += new System.EventHandler(this.bRegister_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(317, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 15);
            this.label1.TabIndex = 5;
            this.label1.Text = "AddOn id";
            // 
            // tbAddOn
            // 
            this.tbAddOn.Location = new System.Drawing.Point(381, 27);
            this.tbAddOn.Name = "tbAddOn";
            this.tbAddOn.Size = new System.Drawing.Size(253, 23);
            this.tbAddOn.TabIndex = 4;
            // 
            // HandleAddons
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.bRegister);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbAddOn);
            this.Controls.Add(this.tvAddons);
            this.Name = "HandleAddons";
            this.Text = "RegesteredAddon";
            this.Load += new System.EventHandler(this.HandleAddons_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TreeView tvAddons;
        private Button bRegister;
        private Label label1;
        private TextBox tbAddOn;
    }
}