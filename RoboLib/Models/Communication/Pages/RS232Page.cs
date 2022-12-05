using RoboLib.GUI.Pages;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RoboLib.Models.Communication.Pages
{
    public partial class RS232Page : ViewPage
    {
        RS232 _rs232;

        public RS232Page()
        {
            InitializeComponent();
        }

        protected override void DefineBinding(ObjBase objBase)
        {
            base.DefineBinding(objBase);
            _rs232 = objBase as RS232;
            rS232HeaderPanel1.PerformBinding(_rs232);
            rS232SettingsPanel1.PerformBinding(_rs232);
        }
    }
}
