namespace PilotDesktop
{
    partial class PilotNavigator
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PilotNavigator));
            this.bSettings = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnToCodeGenerator = new System.Windows.Forms.Button();
            this.bRegisterAddon = new System.Windows.Forms.Button();
           
            this.button1 = new System.Windows.Forms.Button();
            this.Keg = new System.Windows.Forms.PictureBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Keg)).BeginInit();
            this.SuspendLayout();
            // 
            // bSettings
            // 
            this.bSettings.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bSettings.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.bSettings.BackgroundImage = global::PilotDesktop.Properties.Resources.GlassButton111;
            this.bSettings.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bSettings.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bSettings.FlatAppearance.BorderSize = 0;
            this.bSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bSettings.Font = new System.Drawing.Font("Nirmala UI Semilight", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.bSettings.ForeColor = System.Drawing.Color.LightSteelBlue;
            this.bSettings.ImageIndex = 66;
            this.bSettings.Location = new System.Drawing.Point(0, -1);
            this.bSettings.MinimumSize = new System.Drawing.Size(100, 0);
            this.bSettings.Name = "bSettings";
            this.bSettings.Size = new System.Drawing.Size(109, 36);
            this.bSettings.TabIndex = 1;
            this.bSettings.Text = "Settings";
            this.bSettings.UseVisualStyleBackColor = false;
            this.bSettings.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.btnToCodeGenerator);
            this.panel1.Controls.Add(this.bRegisterAddon);

            this.panel1.Controls.Add(this.button1);
            this.panel1.Location = new System.Drawing.Point(0, 34);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(109, 158);
            this.panel1.TabIndex = 4;
            // 
            // bRegisterAddon
            // 
            this.bRegisterAddon.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bRegisterAddon.BackColor = System.Drawing.Color.Transparent;
            this.bRegisterAddon.BackgroundImage = global::PilotDesktop.Properties.Resources.GlassButtonGeneral1;
            this.bRegisterAddon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bRegisterAddon.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bRegisterAddon.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.bRegisterAddon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bRegisterAddon.Font = new System.Drawing.Font("Nirmala UI Semilight", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.bRegisterAddon.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.bRegisterAddon.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.bRegisterAddon.Location = new System.Drawing.Point(3, 110);
            this.bRegisterAddon.MinimumSize = new System.Drawing.Size(100, 0);
            this.bRegisterAddon.Name = "bRegisterAddon";
            this.bRegisterAddon.Size = new System.Drawing.Size(100, 45);
            this.bRegisterAddon.TabIndex = 7;
            this.bRegisterAddon.Text = "Hantera addon";
            this.bRegisterAddon.UseVisualStyleBackColor = false;
            this.bRegisterAddon.Click += new System.EventHandler(this.bRegisterAddon_Click);
            // 
            // button2
            // 
            this.btnToCodeGenerator.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnToCodeGenerator.BackColor = System.Drawing.Color.Transparent;
            this.btnToCodeGenerator.BackgroundImage = global::PilotDesktop.Properties.Resources.GlassButtonGeneral1;
            this.btnToCodeGenerator.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnToCodeGenerator.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnToCodeGenerator.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnToCodeGenerator.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnToCodeGenerator.Font = new System.Drawing.Font("Nirmala UI Semilight", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnToCodeGenerator.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btnToCodeGenerator.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnToCodeGenerator.Location = new System.Drawing.Point(5, 59);
            this.btnToCodeGenerator.MinimumSize = new System.Drawing.Size(100, 0);
            this.btnToCodeGenerator.Name = "btnToCodeGenerator";
            this.btnToCodeGenerator.Size = new System.Drawing.Size(100, 45);
            this.btnToCodeGenerator.TabIndex = 6;
            this.btnToCodeGenerator.Text = "Code generator";
            this.btnToCodeGenerator.UseVisualStyleBackColor = false;
            this.btnToCodeGenerator.Click += new System.EventHandler(this.btnToCodeGenerator_Click);
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.BackgroundImage = global::PilotDesktop.Properties.Resources.GlassButtonGeneral1;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Nirmala UI Semilight", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.Location = new System.Drawing.Point(5, 7);
            this.button1.MinimumSize = new System.Drawing.Size(100, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 45);
            this.button1.TabIndex = 5;
            this.button1.Text = "Project handler";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // Keg
            // 
            this.Keg.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Keg.BackColor = System.Drawing.Color.Transparent;
            this.Keg.BackgroundImage = global::PilotDesktop.Properties.Resources.keg1;
            this.Keg.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Keg.Location = new System.Drawing.Point(4, 5);
            this.Keg.MaximumSize = new System.Drawing.Size(25, 25);
            this.Keg.MinimumSize = new System.Drawing.Size(25, 25);
            this.Keg.Name = "Keg";
            this.Keg.Size = new System.Drawing.Size(25, 25);
            this.Keg.TabIndex = 5;
            this.Keg.TabStop = false;
            this.Keg.Click += new System.EventHandler(this.Keg_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.BackColor = System.Drawing.Color.Transparent;
            this.toolStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.toolStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.VerticalStackWithOverflow;
            this.toolStrip1.Location = new System.Drawing.Point(0, 195);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.toolStrip1.Size = new System.Drawing.Size(113, 210);
            this.toolStrip1.Stretch = true;
            this.toolStrip1.TabIndex = 3;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // PilotNavigator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackgroundImage = global::PilotDesktop.Properties.Resources.reflection1;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(109, 359);
            this.Controls.Add(this.Keg);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.bSettings);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(800, 800);
            this.MdiChildrenMinimizedAnchorBottom = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(100, 300);
            this.Name = "PilotNavigator";
            this.Opacity = 0.96D;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Pilot";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.PilotNavigator_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Keg)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Button bSettings;
        private Panel panel1;
        private Button btnToCodeGenerator;
        private Button button1;
        private PictureBox Keg;
        private ToolStrip toolStrip1;
        private Button bRegisterAddon;
    }
}