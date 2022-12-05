
namespace RoboJarvis.Pages
{
    partial class JointControlPage
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
            this.flpanelJoints = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // flpanelJoints
            // 
            this.flpanelJoints.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpanelJoints.Location = new System.Drawing.Point(0, 0);
            this.flpanelJoints.Name = "flpanelJoints";
            this.flpanelJoints.Size = new System.Drawing.Size(950, 872);
            this.flpanelJoints.TabIndex = 0;
            // 
            // JointControlPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.flpanelJoints);
            this.Name = "JointControlPage";
            this.Size = new System.Drawing.Size(950, 872);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flpanelJoints;
    }
}
