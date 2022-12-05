
namespace RoboJarvis.Comp.Motion.Pages
{
    partial class MKSAxisPage
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
            this.gbSettings = new System.Windows.Forms.GroupBox();
            this.mksSettingsPanel1 = new RoboJarvis.Comp.Motion.Pages.MKSSettingsPanel();
            this.gbPositions = new System.Windows.Forms.GroupBox();
            this.flpPositions = new System.Windows.Forms.FlowLayoutPanel();
            this.gbJog = new System.Windows.Forms.GroupBox();
            this.jogPanel1 = new RoboJarvis.Comp.Motion.Pages.JogPanel();
            this.gbSafetyLimits = new System.Windows.Forms.GroupBox();
            this.softLimitPanel1 = new RoboJarvis.Comp.Motion.Pages.SoftLimitPanel();
            this.motionHeaderPanel1 = new RoboJarvis.Comp.Motion.Pages.MotionHeaderPanel();
            this.gbSettings.SuspendLayout();
            this.gbPositions.SuspendLayout();
            this.gbJog.SuspendLayout();
            this.gbSafetyLimits.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbSettings
            // 
            this.gbSettings.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.gbSettings.Controls.Add(this.mksSettingsPanel1);
            this.gbSettings.Location = new System.Drawing.Point(3, 285);
            this.gbSettings.Name = "gbSettings";
            this.gbSettings.Size = new System.Drawing.Size(304, 105);
            this.gbSettings.TabIndex = 10;
            this.gbSettings.TabStop = false;
            this.gbSettings.Text = "Settings";
            // 
            // mksSettingsPanel1
            // 
            this.mksSettingsPanel1.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.mksSettingsPanel1.Location = new System.Drawing.Point(0, 18);
            this.mksSettingsPanel1.Name = "mksSettingsPanel1";
            this.mksSettingsPanel1.Size = new System.Drawing.Size(303, 81);
            this.mksSettingsPanel1.TabIndex = 0;
            // 
            // gbPositions
            // 
            this.gbPositions.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.gbPositions.Controls.Add(this.flpPositions);
            this.gbPositions.Location = new System.Drawing.Point(3, 147);
            this.gbPositions.Name = "gbPositions";
            this.gbPositions.Size = new System.Drawing.Size(303, 75);
            this.gbPositions.TabIndex = 8;
            this.gbPositions.TabStop = false;
            this.gbPositions.Text = "Test Positions";
            // 
            // flpPositions
            // 
            this.flpPositions.Location = new System.Drawing.Point(6, 18);
            this.flpPositions.Name = "flpPositions";
            this.flpPositions.Size = new System.Drawing.Size(294, 50);
            this.flpPositions.TabIndex = 0;
            // 
            // gbJog
            // 
            this.gbJog.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.gbJog.Controls.Add(this.jogPanel1);
            this.gbJog.Location = new System.Drawing.Point(3, 61);
            this.gbJog.Name = "gbJog";
            this.gbJog.Size = new System.Drawing.Size(303, 80);
            this.gbJog.TabIndex = 7;
            this.gbJog.TabStop = false;
            this.gbJog.Text = "Jog ";
            // 
            // jogPanel1
            // 
            this.jogPanel1.Location = new System.Drawing.Point(6, 19);
            this.jogPanel1.Name = "jogPanel1";
            this.jogPanel1.Size = new System.Drawing.Size(294, 53);
            this.jogPanel1.TabIndex = 0;
            // 
            // gbSafetyLimits
            // 
            this.gbSafetyLimits.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.gbSafetyLimits.Controls.Add(this.softLimitPanel1);
            this.gbSafetyLimits.Location = new System.Drawing.Point(3, 228);
            this.gbSafetyLimits.Name = "gbSafetyLimits";
            this.gbSafetyLimits.Size = new System.Drawing.Size(303, 51);
            this.gbSafetyLimits.TabIndex = 6;
            this.gbSafetyLimits.TabStop = false;
            this.gbSafetyLimits.Text = "Soft Limits";
            // 
            // softLimitPanel1
            // 
            this.softLimitPanel1.Location = new System.Drawing.Point(6, 19);
            this.softLimitPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.softLimitPanel1.Name = "softLimitPanel1";
            this.softLimitPanel1.Size = new System.Drawing.Size(294, 25);
            this.softLimitPanel1.TabIndex = 5;
            // 
            // motionHeaderPanel1
            // 
            this.motionHeaderPanel1.BackColor = System.Drawing.Color.Gold;
            this.motionHeaderPanel1.Location = new System.Drawing.Point(3, 0);
            this.motionHeaderPanel1.Name = "motionHeaderPanel1";
            this.motionHeaderPanel1.Size = new System.Drawing.Size(303, 61);
            this.motionHeaderPanel1.TabIndex = 9;
            // 
            // MKSAxisPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gray;
            this.Controls.Add(this.gbSettings);
            this.Controls.Add(this.motionHeaderPanel1);
            this.Controls.Add(this.gbPositions);
            this.Controls.Add(this.gbJog);
            this.Controls.Add(this.gbSafetyLimits);
            this.Name = "MKSAxisPage";
            this.Size = new System.Drawing.Size(310, 395);
            this.gbSettings.ResumeLayout(false);
            this.gbPositions.ResumeLayout(false);
            this.gbJog.ResumeLayout(false);
            this.gbSafetyLimits.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private Pages.SoftLimitPanel softLimitPanel1;
        private System.Windows.Forms.GroupBox gbSafetyLimits;
        private System.Windows.Forms.GroupBox gbJog;
        private System.Windows.Forms.GroupBox gbPositions;
        private System.Windows.Forms.FlowLayoutPanel flpPositions;
        private MotionHeaderPanel motionHeaderPanel1;
        private System.Windows.Forms.GroupBox gbSettings;
        private MKSSettingsPanel mksSettingsPanel1;
        private JogPanel jogPanel1;
    }
}
