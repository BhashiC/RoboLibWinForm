
namespace RoboLib.Models.Communication.Pages
{
    partial class RS232HeaderPanel
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnHelp = new System.Windows.Forms.Button();
            this.lblRS232Name = new System.Windows.Forms.Label();
            this.btnConnect = new System.Windows.Forms.Button();
            this.btnSend = new System.Windows.Forms.Button();
            this.rtbResponse = new RoboLib.GUI.Controls.RTextBox();
            this.rcbCommand = new RoboLib.GUI.Controls.RComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.rcbConnected = new RoboLib.GUI.Controls.RCheckBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Gray;
            this.panel1.Controls.Add(this.btnHelp);
            this.panel1.Controls.Add(this.lblRS232Name);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(231, 24);
            this.panel1.TabIndex = 17;
            // 
            // btnHelp
            // 
            this.btnHelp.BackColor = System.Drawing.Color.LimeGreen;
            this.btnHelp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHelp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHelp.Location = new System.Drawing.Point(165, 1);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(63, 22);
            this.btnHelp.TabIndex = 25;
            this.btnHelp.Text = "Help";
            this.btnHelp.UseVisualStyleBackColor = false;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // lblRS232Name
            // 
            this.lblRS232Name.AutoSize = true;
            this.lblRS232Name.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblRS232Name.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblRS232Name.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblRS232Name.Location = new System.Drawing.Point(0, 0);
            this.lblRS232Name.Name = "lblRS232Name";
            this.lblRS232Name.Size = new System.Drawing.Size(117, 22);
            this.lblRS232Name.TabIndex = 0;
            this.lblRS232Name.Text = "RS232 Name";
            // 
            // btnConnect
            // 
            this.btnConnect.BackColor = System.Drawing.Color.MediumSpringGreen;
            this.btnConnect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConnect.Location = new System.Drawing.Point(3, 5);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(66, 23);
            this.btnConnect.TabIndex = 21;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = false;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // btnSend
            // 
            this.btnSend.BackColor = System.Drawing.Color.LightSalmon;
            this.btnSend.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSend.Location = new System.Drawing.Point(168, 32);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(66, 23);
            this.btnSend.TabIndex = 22;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = false;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // rtbResponse
            // 
            this.rtbResponse.AutoScroll = true;
            this.rtbResponse.BackColor = System.Drawing.Color.Lime;
            this.rtbResponse.IsPasswordField = false;
            this.rtbResponse.LabelText = "Response";
            this.rtbResponse.LabelWidthPercent = -1;
            this.rtbResponse.Location = new System.Drawing.Point(3, 90);
            this.rtbResponse.Multiline = true;
            this.rtbResponse.Name = "rtbResponse";
            this.rtbResponse.Size = new System.Drawing.Size(231, 36);
            this.rtbResponse.TabIndex = 20;
            this.rtbResponse.ValueText = "";
            // 
            // rcbCommand
            // 
            this.rcbCommand.LabelText = "Comand";
            this.rcbCommand.Location = new System.Drawing.Point(3, 63);
            this.rcbCommand.Name = "rcbCommand";
            this.rcbCommand.Size = new System.Drawing.Size(231, 21);
            this.rcbCommand.TabIndex = 23;
            this.rcbCommand.ValueText = "";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Gray;
            this.panel2.Controls.Add(this.rcbConnected);
            this.panel2.Controls.Add(this.btnConnect);
            this.panel2.Location = new System.Drawing.Point(3, 27);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(160, 30);
            this.panel2.TabIndex = 24;
            // 
            // rcbConnected
            // 
            this.rcbConnected.LabelText = "Connected";
            this.rcbConnected.Location = new System.Drawing.Point(71, 6);
            this.rcbConnected.Name = "rcbConnected";
            this.rcbConnected.Size = new System.Drawing.Size(86, 21);
            this.rcbConnected.TabIndex = 22;
            this.rcbConnected.Value = false;
            // 
            // RS232HeaderPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gold;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.rcbCommand);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.rtbResponse);
            this.Name = "RS232HeaderPanel";
            this.Size = new System.Drawing.Size(238, 128);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblRS232Name;
        private GUI.Controls.RTextBox rtbResponse;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Button btnSend;
        private GUI.Controls.RComboBox rcbCommand;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnHelp;
        private GUI.Controls.RCheckBox rcbConnected;
    }
}
