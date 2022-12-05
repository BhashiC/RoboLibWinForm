
namespace RoboLib.GUI.Controls
{
    partial class RComboBox
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
            this.cbValue = new System.Windows.Forms.ComboBox();
            this.lbName = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cbValue
            // 
            this.cbValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbValue.FormattingEnabled = true;
            this.cbValue.Location = new System.Drawing.Point(41, 0);
            this.cbValue.Name = "cbValue";
            this.cbValue.Size = new System.Drawing.Size(129, 21);
            this.cbValue.TabIndex = 5;
            // 
            // lbName
            // 
            this.lbName.AutoSize = true;
            this.lbName.Dock = System.Windows.Forms.DockStyle.Left;
            this.lbName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lbName.Location = new System.Drawing.Point(0, 0);
            this.lbName.Name = "lbName";
            this.lbName.Size = new System.Drawing.Size(41, 15);
            this.lbName.TabIndex = 4;
            this.lbName.Text = "label1";
            // 
            // RComboBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cbValue);
            this.Controls.Add(this.lbName);
            this.Name = "RComboBox";
            this.Size = new System.Drawing.Size(170, 21);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbValue;
        private System.Windows.Forms.Label lbName;
    }
}
