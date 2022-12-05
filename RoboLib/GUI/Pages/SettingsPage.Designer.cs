
namespace RoboLib.GUI.Pages
{
    partial class SettingsPage
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
            this.treePage = new RoboLib.GUI.Pages.TreePage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tabControlPages = new System.Windows.Forms.TabControl();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // treePage
            // 
            this.treePage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treePage.Location = new System.Drawing.Point(0, 0);
            this.treePage.Name = "treePage";
            this.treePage.Size = new System.Drawing.Size(204, 410);
            this.treePage.TabIndex = 0;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.treePage);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tabControlPages);
            this.splitContainer1.Size = new System.Drawing.Size(615, 410);
            this.splitContainer1.SplitterDistance = 204;
            this.splitContainer1.TabIndex = 2;
            // 
            // tabControlPages
            // 
            this.tabControlPages.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlPages.Location = new System.Drawing.Point(0, 0);
            this.tabControlPages.Name = "tabControlPages";
            this.tabControlPages.SelectedIndex = 0;
            this.tabControlPages.Size = new System.Drawing.Size(407, 410);
            this.tabControlPages.TabIndex = 0;
            // 
            // SettingsPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "SettingsPage";
            this.Size = new System.Drawing.Size(615, 410);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private TreePage treePage;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TabControl tabControlPages;
    }
}
