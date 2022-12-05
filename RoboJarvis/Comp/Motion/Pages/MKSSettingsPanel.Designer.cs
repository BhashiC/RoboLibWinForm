
namespace RoboJarvis.Comp.Motion.Pages
{
    partial class MKSSettingsPanel
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.rtbGearRation = new RoboLib.GUI.Controls.RTextBox();
            this.btnCalibrate = new System.Windows.Forms.Button();
            this.btnSetMotorCurrent = new System.Windows.Forms.Button();
            this.btnSetHoldCurrent = new System.Windows.Forms.Button();
            this.btnSetMicroStep = new System.Windows.Forms.Button();
            this.rcbMicroStep = new RoboLib.GUI.Controls.RComboBox();
            this.rcbMotorCurrent = new RoboLib.GUI.Controls.RComboBox();
            this.rcbHoldCurrent = new RoboLib.GUI.Controls.RComboBox();
            this.rcbUseGearBox = new RoboLib.GUI.Controls.RCheckBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.panel1.Controls.Add(this.rcbUseGearBox);
            this.panel1.Controls.Add(this.rtbGearRation);
            this.panel1.Controls.Add(this.btnCalibrate);
            this.panel1.Location = new System.Drawing.Point(220, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(80, 74);
            this.panel1.TabIndex = 11;
            // 
            // rtbGearRation
            // 
            this.rtbGearRation.IsPasswordField = false;
            this.rtbGearRation.LabelText = "Ratio";
            this.rtbGearRation.LabelWidthPercent = -1;
            this.rtbGearRation.Location = new System.Drawing.Point(3, 26);
            this.rtbGearRation.Multiline = false;
            this.rtbGearRation.Name = "rtbGearRation";
            this.rtbGearRation.Size = new System.Drawing.Size(73, 21);
            this.rtbGearRation.TabIndex = 9;
            this.rtbGearRation.ValueText = "";
            // 
            // btnCalibrate
            // 
            this.btnCalibrate.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnCalibrate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCalibrate.Location = new System.Drawing.Point(3, 52);
            this.btnCalibrate.Name = "btnCalibrate";
            this.btnCalibrate.Size = new System.Drawing.Size(74, 20);
            this.btnCalibrate.TabIndex = 8;
            this.btnCalibrate.Text = "Calibrate";
            this.btnCalibrate.UseVisualStyleBackColor = true;
            this.btnCalibrate.Click += new System.EventHandler(this.btnCalibrate_Click);
            // 
            // btnSetMotorCurrent
            // 
            this.btnSetMotorCurrent.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnSetMotorCurrent.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSetMotorCurrent.Location = new System.Drawing.Point(179, 58);
            this.btnSetMotorCurrent.Name = "btnSetMotorCurrent";
            this.btnSetMotorCurrent.Size = new System.Drawing.Size(36, 20);
            this.btnSetMotorCurrent.TabIndex = 7;
            this.btnSetMotorCurrent.Text = "Set";
            this.btnSetMotorCurrent.UseVisualStyleBackColor = true;
            this.btnSetMotorCurrent.Click += new System.EventHandler(this.btnSetMotorCurrent_Click);
            // 
            // btnSetHoldCurrent
            // 
            this.btnSetHoldCurrent.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnSetHoldCurrent.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSetHoldCurrent.Location = new System.Drawing.Point(179, 31);
            this.btnSetHoldCurrent.Name = "btnSetHoldCurrent";
            this.btnSetHoldCurrent.Size = new System.Drawing.Size(36, 20);
            this.btnSetHoldCurrent.TabIndex = 6;
            this.btnSetHoldCurrent.Text = "Set";
            this.btnSetHoldCurrent.UseVisualStyleBackColor = true;
            this.btnSetHoldCurrent.Click += new System.EventHandler(this.btnSetHoldCurrent_Click);
            // 
            // btnSetMicroStep
            // 
            this.btnSetMicroStep.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnSetMicroStep.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSetMicroStep.Location = new System.Drawing.Point(179, 4);
            this.btnSetMicroStep.Name = "btnSetMicroStep";
            this.btnSetMicroStep.Size = new System.Drawing.Size(36, 20);
            this.btnSetMicroStep.TabIndex = 5;
            this.btnSetMicroStep.Text = "Set";
            this.btnSetMicroStep.UseVisualStyleBackColor = true;
            this.btnSetMicroStep.Click += new System.EventHandler(this.btnSetMicroStep_Click);
            // 
            // rcbMicroStep
            // 
            this.rcbMicroStep.LabelText = "Micro Steps";
            this.rcbMicroStep.Location = new System.Drawing.Point(3, 3);
            this.rcbMicroStep.Name = "rcbMicroStep";
            this.rcbMicroStep.Size = new System.Drawing.Size(170, 21);
            this.rcbMicroStep.TabIndex = 2;
            this.rcbMicroStep.ValueText = "";
            // 
            // rcbMotorCurrent
            // 
            this.rcbMotorCurrent.LabelText = "Motor Current";
            this.rcbMotorCurrent.Location = new System.Drawing.Point(3, 57);
            this.rcbMotorCurrent.Name = "rcbMotorCurrent";
            this.rcbMotorCurrent.Size = new System.Drawing.Size(170, 21);
            this.rcbMotorCurrent.TabIndex = 1;
            this.rcbMotorCurrent.ValueText = "";
            // 
            // rcbHoldCurrent
            // 
            this.rcbHoldCurrent.LabelText = "Hold Current";
            this.rcbHoldCurrent.Location = new System.Drawing.Point(3, 30);
            this.rcbHoldCurrent.Name = "rcbHoldCurrent";
            this.rcbHoldCurrent.Size = new System.Drawing.Size(170, 21);
            this.rcbHoldCurrent.TabIndex = 0;
            this.rcbHoldCurrent.ValueText = "";
            // 
            // rcbUseGearBox
            // 
            this.rcbUseGearBox.LabelText = "Use GBox";
            this.rcbUseGearBox.Location = new System.Drawing.Point(3, 3);
            this.rcbUseGearBox.Name = "rcbUseGearBox";
            this.rcbUseGearBox.Size = new System.Drawing.Size(74, 17);
            this.rcbUseGearBox.TabIndex = 10;
            this.rcbUseGearBox.Value = false;
            // 
            // MKSSettingsPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnSetMotorCurrent);
            this.Controls.Add(this.btnSetHoldCurrent);
            this.Controls.Add(this.btnSetMicroStep);
            this.Controls.Add(this.rcbMicroStep);
            this.Controls.Add(this.rcbMotorCurrent);
            this.Controls.Add(this.rcbHoldCurrent);
            this.Name = "MKSSettingsPanel";
            this.Size = new System.Drawing.Size(303, 81);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private RoboLib.GUI.Controls.RComboBox rcbHoldCurrent;
        private RoboLib.GUI.Controls.RComboBox rcbMotorCurrent;
        private RoboLib.GUI.Controls.RComboBox rcbMicroStep;
        private System.Windows.Forms.Button btnSetMicroStep;
        private System.Windows.Forms.Button btnSetHoldCurrent;
        private System.Windows.Forms.Button btnSetMotorCurrent;
        private System.Windows.Forms.Button btnCalibrate;
        private RoboLib.GUI.Controls.RTextBox rtbGearRation;
        private System.Windows.Forms.Panel panel1;
        private RoboLib.GUI.Controls.RCheckBox rcbUseGearBox;
    }
}
