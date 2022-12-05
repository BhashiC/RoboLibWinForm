
namespace RoboLib.Models.Communication.Pages
{
    partial class RS232Page
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
            this.rS232HeaderPanel1 = new RoboLib.Models.Communication.Pages.RS232HeaderPanel();
            this.rS232SettingsPanel1 = new RoboLib.Models.Communication.Pages.RS232SettingsPanel();
            this.SuspendLayout();
            // 
            // rS232HeaderPanel1
            // 
            this.rS232HeaderPanel1.BackColor = System.Drawing.Color.Gold;
            this.rS232HeaderPanel1.Location = new System.Drawing.Point(3, 3);
            this.rS232HeaderPanel1.Name = "rS232HeaderPanel1";
            this.rS232HeaderPanel1.Size = new System.Drawing.Size(238, 128);
            this.rS232HeaderPanel1.TabIndex = 0;
            // 
            // rS232SettingsPanel1
            // 
            this.rS232SettingsPanel1.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.rS232SettingsPanel1.Location = new System.Drawing.Point(3, 137);
            this.rS232SettingsPanel1.Name = "rS232SettingsPanel1";
            this.rS232SettingsPanel1.Size = new System.Drawing.Size(238, 232);
            this.rS232SettingsPanel1.TabIndex = 1;
            // 
            // RS232Page
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGray;
            this.Controls.Add(this.rS232SettingsPanel1);
            this.Controls.Add(this.rS232HeaderPanel1);
            this.Name = "RS232Page";
            this.Size = new System.Drawing.Size(245, 375);
            this.ResumeLayout(false);

        }

        #endregion

        private RS232HeaderPanel rS232HeaderPanel1;
        private RS232SettingsPanel rS232SettingsPanel1;
    }
}
