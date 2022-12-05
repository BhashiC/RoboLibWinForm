
namespace RoboLib.Models.Communication.Pages
{
    partial class RS232SettingsPanel
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rcbBaudRate = new RoboLib.GUI.Controls.RComboBox();
            this.rcbComPort = new RoboLib.GUI.Controls.RComboBox();
            this.rcbHandShake = new RoboLib.GUI.Controls.RComboBox();
            this.rtbDataBits = new RoboLib.GUI.Controls.RTextBox();
            this.rtbTimeout = new RoboLib.GUI.Controls.RTextBox();
            this.rcbNewLine = new RoboLib.GUI.Controls.RComboBox();
            this.rcbStopBits = new RoboLib.GUI.Controls.RComboBox();
            this.rcbParity = new RoboLib.GUI.Controls.RComboBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox1.Controls.Add(this.rcbBaudRate);
            this.groupBox1.Controls.Add(this.rcbComPort);
            this.groupBox1.Controls.Add(this.rcbHandShake);
            this.groupBox1.Controls.Add(this.rtbDataBits);
            this.groupBox1.Controls.Add(this.rtbTimeout);
            this.groupBox1.Controls.Add(this.rcbNewLine);
            this.groupBox1.Controls.Add(this.rcbStopBits);
            this.groupBox1.Controls.Add(this.rcbParity);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(238, 232);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Settings";
            // 
            // rcbBaudRate
            // 
            this.rcbBaudRate.LabelText = "Baud Rate";
            this.rcbBaudRate.Location = new System.Drawing.Point(6, 46);
            this.rcbBaudRate.Name = "rcbBaudRate";
            this.rcbBaudRate.Size = new System.Drawing.Size(223, 21);
            this.rcbBaudRate.TabIndex = 2;
            this.rcbBaudRate.ValueText = "";
            // 
            // rcbComPort
            // 
            this.rcbComPort.LabelText = "COM Port";
            this.rcbComPort.Location = new System.Drawing.Point(6, 19);
            this.rcbComPort.Name = "rcbComPort";
            this.rcbComPort.Size = new System.Drawing.Size(223, 21);
            this.rcbComPort.TabIndex = 3;
            this.rcbComPort.ValueText = "";
            // 
            // rcbHandShake
            // 
            this.rcbHandShake.LabelText = "Hand Shake";
            this.rcbHandShake.Location = new System.Drawing.Point(6, 100);
            this.rcbHandShake.Name = "rcbHandShake";
            this.rcbHandShake.Size = new System.Drawing.Size(223, 21);
            this.rcbHandShake.TabIndex = 4;
            this.rcbHandShake.ValueText = "";
            // 
            // rtbDataBits
            // 
            this.rtbDataBits.IsPasswordField = false;
            this.rtbDataBits.LabelText = "Data Bits";
            this.rtbDataBits.LabelWidthPercent = -1;
            this.rtbDataBits.Location = new System.Drawing.Point(6, 73);
            this.rtbDataBits.Multiline = false;
            this.rtbDataBits.Name = "rtbDataBits";
            this.rtbDataBits.Size = new System.Drawing.Size(223, 21);
            this.rtbDataBits.TabIndex = 5;
            this.rtbDataBits.ValueText = "";
            // 
            // rtbTimeout
            // 
            this.rtbTimeout.IsPasswordField = false;
            this.rtbTimeout.LabelText = "Timeout";
            this.rtbTimeout.LabelWidthPercent = -1;
            this.rtbTimeout.Location = new System.Drawing.Point(6, 208);
            this.rtbTimeout.Multiline = false;
            this.rtbTimeout.Name = "rtbTimeout";
            this.rtbTimeout.Size = new System.Drawing.Size(223, 21);
            this.rtbTimeout.TabIndex = 9;
            this.rtbTimeout.ValueText = "";
            // 
            // rcbNewLine
            // 
            this.rcbNewLine.LabelText = "New Line";
            this.rcbNewLine.Location = new System.Drawing.Point(6, 127);
            this.rcbNewLine.Name = "rcbNewLine";
            this.rcbNewLine.Size = new System.Drawing.Size(223, 21);
            this.rcbNewLine.TabIndex = 6;
            this.rcbNewLine.ValueText = "";
            // 
            // rcbStopBits
            // 
            this.rcbStopBits.LabelText = "Stop Bits";
            this.rcbStopBits.Location = new System.Drawing.Point(6, 181);
            this.rcbStopBits.Name = "rcbStopBits";
            this.rcbStopBits.Size = new System.Drawing.Size(223, 21);
            this.rcbStopBits.TabIndex = 8;
            this.rcbStopBits.ValueText = "";
            // 
            // rcbParity
            // 
            this.rcbParity.LabelText = "Parity";
            this.rcbParity.Location = new System.Drawing.Point(6, 154);
            this.rcbParity.Name = "rcbParity";
            this.rcbParity.Size = new System.Drawing.Size(223, 21);
            this.rcbParity.TabIndex = 7;
            this.rcbParity.ValueText = "";
            // 
            // RS232SettingsPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.groupBox1);
            this.Name = "RS232SettingsPanel";
            this.Size = new System.Drawing.Size(238, 232);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private GUI.Controls.RComboBox rcbBaudRate;
        private GUI.Controls.RComboBox rcbComPort;
        private GUI.Controls.RComboBox rcbHandShake;
        private GUI.Controls.RTextBox rtbDataBits;
        private GUI.Controls.RTextBox rtbTimeout;
        private GUI.Controls.RComboBox rcbNewLine;
        private GUI.Controls.RComboBox rcbStopBits;
        private GUI.Controls.RComboBox rcbParity;
    }
}
