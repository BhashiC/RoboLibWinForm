namespace RoboJarvis.Comp.PathPlan.Pages
{
    partial class PathPlanPage
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
            this.gbPathPoints = new System.Windows.Forms.GroupBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnDeletePoint = new System.Windows.Forms.Button();
            this.tbRemovePointAt = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnCopyAngles = new System.Windows.Forms.Button();
            this.tbCopyToPointAt = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnAddPoint = new System.Windows.Forms.Button();
            this.tbAddPointAt = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.rtbWorkingPointNo = new RoboLib.GUI.Controls.RTextBox();
            this.rcbSimulating = new RoboLib.GUI.Controls.RCheckBox();
            this.btnInvKinSimStart = new System.Windows.Forms.Button();
            this.cbRoundAngles = new System.Windows.Forms.CheckBox();
            this.btnHome = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnRun = new System.Windows.Forms.Button();
            this.rtbWorkingPatern = new RoboLib.GUI.Controls.RTextBox();
            this.dgvPathPoints = new System.Windows.Forms.DataGridView();
            this.gbPathPatterns = new System.Windows.Forms.GroupBox();
            this.btnRemovePattern = new System.Windows.Forms.Button();
            this.rtbCreateNewPattern = new RoboLib.GUI.Controls.RTextBox();
            this.btnLoadPattern = new System.Windows.Forms.Button();
            this.btnCreatePattern = new System.Windows.Forms.Button();
            this.rcbCurrentPathPatern = new RoboLib.GUI.Controls.RComboBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.gbPathPoints.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPathPoints)).BeginInit();
            this.gbPathPatterns.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbPathPoints
            // 
            this.gbPathPoints.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.gbPathPoints.Controls.Add(this.panel4);
            this.gbPathPoints.Controls.Add(this.panel3);
            this.gbPathPoints.Controls.Add(this.panel2);
            this.gbPathPoints.Controls.Add(this.panel1);
            this.gbPathPoints.Controls.Add(this.label1);
            this.gbPathPoints.Controls.Add(this.rtbWorkingPointNo);
            this.gbPathPoints.Controls.Add(this.cbRoundAngles);
            this.gbPathPoints.Controls.Add(this.rtbWorkingPatern);
            this.gbPathPoints.Controls.Add(this.dgvPathPoints);
            this.gbPathPoints.Location = new System.Drawing.Point(0, 143);
            this.gbPathPoints.Margin = new System.Windows.Forms.Padding(4);
            this.gbPathPoints.Name = "gbPathPoints";
            this.gbPathPoints.Padding = new System.Windows.Forms.Padding(4);
            this.gbPathPoints.Size = new System.Drawing.Size(467, 546);
            this.gbPathPoints.TabIndex = 0;
            this.gbPathPoints.TabStop = false;
            this.gbPathPoints.Text = "Path Pattern Points";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.GrayText;
            this.panel3.Controls.Add(this.btnDeletePoint);
            this.panel3.Controls.Add(this.tbRemovePointAt);
            this.panel3.Location = new System.Drawing.Point(6, 375);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(228, 37);
            this.panel3.TabIndex = 26;
            // 
            // btnDeletePoint
            // 
            this.btnDeletePoint.Location = new System.Drawing.Point(4, 4);
            this.btnDeletePoint.Margin = new System.Windows.Forms.Padding(4);
            this.btnDeletePoint.Name = "btnDeletePoint";
            this.btnDeletePoint.Size = new System.Drawing.Size(161, 28);
            this.btnDeletePoint.TabIndex = 6;
            this.btnDeletePoint.Text = "Delete Point No";
            this.btnDeletePoint.UseVisualStyleBackColor = true;
            this.btnDeletePoint.Click += new System.EventHandler(this.btnDeletePoint_Click);
            // 
            // tbRemovePointAt
            // 
            this.tbRemovePointAt.Location = new System.Drawing.Point(169, 4);
            this.tbRemovePointAt.Margin = new System.Windows.Forms.Padding(4);
            this.tbRemovePointAt.Name = "tbRemovePointAt";
            this.tbRemovePointAt.Size = new System.Drawing.Size(52, 22);
            this.tbRemovePointAt.TabIndex = 9;
            this.tbRemovePointAt.TextChanged += new System.EventHandler(this.tbRemovePointAt_TextChanged);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.GrayText;
            this.panel2.Controls.Add(this.btnCopyAngles);
            this.panel2.Controls.Add(this.tbCopyToPointAt);
            this.panel2.Location = new System.Drawing.Point(6, 336);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(228, 37);
            this.panel2.TabIndex = 26;
            // 
            // btnCopyAngles
            // 
            this.btnCopyAngles.Location = new System.Drawing.Point(4, 4);
            this.btnCopyAngles.Margin = new System.Windows.Forms.Padding(4);
            this.btnCopyAngles.Name = "btnCopyAngles";
            this.btnCopyAngles.Size = new System.Drawing.Size(161, 28);
            this.btnCopyAngles.TabIndex = 14;
            this.btnCopyAngles.Text = "Copy Joint Angles to";
            this.btnCopyAngles.UseVisualStyleBackColor = true;
            this.btnCopyAngles.Click += new System.EventHandler(this.btnCopyAngles_Click);
            // 
            // tbCopyToPointAt
            // 
            this.tbCopyToPointAt.Location = new System.Drawing.Point(169, 4);
            this.tbCopyToPointAt.Margin = new System.Windows.Forms.Padding(4);
            this.tbCopyToPointAt.Name = "tbCopyToPointAt";
            this.tbCopyToPointAt.Size = new System.Drawing.Size(52, 22);
            this.tbCopyToPointAt.TabIndex = 15;
            this.tbCopyToPointAt.TextChanged += new System.EventHandler(this.tbCopyToPointAt_TextChanged);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.GrayText;
            this.panel1.Controls.Add(this.btnAddPoint);
            this.panel1.Controls.Add(this.tbAddPointAt);
            this.panel1.Location = new System.Drawing.Point(7, 297);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(228, 37);
            this.panel1.TabIndex = 25;
            // 
            // btnAddPoint
            // 
            this.btnAddPoint.Location = new System.Drawing.Point(4, 4);
            this.btnAddPoint.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddPoint.Name = "btnAddPoint";
            this.btnAddPoint.Size = new System.Drawing.Size(161, 28);
            this.btnAddPoint.TabIndex = 5;
            this.btnAddPoint.Text = "Add New Point to";
            this.btnAddPoint.UseVisualStyleBackColor = true;
            this.btnAddPoint.Click += new System.EventHandler(this.btnAddPoint_Click);
            // 
            // tbAddPointAt
            // 
            this.tbAddPointAt.Location = new System.Drawing.Point(169, 4);
            this.tbAddPointAt.Margin = new System.Windows.Forms.Padding(4);
            this.tbAddPointAt.Name = "tbAddPointAt";
            this.tbAddPointAt.Size = new System.Drawing.Size(52, 22);
            this.tbAddPointAt.TabIndex = 8;
            this.tbAddPointAt.TextChanged += new System.EventHandler(this.tbAddPointAt_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(173, 277);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 17);
            this.label1.TabIndex = 24;
            this.label1.Text = "Point No";
            // 
            // rtbWorkingPointNo
            // 
            this.rtbWorkingPointNo.BackColor = System.Drawing.SystemColors.Control;
            this.rtbWorkingPointNo.IsPasswordField = false;
            this.rtbWorkingPointNo.LabelText = "No";
            this.rtbWorkingPointNo.LabelWidthPercent = -1;
            this.rtbWorkingPointNo.Location = new System.Drawing.Point(347, 23);
            this.rtbWorkingPointNo.Margin = new System.Windows.Forms.Padding(5);
            this.rtbWorkingPointNo.Multiline = false;
            this.rtbWorkingPointNo.Name = "rtbWorkingPointNo";
            this.rtbWorkingPointNo.Size = new System.Drawing.Size(116, 26);
            this.rtbWorkingPointNo.TabIndex = 23;
            this.rtbWorkingPointNo.ValueText = "";
            // 
            // rcbSimulating
            // 
            this.rcbSimulating.LabelText = "Moving";
            this.rcbSimulating.Location = new System.Drawing.Point(60, 56);
            this.rcbSimulating.Margin = new System.Windows.Forms.Padding(5);
            this.rcbSimulating.Name = "rcbSimulating";
            this.rcbSimulating.Size = new System.Drawing.Size(100, 28);
            this.rcbSimulating.TabIndex = 22;
            this.rcbSimulating.Value = false;
            // 
            // btnInvKinSimStart
            // 
            this.btnInvKinSimStart.Location = new System.Drawing.Point(4, 56);
            this.btnInvKinSimStart.Margin = new System.Windows.Forms.Padding(4);
            this.btnInvKinSimStart.Name = "btnInvKinSimStart";
            this.btnInvKinSimStart.Size = new System.Drawing.Size(48, 44);
            this.btnInvKinSimStart.TabIndex = 21;
            this.btnInvKinSimStart.Text = "Inv Kin";
            this.btnInvKinSimStart.UseVisualStyleBackColor = true;
            this.btnInvKinSimStart.Click += new System.EventHandler(this.btnInvKinSimStart_Click);
            // 
            // cbRoundAngles
            // 
            this.cbRoundAngles.AutoSize = true;
            this.cbRoundAngles.Location = new System.Drawing.Point(11, 419);
            this.cbRoundAngles.Margin = new System.Windows.Forms.Padding(4);
            this.cbRoundAngles.Name = "cbRoundAngles";
            this.cbRoundAngles.Size = new System.Drawing.Size(136, 21);
            this.cbRoundAngles.TabIndex = 17;
            this.cbRoundAngles.Text = "Round and Copy";
            this.cbRoundAngles.UseVisualStyleBackColor = true;
            // 
            // btnHome
            // 
            this.btnHome.Font = new System.Drawing.Font("Webdings", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.btnHome.Location = new System.Drawing.Point(116, 4);
            this.btnHome.Margin = new System.Windows.Forms.Padding(4);
            this.btnHome.Name = "btnHome";
            this.btnHome.Size = new System.Drawing.Size(48, 44);
            this.btnHome.TabIndex = 13;
            this.btnHome.Text = "H";
            this.btnHome.UseVisualStyleBackColor = true;
            this.btnHome.Click += new System.EventHandler(this.btnHome_Click);
            // 
            // btnStop
            // 
            this.btnStop.Font = new System.Drawing.Font("Webdings", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.btnStop.Location = new System.Drawing.Point(60, 4);
            this.btnStop.Margin = new System.Windows.Forms.Padding(4);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(48, 44);
            this.btnStop.TabIndex = 12;
            this.btnStop.Text = "<";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnRun
            // 
            this.btnRun.Font = new System.Drawing.Font("Webdings", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.btnRun.Location = new System.Drawing.Point(4, 4);
            this.btnRun.Margin = new System.Windows.Forms.Padding(4);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(48, 44);
            this.btnRun.TabIndex = 10;
            this.btnRun.Text = "4";
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // rtbWorkingPatern
            // 
            this.rtbWorkingPatern.BackColor = System.Drawing.SystemColors.Control;
            this.rtbWorkingPatern.IsPasswordField = false;
            this.rtbWorkingPatern.LabelText = "Working Pattern Name";
            this.rtbWorkingPatern.LabelWidthPercent = -1;
            this.rtbWorkingPatern.Location = new System.Drawing.Point(8, 23);
            this.rtbWorkingPatern.Margin = new System.Windows.Forms.Padding(5);
            this.rtbWorkingPatern.Multiline = false;
            this.rtbWorkingPatern.Name = "rtbWorkingPatern";
            this.rtbWorkingPatern.Size = new System.Drawing.Size(331, 26);
            this.rtbWorkingPatern.TabIndex = 7;
            this.rtbWorkingPatern.ValueText = "";
            // 
            // dgvPathPoints
            // 
            this.dgvPathPoints.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvPathPoints.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPathPoints.Location = new System.Drawing.Point(4, 57);
            this.dgvPathPoints.Margin = new System.Windows.Forms.Padding(4);
            this.dgvPathPoints.Name = "dgvPathPoints";
            this.dgvPathPoints.Size = new System.Drawing.Size(459, 209);
            this.dgvPathPoints.TabIndex = 2;
            // 
            // gbPathPatterns
            // 
            this.gbPathPatterns.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.gbPathPatterns.Controls.Add(this.btnRemovePattern);
            this.gbPathPatterns.Controls.Add(this.rtbCreateNewPattern);
            this.gbPathPatterns.Controls.Add(this.btnLoadPattern);
            this.gbPathPatterns.Controls.Add(this.btnCreatePattern);
            this.gbPathPatterns.Controls.Add(this.rcbCurrentPathPatern);
            this.gbPathPatterns.Location = new System.Drawing.Point(0, 4);
            this.gbPathPatterns.Margin = new System.Windows.Forms.Padding(4);
            this.gbPathPatterns.Name = "gbPathPatterns";
            this.gbPathPatterns.Padding = new System.Windows.Forms.Padding(4);
            this.gbPathPatterns.Size = new System.Drawing.Size(467, 132);
            this.gbPathPatterns.TabIndex = 7;
            this.gbPathPatterns.TabStop = false;
            this.gbPathPatterns.Text = "Path Patterns";
            // 
            // btnRemovePattern
            // 
            this.btnRemovePattern.Location = new System.Drawing.Point(347, 95);
            this.btnRemovePattern.Margin = new System.Windows.Forms.Padding(4);
            this.btnRemovePattern.Name = "btnRemovePattern";
            this.btnRemovePattern.Size = new System.Drawing.Size(112, 28);
            this.btnRemovePattern.TabIndex = 10;
            this.btnRemovePattern.Text = "Delete Pattern";
            this.btnRemovePattern.UseVisualStyleBackColor = true;
            this.btnRemovePattern.Click += new System.EventHandler(this.btnRemovePattern_Click);
            // 
            // rtbCreateNewPattern
            // 
            this.rtbCreateNewPattern.BackColor = System.Drawing.SystemColors.Control;
            this.rtbCreateNewPattern.IsPasswordField = false;
            this.rtbCreateNewPattern.LabelText = "Create New Pattern";
            this.rtbCreateNewPattern.LabelWidthPercent = -1;
            this.rtbCreateNewPattern.Location = new System.Drawing.Point(8, 23);
            this.rtbCreateNewPattern.Margin = new System.Windows.Forms.Padding(5);
            this.rtbCreateNewPattern.Multiline = false;
            this.rtbCreateNewPattern.Name = "rtbCreateNewPattern";
            this.rtbCreateNewPattern.Size = new System.Drawing.Size(331, 26);
            this.rtbCreateNewPattern.TabIndex = 9;
            this.rtbCreateNewPattern.ValueText = "";
            // 
            // btnLoadPattern
            // 
            this.btnLoadPattern.Location = new System.Drawing.Point(347, 59);
            this.btnLoadPattern.Margin = new System.Windows.Forms.Padding(4);
            this.btnLoadPattern.Name = "btnLoadPattern";
            this.btnLoadPattern.Size = new System.Drawing.Size(112, 28);
            this.btnLoadPattern.TabIndex = 8;
            this.btnLoadPattern.Text = "Load Pattern";
            this.btnLoadPattern.UseVisualStyleBackColor = true;
            this.btnLoadPattern.Click += new System.EventHandler(this.btnLoadPattern_Click);
            // 
            // btnCreatePattern
            // 
            this.btnCreatePattern.Location = new System.Drawing.Point(347, 23);
            this.btnCreatePattern.Margin = new System.Windows.Forms.Padding(4);
            this.btnCreatePattern.Name = "btnCreatePattern";
            this.btnCreatePattern.Size = new System.Drawing.Size(112, 28);
            this.btnCreatePattern.TabIndex = 7;
            this.btnCreatePattern.Text = "Create Pattern";
            this.btnCreatePattern.UseVisualStyleBackColor = true;
            this.btnCreatePattern.Click += new System.EventHandler(this.btnCreatePattern_Click);
            // 
            // rcbCurrentPathPatern
            // 
            this.rcbCurrentPathPatern.BackColor = System.Drawing.SystemColors.Control;
            this.rcbCurrentPathPatern.LabelText = "Current Path Pattern";
            this.rcbCurrentPathPatern.Location = new System.Drawing.Point(8, 57);
            this.rcbCurrentPathPatern.Margin = new System.Windows.Forms.Padding(5);
            this.rcbCurrentPathPatern.Name = "rcbCurrentPathPatern";
            this.rcbCurrentPathPatern.Size = new System.Drawing.Size(331, 26);
            this.rcbCurrentPathPatern.TabIndex = 0;
            this.rcbCurrentPathPatern.ValueText = "";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.SystemColors.GrayText;
            this.panel4.Controls.Add(this.btnRun);
            this.panel4.Controls.Add(this.btnStop);
            this.panel4.Controls.Add(this.btnHome);
            this.panel4.Controls.Add(this.btnInvKinSimStart);
            this.panel4.Controls.Add(this.rcbSimulating);
            this.panel4.Location = new System.Drawing.Point(292, 301);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(168, 106);
            this.panel4.TabIndex = 27;
            // 
            // PathPlanPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.Controls.Add(this.gbPathPatterns);
            this.Controls.Add(this.gbPathPoints);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "PathPlanPage";
            this.Size = new System.Drawing.Size(467, 693);
            this.gbPathPoints.ResumeLayout(false);
            this.gbPathPoints.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPathPoints)).EndInit();
            this.gbPathPatterns.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbPathPoints;
        private System.Windows.Forms.DataGridView dgvPathPoints;
        private System.Windows.Forms.Button btnDeletePoint;
        private System.Windows.Forms.Button btnAddPoint;
        private System.Windows.Forms.GroupBox gbPathPatterns;
        private RoboLib.GUI.Controls.RComboBox rcbCurrentPathPatern;
        private System.Windows.Forms.Button btnLoadPattern;
        private System.Windows.Forms.Button btnCreatePattern;
        private RoboLib.GUI.Controls.RTextBox rtbCreateNewPattern;
        private System.Windows.Forms.Button btnRemovePattern;
        private RoboLib.GUI.Controls.RTextBox rtbWorkingPatern;
        private System.Windows.Forms.TextBox tbRemovePointAt;
        private System.Windows.Forms.TextBox tbAddPointAt;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnHome;
        private System.Windows.Forms.TextBox tbCopyToPointAt;
        private System.Windows.Forms.Button btnCopyAngles;
        private System.Windows.Forms.CheckBox cbRoundAngles;
        private RoboLib.GUI.Controls.RCheckBox rcbSimulating;
        private System.Windows.Forms.Button btnInvKinSimStart;
        private RoboLib.GUI.Controls.RTextBox rtbWorkingPointNo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel4;
    }
}
