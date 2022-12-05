namespace RoboJarvis
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonSettings = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonJoints = new System.Windows.Forms.ToolStripButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.jointAngleTrackBarPanel1 = new RoboJarvis.Pages.RobotTrackBarPanel();
            this.pathPlanPage1 = new RoboJarvis.Comp.PathPlan.Pages.PathPlanPage();
            this.elementHost1 = new System.Windows.Forms.Integration.ElementHost();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(62)))), ((int)(((byte)(66)))));
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonSettings,
            this.toolStripButtonJoints});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1184, 60);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButtonSettings
            // 
            this.toolStripButtonSettings.AutoSize = false;
            this.toolStripButtonSettings.BackgroundImage = global::RoboJarvis.Properties.Resources.Settings;
            this.toolStripButtonSettings.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.toolStripButtonSettings.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonSettings.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonSettings.Name = "toolStripButtonSettings";
            this.toolStripButtonSettings.Size = new System.Drawing.Size(60, 60);
            this.toolStripButtonSettings.Text = "Settings";
            this.toolStripButtonSettings.Click += new System.EventHandler(this.toolStripButtonSettings_Click);
            // 
            // toolStripButtonJoints
            // 
            this.toolStripButtonJoints.AutoSize = false;
            this.toolStripButtonJoints.BackgroundImage = global::RoboJarvis.Properties.Resources.MotorSetup;
            this.toolStripButtonJoints.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.toolStripButtonJoints.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonJoints.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonJoints.Name = "toolStripButtonJoints";
            this.toolStripButtonJoints.Size = new System.Drawing.Size(60, 60);
            this.toolStripButtonJoints.Text = "JointControl";
            this.toolStripButtonJoints.ToolTipText = "Joint Control";
            this.toolStripButtonJoints.Click += new System.EventHandler(this.toolStripButtonJoints_Click);
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = global::RoboJarvis.Properties.Resources.Logo;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Location = new System.Drawing.Point(6, 459);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(326, 292);
            this.panel1.TabIndex = 7;
            // 
            // jointAngleTrackBarPanel1
            // 
            this.jointAngleTrackBarPanel1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.jointAngleTrackBarPanel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.jointAngleTrackBarPanel1.Location = new System.Drawing.Point(0, 60);
            this.jointAngleTrackBarPanel1.Name = "jointAngleTrackBarPanel1";
            this.jointAngleTrackBarPanel1.Size = new System.Drawing.Size(339, 701);
            this.jointAngleTrackBarPanel1.TabIndex = 6;
            // 
            // pathPlanPage1
            // 
            this.pathPlanPage1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.pathPlanPage1.Dock = System.Windows.Forms.DockStyle.Right;
            this.pathPlanPage1.Location = new System.Drawing.Point(834, 60);
            this.pathPlanPage1.Name = "pathPlanPage1";
            this.pathPlanPage1.Size = new System.Drawing.Size(350, 701);
            this.pathPlanPage1.TabIndex = 11;
            // 
            // elementHost1
            // 
            this.elementHost1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.elementHost1.Location = new System.Drawing.Point(339, 60);
            this.elementHost1.Name = "elementHost1";
            this.elementHost1.Size = new System.Drawing.Size(495, 701);
            this.elementHost1.TabIndex = 12;
            this.elementHost1.Text = "elementHost1";
            this.elementHost1.Child = null;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(62)))), ((int)(((byte)(66)))));
            this.ClientSize = new System.Drawing.Size(1184, 761);
            this.Controls.Add(this.elementHost1);
            this.Controls.Add(this.pathPlanPage1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.jointAngleTrackBarPanel1);
            this.Controls.Add(this.toolStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButtonSettings;
        private System.Windows.Forms.ToolStripButton toolStripButtonJoints;
        private Pages.RobotTrackBarPanel jointAngleTrackBarPanel1;
        private System.Windows.Forms.Panel panel1;
        private Comp.PathPlan.Pages.PathPlanPage pathPlanPage1;
        private System.Windows.Forms.Integration.ElementHost elementHost1;
    }
}

