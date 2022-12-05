
namespace RoboJarvis.Comp.Motion.Pages
{
    partial class JogPanel
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
            this.rtbJogDistance = new RoboLib.GUI.Controls.RTextBox();
            this.btnJogPos = new System.Windows.Forms.Button();
            this.rtbJogSpeed = new RoboLib.GUI.Controls.RTextBox();
            this.btnJogNeg = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // rtbJogDistance
            // 
            this.rtbJogDistance.IsPasswordField = false;
            this.rtbJogDistance.LabelText = "Jog Distance";
            this.rtbJogDistance.LabelWidthPercent = -1;
            this.rtbJogDistance.Location = new System.Drawing.Point(3, 28);
            this.rtbJogDistance.Margin = new System.Windows.Forms.Padding(4);
            this.rtbJogDistance.Multiline = false;
            this.rtbJogDistance.Name = "rtbJogDistance";
            this.rtbJogDistance.Size = new System.Drawing.Size(183, 21);
            this.rtbJogDistance.TabIndex = 1;
            this.rtbJogDistance.ValueText = "";
            // 
            // btnJogPos
            // 
            this.btnJogPos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnJogPos.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btnJogPos.Location = new System.Drawing.Point(245, 3);
            this.btnJogPos.Name = "btnJogPos";
            this.btnJogPos.Size = new System.Drawing.Size(46, 46);
            this.btnJogPos.TabIndex = 5;
            this.btnJogPos.Text = "++";
            this.btnJogPos.UseVisualStyleBackColor = true;
            this.btnJogPos.Click += new System.EventHandler(this.btnJogPos_Click);
            // 
            // rtbJogSpeed
            // 
            this.rtbJogSpeed.IsPasswordField = false;
            this.rtbJogSpeed.LabelText = "Jog Speed";
            this.rtbJogSpeed.LabelWidthPercent = -1;
            this.rtbJogSpeed.Location = new System.Drawing.Point(3, 3);
            this.rtbJogSpeed.Multiline = false;
            this.rtbJogSpeed.Name = "rtbJogSpeed";
            this.rtbJogSpeed.Size = new System.Drawing.Size(184, 21);
            this.rtbJogSpeed.TabIndex = 7;
            this.rtbJogSpeed.ValueText = "";
            // 
            // btnJogNeg
            // 
            this.btnJogNeg.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnJogNeg.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnJogNeg.Location = new System.Drawing.Point(193, 3);
            this.btnJogNeg.Name = "btnJogNeg";
            this.btnJogNeg.Size = new System.Drawing.Size(46, 46);
            this.btnJogNeg.TabIndex = 8;
            this.btnJogNeg.Text = "- -";
            this.btnJogNeg.UseVisualStyleBackColor = true;
            this.btnJogNeg.Click += new System.EventHandler(this.btnJogNeg_Click);
            // 
            // JogPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnJogNeg);
            this.Controls.Add(this.rtbJogSpeed);
            this.Controls.Add(this.btnJogPos);
            this.Controls.Add(this.rtbJogDistance);
            this.Name = "JogPanel";
            this.Size = new System.Drawing.Size(294, 53);
            this.ResumeLayout(false);

        }

        #endregion
        private RoboLib.GUI.Controls.RTextBox rtbJogDistance;
        private System.Windows.Forms.Button btnJogPos;
        private RoboLib.GUI.Controls.RTextBox rtbJogSpeed;
        private System.Windows.Forms.Button btnJogNeg;
    }
}
