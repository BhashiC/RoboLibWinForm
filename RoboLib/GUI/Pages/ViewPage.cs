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
    public partial class ViewPage : UserControl
    {
        public ViewPage()
        {
            InitializeComponent();
        }

        public ViewPage PerformBinding(ObjBase objBase = null)
        {
            DefineBinding(objBase /*?? Robot.Instance*/);
            return this;
        }
        protected virtual void DefineBinding(ObjBase objBase)
        {
        }
    }
}
