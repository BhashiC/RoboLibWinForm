namespace RoboLib.GUI.Pages
{
    partial class ComponentGeneralPage
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.gbViewOnly = new System.Windows.Forms.GroupBox();
            this.panelViewOnly = new System.Windows.Forms.Panel();
            this.gbSettings = new System.Windows.Forms.GroupBox();
            this.panelSettings = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.gbViewOnly.SuspendLayout();
            this.gbSettings.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.gbViewOnly);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.gbSettings);
            this.splitContainer1.Size = new System.Drawing.Size(310, 559);
            this.splitContainer1.SplitterDistance = 160;
            this.splitContainer1.TabIndex = 0;
            // 
            // gbViewOnly
            // 
            this.gbViewOnly.Controls.Add(this.panelViewOnly);
            this.gbViewOnly.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbViewOnly.Location = new System.Drawing.Point(0, 0);
            this.gbViewOnly.Name = "gbViewOnly";
            this.gbViewOnly.Size = new System.Drawing.Size(310, 160);
            this.gbViewOnly.TabIndex = 0;
            this.gbViewOnly.TabStop = false;
            this.gbViewOnly.Text = "View  Only";
            // 
            // panelViewOnly
            // 
            this.panelViewOnly.AutoScroll = true;
            this.panelViewOnly.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelViewOnly.Location = new System.Drawing.Point(3, 16);
            this.panelViewOnly.Name = "panelViewOnly";
            this.panelViewOnly.Size = new System.Drawing.Size(304, 141);
            this.panelViewOnly.TabIndex = 0;
            // 
            // gbSettings
            // 
            this.gbSettings.Controls.Add(this.panelSettings);
            this.gbSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbSettings.Location = new System.Drawing.Point(0, 0);
            this.gbSettings.Name = "gbSettings";
            this.gbSettings.Size = new System.Drawing.Size(310, 395);
            this.gbSettings.TabIndex = 1;
            this.gbSettings.TabStop = false;
            this.gbSettings.Text = "Settings";
            // 
            // panelSettings
            // 
            this.panelSettings.AutoScroll = true;
            this.panelSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelSettings.Location = new System.Drawing.Point(3, 16);
            this.panelSettings.Name = "panelSettings";
            this.panelSettings.Size = new System.Drawing.Size(304, 376);
            this.panelSettings.TabIndex = 0;
            // 
            // ComponentGeneralPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "ComponentGeneralPage";
            this.Size = new System.Drawing.Size(310, 559);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.gbViewOnly.ResumeLayout(false);
            this.gbSettings.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox gbViewOnly;
        private System.Windows.Forms.GroupBox gbSettings;
        private System.Windows.Forms.Panel panelViewOnly;
        private System.Windows.Forms.Panel panelSettings;
    }
}
