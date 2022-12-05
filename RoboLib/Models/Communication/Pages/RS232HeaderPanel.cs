using RoboLib.Extensions;
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
    public partial class RS232HeaderPanel : ViewPage
    {
        RS232 _rs232;

        public RS232HeaderPanel()
        {
            InitializeComponent();
        }

        protected override void DefineBinding(ObjBase objBase)
        {
            base.DefineBinding(objBase);
            _rs232 = objBase as RS232;

            lblRS232Name.Text = _rs232.Name;
            rcbConnected.SetReadOnly(true);
            rcbConnected.BindToProperty(_rs232, "Connected", false);
            rtbResponse.SetReadOnly(true);
            rtbResponse.BindToProperty(_rs232, "Response", false);
            rcbCommand.BindToProperty(_rs232, "Command", false).UseDataSource(_rs232.Commands, true);

            _rs232.PropertyChanged += new PropertyChangedEventHandler(_rs232_PropertyChanged);
            _rs232_PropertyChanged(null, new PropertyChangedEventArgs("Connected"));
        }

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            _rs232.PropertyChanged -= new PropertyChangedEventHandler(_rs232_PropertyChanged);
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        void _rs232_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "Connected")
            {
                btnConnect.Text = _rs232.Connected ? "Disconnect" : "Connect";
                btnSend.Enabled = _rs232.Connected;
            }
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            btnConnect.Enabled = false;
            try
            {
                if (_rs232.Connected)
                {
                    _rs232.Disconnect();
                }
                else
                {
                    _rs232.Connect();
                }
            }
            finally
            {
                btnConnect.Enabled = true;
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            var cmd = _rs232.Command;
            _rs232.Response = "";
            _rs232.ReadPortCmd(cmd, true);
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            if (_rs232.CommandList.Count > 0)
            {
                using (Form frm = new Form()
                {
                    Width = 260,
                    Height = 200,
                    Text = "Command List Help",
                    ShowIcon = false,
                    StartPosition = FormStartPosition.CenterParent,
                    MaximizeBox = false,
                    MinimizeBox = false,
                    FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
                })
                {
                    frm.AddAndBringToFront(new RS232HelpPanel() { Dock = DockStyle.Fill }.PerformBinding(_rs232));
                    frm.ShowDialog();
                };
            }
            else 
            {
                MessageBox.Show("Help is not setup for this channel", "Help Error");
            }
        }
    }
}
