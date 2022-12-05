using RoboLib.Extensions;
using RoboLib.GUI.Pages;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace RoboLib.Models.Communication.Pages
{
    public partial class RS232SettingsPanel : ViewPage
    {
        RS232 _rs232;

        public RS232SettingsPanel()
        {
            InitializeComponent();
        }

        protected override void DefineBinding(ObjBase objBase)
        {
            base.DefineBinding(objBase);
            _rs232 = objBase as RS232;
            rcbComPort.BindToProperty(_rs232, "ComPort", false).UseDataSource(_rs232.ComPorts);
            rcbBaudRate.BindToProperty(_rs232, "BaudRate", false).UseDataSource(_rs232.BaudRates);
            rcbHandShake.BindToProperty(_rs232, "HandShake", false);
            rcbNewLine.BindToProperty(_rs232, "NewLine", false);
            rcbParity.BindToProperty(_rs232, "Parity", false);
            rcbStopBits.BindToProperty(_rs232, "StopBits", false);
            rtbDataBits.BindToProperty(_rs232, "DataBits", false);
            rtbTimeout.BindToProperty(_rs232, "Timeout", false);
        }
    }
}
