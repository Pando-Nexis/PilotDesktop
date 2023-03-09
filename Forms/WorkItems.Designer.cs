namespace PilotDesktop.Forms
{
    partial class WorkItems
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
            this.bNewWorkItem = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lvItems
            // 
            this.lvItems.FullRowSelect = true;
            this.lvItems.GridLines = true;
            this.lvItems.Location = new System.Drawing.Point(14, 85);
            this.lvItems.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lvItems.Name = "lvItems";
            this.lvItems.Size = new System.Drawing.Size(1264, 529);
            this.lvItems.TabIndex = 0;
            this.lvItems.UseCompatibleStateImageBehavior = false;
            this.lvItems.View = System.Windows.Forms.View.Details;
            this.lvItems.SelectedIndexChanged += new System.EventHandler(this.lvItems_SelectedIndexChanged);
            this.lvItems.DoubleClick += new System.EventHandler(this.lvItems_DoubleClick);
            // 
            // bNewWorkItem
            // 
            this.bNewWorkItem.Location = new System.Drawing.Point(798, 47);
            this.bNewWorkItem.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.bNewWorkItem.Name = "bNewWorkItem";
            this.bNewWorkItem.Size = new System.Drawing.Size(86, 31);
            this.bNewWorkItem.TabIndex = 1;
            this.bNewWorkItem.Text = "Nytt";
            this.bNewWorkItem.UseVisualStyleBackColor = true;
            this.bNewWorkItem.Click += new System.EventHandler(this.button1_Click);
            // 
            // WorkItems
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1290, 651);
            this.Controls.Add(this.bNewWorkItem);
            this.Controls.Add(this.lvItems);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "WorkItems";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "WorkItems";
            this.Load += new System.EventHandler(this.WorkItems_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private ListView lvItems;
        private Button bNewWorkItem;
    }
}