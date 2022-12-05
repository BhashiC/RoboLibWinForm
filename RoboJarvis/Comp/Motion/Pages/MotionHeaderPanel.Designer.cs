
namespace RoboJarvis.Comp.Motion.Pages
{
    partial class MotionHeaderPanel
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
            this.btnEnable = new System.Windows.Forms.Button();
            this.rcbEnabled = new RoboLib.GUI.Controls.RCheckBox();
            this.lblAxisName = new System.Windows.Forms.Label();
            this.rtbCurrentPosition = new RoboLib.GUI.Controls.RTextBox();
            this.btnHome = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Gray;
            this.panel1.Controls.Add(this.btnEnable);
            this.panel1.Controls.Add(this.rcbEnabled);
            this.panel1.Controls.Add(this.lblAxisName);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(297, 24);
            this.panel1.TabIndex = 2;
            // 
            // btnEnable
            // 
            this.btnEnable.BackColor = System.Drawing.Color.MediumSpringGreen;
            this.btnEnable.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnEnable.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEnable.Location = new System.Drawing.Point(158, 0);
            this.btnEnable.Name = "btnEnable";
            this.btnEnable.Size = new System.Drawing.Size(66, 24);
            this.btnEnable.TabIndex = 5;
            this.btnEnable.Text = "Enable";
            this.btnEnable.UseVisualStyleBackColor = false;
            this.btnEnable.Click += new System.EventHandler(this.btnEnable_Click);
            // 
            // rcbEnabled
            // 
            this.rcbEnabled.Dock = System.Windows.Forms.DockStyle.Right;
            this.rcbEnabled.LabelText = "Enabled";
            this.rcbEnabled.Location = new System.Drawing.Point(224, 0);
            this.rcbEnabled.Name = "rcbEnabled";
            this.rcbEnabled.Size = new System.Drawing.Size(73, 24);
            this.rcbEnabled.TabIndex = 4;
            this.rcbEnabled.Value = false;
            // 
            // lblAxisName
            // 
            this.lblAxisName.AutoSize = true;
            this.lblAxisName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblAxisName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblAxisName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblAxisName.Location = new System.Drawing.Point(0, 0);
            this.lblAxisName.Name = "lblAxisName";
            this.lblAxisName.Size = new System.Drawing.Size(95, 22);
            this.lblAxisName.TabIndex = 0;
            this.lblAxisName.Text = "Axis Name";
            // 
            // rtbCurrentPosition
            // 
            this.rtbCurrentPosition.BackColor = System.Drawing.Color.Lime;
            this.rtbCurrentPosition.IsPasswordField = false;
            this.rtbCurrentPosition.LabelText = "Current Position";
            this.rtbCurrentPosition.LabelWidthPercent = -1;
            this.rtbCurrentPosition.Location = new System.Drawing.Point(3, 33);
            this.rtbCurrentPosition.Margin = new System.Windows.Forms.Padding(4);
            this.rtbCurrentPosition.Multiline = false;
            this.rtbCurrentPosition.Name = "rtbCurrentPosition";
            this.rtbCurrentPosition.Size = new System.Drawing.Size(225, 21);
            this.rtbCurrentPosition.TabIndex = 6;
            this.rtbCurrentPosition.ValueText = "";
            // 
            // btnHome
            // 
            this.btnHome.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHome.Location = new System.Drawing.Point(234, 31);
            this.btnHome.Name = "btnHome";
            this.btnHome.Size = new System.Drawing.Size(66, 23);
            this.btnHome.TabIndex = 5;
            this.btnHome.Text = "Home";
            this.btnHome.UseVisualStyleBackColor = true;
            this.btnHome.Click += new System.EventHandler(this.btnHome_Click);
            // 
            // MotionHeaderPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gold;
            this.Controls.Add(this.rtbCurrentPosition);
            this.Controls.Add(this.btnHome);
            this.Controls.Add(this.panel1);
            this.Name = "MotionHeaderPanel";
            this.Size = new System.Drawing.Size(303, 61);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblAxisName;
        private RoboLib.GUI.Controls.RTextBox rtbCurrentPosition;
        private System.Windows.Forms.Button btnHome;
        private System.Windows.Forms.Button btnEnable;
        private RoboLib.GUI.Controls.RCheckBox rcbEnabled;
    }
}
