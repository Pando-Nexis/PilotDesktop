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
            bSettings = new Button();
            panel1 = new Panel();
            bHandleAddOn = new Button();
            btnToCodeGenerator = new Button();
            btnToOblivion = new Button();
            Keg = new PictureBox();
            toolStrip1 = new ToolStrip();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)Keg).BeginInit();
            SuspendLayout();
            // 
            // bSettings
            // 
            bSettings.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            bSettings.BackColor = Color.FromArgb(64, 64, 64);
            bSettings.BackgroundImage = Properties.Resources.GlassButton111;
            bSettings.BackgroundImageLayout = ImageLayout.Stretch;
            bSettings.Cursor = Cursors.Hand;
            bSettings.FlatAppearance.BorderSize = 0;
            bSettings.FlatStyle = FlatStyle.Flat;
            bSettings.Font = new Font("Nirmala UI Semilight", 8F, FontStyle.Regular, GraphicsUnit.Point);
            bSettings.ForeColor = Color.LightSteelBlue;
            bSettings.ImageIndex = 66;
            bSettings.Location = new Point(0, -1);
            bSettings.Margin = new Padding(3, 4, 3, 4);
            bSettings.MinimumSize = new Size(114, 0);
            bSettings.Name = "bSettings";
            bSettings.Size = new Size(125, 48);
            bSettings.TabIndex = 1;
            bSettings.Text = "    Inställningar";
            bSettings.UseVisualStyleBackColor = false;
            bSettings.Click += btnSettings_Click;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel1.BackColor = Color.Transparent;
            panel1.Controls.Add(bHandleAddOn);
            panel1.Controls.Add(btnToCodeGenerator);
            panel1.Controls.Add(btnToOblivion);
            panel1.Location = new Point(0, 45);
            panel1.Margin = new Padding(3, 4, 3, 4);
            panel1.Name = "panel1";
            panel1.Size = new Size(125, 211);
            panel1.TabIndex = 4;
            // 
            // bHandleAddOn
            // 
            bHandleAddOn.Anchor = AnchorStyles.Top;
            bHandleAddOn.BackColor = Color.Transparent;
            bHandleAddOn.BackgroundImage = Properties.Resources.GlassButtonGeneral1;
            bHandleAddOn.BackgroundImageLayout = ImageLayout.Stretch;
            bHandleAddOn.Cursor = Cursors.Hand;
            bHandleAddOn.FlatAppearance.BorderColor = Color.White;
            bHandleAddOn.FlatStyle = FlatStyle.Flat;
            bHandleAddOn.Font = new Font("Nirmala UI Semilight", 9F, FontStyle.Regular, GraphicsUnit.Point);
            bHandleAddOn.ForeColor = Color.FromArgb(64, 0, 64);
            bHandleAddOn.ImageAlign = ContentAlignment.MiddleRight;
            bHandleAddOn.Location = new Point(6, 147);
            bHandleAddOn.Margin = new Padding(3, 4, 3, 4);
            bHandleAddOn.MinimumSize = new Size(114, 0);
            bHandleAddOn.Name = "bHandleAddOn";
            bHandleAddOn.Size = new Size(114, 60);
            bHandleAddOn.TabIndex = 7;
            bHandleAddOn.Text = "Hantera AddOn";
            bHandleAddOn.UseVisualStyleBackColor = false;
            bHandleAddOn.Click += bHandleAddOn_Click;
            // 
            // btnToCodeGenerator
            // 
            btnToCodeGenerator.Anchor = AnchorStyles.Top;
            btnToCodeGenerator.BackColor = Color.Transparent;
            btnToCodeGenerator.BackgroundImage = Properties.Resources.GlassButtonGeneral1;
            btnToCodeGenerator.BackgroundImageLayout = ImageLayout.Stretch;
            btnToCodeGenerator.Cursor = Cursors.Hand;
            btnToCodeGenerator.FlatAppearance.BorderColor = Color.White;
            btnToCodeGenerator.FlatStyle = FlatStyle.Flat;
            btnToCodeGenerator.Font = new Font("Nirmala UI Semilight", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btnToCodeGenerator.ForeColor = Color.FromArgb(64, 0, 64);
            btnToCodeGenerator.ImageAlign = ContentAlignment.MiddleRight;
            btnToCodeGenerator.Location = new Point(6, 79);
            btnToCodeGenerator.Margin = new Padding(3, 4, 3, 4);
            btnToCodeGenerator.MinimumSize = new Size(114, 0);
            btnToCodeGenerator.Name = "btnToCodeGenerator";
            btnToCodeGenerator.Size = new Size(114, 60);
            btnToCodeGenerator.TabIndex = 6;
            btnToCodeGenerator.Text = "Kodgenerator";
            btnToCodeGenerator.UseVisualStyleBackColor = false;
            btnToCodeGenerator.Click += btnToCodeGenerator_Click;
            // 
            // btnToOblivion
            // 
            btnToOblivion.Anchor = AnchorStyles.Top;
            btnToOblivion.BackColor = Color.Transparent;
            btnToOblivion.BackgroundImage = Properties.Resources.GlassButtonGeneral1;
            btnToOblivion.BackgroundImageLayout = ImageLayout.Stretch;
            btnToOblivion.Cursor = Cursors.Hand;
            btnToOblivion.FlatAppearance.BorderColor = Color.White;
            btnToOblivion.FlatStyle = FlatStyle.Flat;
            btnToOblivion.Font = new Font("Nirmala UI Semilight", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btnToOblivion.ForeColor = Color.FromArgb(64, 0, 64);
            btnToOblivion.ImageAlign = ContentAlignment.MiddleRight;
            btnToOblivion.Location = new Point(6, 9);
            btnToOblivion.Margin = new Padding(3, 4, 3, 4);
            btnToOblivion.MinimumSize = new Size(114, 0);
            btnToOblivion.Name = "btnToOblivion";
            btnToOblivion.Size = new Size(114, 60);
            btnToOblivion.TabIndex = 5;
            btnToOblivion.Text = "Aktiviteter";
            btnToOblivion.UseVisualStyleBackColor = false;
            btnToOblivion.Click += button1_Click_1;
            // 
            // Keg
            // 
            Keg.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            Keg.BackColor = Color.Transparent;
            Keg.BackgroundImage = Properties.Resources.keg1;
            Keg.BackgroundImageLayout = ImageLayout.Stretch;
            Keg.Location = new Point(5, 7);
            Keg.Margin = new Padding(3, 4, 3, 4);
            Keg.MaximumSize = new Size(29, 33);
            Keg.MinimumSize = new Size(29, 33);
            Keg.Name = "Keg";
            Keg.Size = new Size(29, 33);
            Keg.TabIndex = 5;
            Keg.TabStop = false;
            Keg.Click += Keg_Click;
            // 
            // toolStrip1
            // 
            toolStrip1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            toolStrip1.AutoSize = false;
            toolStrip1.BackColor = Color.Transparent;
            toolStrip1.BackgroundImageLayout = ImageLayout.Center;
            toolStrip1.Dock = DockStyle.None;
            toolStrip1.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            toolStrip1.ImageScalingSize = new Size(20, 20);
            toolStrip1.LayoutStyle = ToolStripLayoutStyle.VerticalStackWithOverflow;
            toolStrip1.Location = new Point(0, 260);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.RenderMode = ToolStripRenderMode.Professional;
            toolStrip1.Size = new Size(129, 280);
            toolStrip1.Stretch = true;
            toolStrip1.TabIndex = 3;
            toolStrip1.Text = "toolStrip1";
            // 
            // PilotNavigator
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BackgroundImage = Properties.Resources.reflection1;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(169, 479);
            Controls.Add(Keg);
            Controls.Add(panel1);
            Controls.Add(toolStrip1);
            Controls.Add(bSettings);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            MaximumSize = new Size(912, 1051);
            MdiChildrenMinimizedAnchorBottom = false;
            MinimizeBox = false;
            MinimumSize = new Size(112, 384);
            Name = "PilotNavigator";
            Opacity = 0.96D;
            SizeGripStyle = SizeGripStyle.Show;
            StartPosition = FormStartPosition.Manual;
            Text = "Pilot";
            TopMost = true;
            Load += PilotNavigator_Load;
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)Keg).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Button bSettings;
        private Panel panel1;
        private Button btnToCodeGenerator;
        private Button btnToOblivion;
        private PictureBox Keg;
        private ToolStrip toolStrip1;
        private Button bHandleAddOn;
    }
}