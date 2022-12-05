
namespace RoboLib.Models.Communication.Pages
{
    partial class RS232HelpPanel
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
            this.listBoxHelp = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // listBoxHelp
            // 
            this.listBoxHelp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxHelp.FormattingEnabled = true;
            this.listBoxHelp.Location = new System.Drawing.Point(0, 0);
            this.listBoxHelp.Name = "listBoxHelp";
            this.listBoxHelp.Size = new System.Drawing.Size(260, 200);
            this.listBoxHelp.TabIndex = 0;
            // 
            // RS232HelpPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.listBoxHelp);
            this.Name = "RS232HelpPanel";
            this.Size = new System.Drawing.Size(260, 200);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxHelp;
    }
}
