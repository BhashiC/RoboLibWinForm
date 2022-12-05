using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RoboLib.GUI.Controls
{
    public partial class RCheckBox : UserControl
    {
        public Control ValueControl
        {
            get { return rcbDefault; }
        }

        public string LabelText
        {
            get { return rcbDefault.Text; }
            set { rcbDefault.Text = value; }
        }

        public bool Value
        {
            get { return rcbDefault.Checked; }
            set { rcbDefault.Checked = value; }
        }

        public RCheckBox()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Set Value Control to read only
        /// </summary>
        /// <param name="readOnly"></param>
        public void SetReadOnly(bool readOnly = false)
        {
            rcbDefault.Enabled = !readOnly;
        }
    }
}
