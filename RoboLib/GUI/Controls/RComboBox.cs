using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RoboLib.GUI.Controls
{
    public partial class RComboBox : UserControl, IControlPair
    {
        public Control LabelControl 
        {
            get { return lbName; }
        }

        public Control ValueControl 
        {
            get { return cbValue; }
        }
        public string LabelText
        {
            get { return lbName.Text; }
            set { lbName.Text = value; }
        }

        public string ValueText
        {
            get { return cbValue.Text; }
            set { cbValue.Text = value; }
        }

        public RComboBox()
        {
            InitializeComponent();
        }
    }
}
