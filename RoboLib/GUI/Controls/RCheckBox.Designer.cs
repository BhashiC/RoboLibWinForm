namespace RoboLib.GUI.Controls
{
    partial class RCheckBox
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
            this.rcbDefault = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // rcbDefault
            // 
            this.rcbDefault.AutoSize = true;
            this.rcbDefault.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rcbDefault.Location = new System.Drawing.Point(0, 0);
            this.rcbDefault.Name = "rcbDefault";
            this.rcbDefault.Size = new System.Drawing.Size(86, 16);
            this.rcbDefault.TabIndex = 0;
            this.rcbDefault.Text = "RCheckBox";
            this.rcbDefault.UseVisualStyleBackColor = true;
            // 
            // RCheckBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.rcbDefault);
            this.Name = "RCheckBox";
            this.Size = new System.Drawing.Size(86, 16);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox rcbDefault;
    }
}
