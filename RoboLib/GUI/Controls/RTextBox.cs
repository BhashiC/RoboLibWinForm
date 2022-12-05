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
    public partial class RTextBox : UserControl, IControlPair
    {
        public Control LabelControl
        {
            get { return lbName; }
        }

        public Control ValueControl
        {
            get { return tbValue; }
        }

        public string LabelText
        {
            get { return lbName.Text; }
            set { lbName.Text = value; }
        }

        public string ValueText
        {
            get { return tbValue.Text; }
            set { tbValue.Text = value; }
        }

        public bool Multiline
        {
            get { return tbValue.Multiline; }
            set { tbValue.Multiline = value; }
        }

        public bool IsPasswordField
        {
            get { return tbValue.UseSystemPasswordChar; }
            set { tbValue.UseSystemPasswordChar = value; }
        }

        int _labelWidthPercent = -1;
        /// <summary>
        ///  Width of label, -1 for auto label width
        /// </summary>
        public int LabelWidthPercent
        {
            get
            {
                return _labelWidthPercent;
            }
            set
            {
                _labelWidthPercent = value;
                if (value > -1)
                {
                    lbName.AutoSize = false;
                    lbName.Width = value * this.Width / 100;
                }
                else
                {
                    lbName.AutoSize = true;
                }
            }
        }

        public RTextBox()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Set Value Control to read only
        /// </summary>
        /// <param name="readOnly"></param>
        public void SetReadOnly(bool readOnly = false) 
        {
            tbValue.ReadOnly = readOnly;
        }

        private void tbValue_TextChanged(object sender, EventArgs e)
        {
            if (!tbValue.Focused) //This will make sure change is only from GUI
            {
                return;
            }
            else
            {
                tbValue.BackColor = Color.Yellow;
            }
        }
    }
}
