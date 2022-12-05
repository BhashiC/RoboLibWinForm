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
using RoboLib.Extensions;

namespace RoboLib.Models.Communication.Pages
{
    public partial class RS232HelpPanel : ViewPage
    {
        RS232 _rs232;

        public RS232HelpPanel()
        {
            InitializeComponent();
        }

        protected override void DefineBinding(ObjBase objBase)
        {
            base.DefineBinding(objBase);
            _rs232 = objBase as RS232;

            listBoxHelp.DataSource = _rs232.CommandList;
        }
    }
}
