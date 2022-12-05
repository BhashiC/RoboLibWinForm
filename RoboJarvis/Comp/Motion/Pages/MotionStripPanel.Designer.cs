
namespace RoboJarvis.Comp.Motion.Pages
{
    partial class MotionStripPanel
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
            this.btnMove = new System.Windows.Forms.Button();
            this.rtbSpeed = new RoboLib.GUI.Controls.RTextBox();
            this.rtbPosition = new RoboLib.GUI.Controls.RTextBox();
            this.SuspendLayout();
            // 
            // btnMove
            // 
            this.btnMove.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnMove.Font = new System.Drawing.Font("Wingdings 3", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.btnMove.Location = new System.Drawing.Point(255, 1);
            this.btnMove.Name = "btnMove";
            this.btnMove.Size = new System.Drawing.Size(36, 20);
            this.btnMove.TabIndex = 4;
            this.btnMove.Text = "}}";
            this.btnMove.UseVisualStyleBackColor = true;
            this.btnMove.Click += new System.EventHandler(this.btnMove_Click);
            // 
            // rtbSpeed
            // 
            this.rtbSpeed.IsPasswordField = false;
            this.rtbSpeed.LabelText = "Speed";
            this.rtbSpeed.LabelWidthPercent = -1;
            this.rtbSpeed.Location = new System.Drawing.Point(143, 0);
            this.rtbSpeed.Multiline = false;
            this.rtbSpeed.Name = "rtbSpeed";
            this.rtbSpeed.Size = new System.Drawing.Size(106, 21);
            this.rtbSpeed.TabIndex = 6;
            this.rtbSpeed.ValueText = "";
            // 
            // rtbPosition
            // 
            this.rtbPosition.IsPasswordField = false;
            this.rtbPosition.LabelText = "Position";
            this.rtbPosition.LabelWidthPercent = -1;
            this.rtbPosition.Location = new System.Drawing.Point(3, 0);
            this.rtbPosition.Multiline = false;
            this.rtbPosition.Name = "rtbPosition";
            this.rtbPosition.Size = new System.Drawing.Size(134, 21);
            this.rtbPosition.TabIndex = 5;
            this.rtbPosition.ValueText = "";
            // 
            // MotionStripPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.rtbSpeed);
            this.Controls.Add(this.rtbPosition);
            this.Controls.Add(this.btnMove);
            this.Name = "MotionStripPanel";
            this.Size = new System.Drawing.Size(294, 21);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnMove;
        private RoboLib.GUI.Controls.RTextBox rtbPosition;
        private RoboLib.GUI.Controls.RTextBox rtbSpeed;
    }
}
