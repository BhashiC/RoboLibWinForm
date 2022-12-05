using RoboLib.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RoboLib.GUI.Pages
{
    public partial class SettingsPage : ViewPage
    {
        PropertyPageViewModel _item;
        public SettingsPage()
        {
            InitializeComponent();
        }

        protected override void DefineBinding(ObjBase objBase)
        {
            base.DefineBinding(objBase);
            treePage.PerformBinding();
            treePage.evAfterSelect += new Action<object>(treePage_evAfterSelect);
            tabControlPages.SelectedIndexChanged += new EventHandler(tabControlPages_SelectedIndexChanged);
        }

        void tabControlPages_SelectedIndexChanged(object sender, EventArgs e)
        {
            TabPage selectedTab = tabControlPages.SelectedTab;
            if (selectedTab != null && selectedTab.Controls.Count == 0)
            {
                selectedTab.Controls.Add(((ViewPage)Activator.CreateInstance(_item.PageType)).PerformBinding(_item.Obj));
            }
        }

        void treePage_evAfterSelect(object obj)
        {
            this.SuspendLayout();
            try
            {
                tabControlPages.TabPages.Clear();
                
                var pages = (obj as ComponentBase).GetPropertyPages();
                int i = 0;
                foreach (var item in pages)
                {
                    _item = item;
                    if (item.PageType.BaseType != typeof(ViewPage))
                    {
                        throw new Exception(string.Format("Auto Property Page supported ViewPage only. Obj [{0}], Page [{1}]", item.Obj.Name, item.PageType));
                    }

                    tabControlPages.TabPages.Add(item.PageTitle);
                    tabControlPages.SelectTab(i);
                    tabControlPages_SelectedIndexChanged(tabControlPages, null);
                    i++;
                }
                if (tabControlPages.TabPages.Count != 0)
                {
                    //Always display 1st tab as the selected tab
                    tabControlPages.SelectTab(0);
                }
            }
            finally
            {
                this.ResumeLayout();
            }
        }

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            treePage.evAfterSelect -= new Action<object>(treePage_evAfterSelect);
            tabControlPages.SelectedIndexChanged += new EventHandler(tabControlPages_SelectedIndexChanged);
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
