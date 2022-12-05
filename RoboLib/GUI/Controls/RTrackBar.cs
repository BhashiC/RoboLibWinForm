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
    public partial class RTrackBar : UserControl, IControlPair
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

        /// <summary>
        /// TrackBar value precision
        /// </summary>
        public double Precision { get; set; }

        /// <summary>
        /// TrackBar value decimal precision
        /// </summary>
        public double TrackBarValue
        {
            get
            {
                return trackBar.Value * Precision;
            }
            set
            {
                trackBar.Value = (int)(value / Precision);
            }
        }

        /// <summary>
        /// TrackBar Minimum value
        /// </summary>
        public double Minimum
        {
            get
            {
                return trackBar.Minimum * Precision;
            }
            set
            {
                trackBar.Minimum = (int)(value / Precision);
            }
        }

        /// <summary>
        /// TrackBar Maximum value
        /// </summary>
        public double Maximum
        {
            get
            {
                return trackBar.Maximum * Precision;
            }
            set
            {
                trackBar.Maximum = (int)(value / Precision);
            }
        }

        /// <summary>
        /// Small change by Arrow keys
        /// </summary>
        public double SmallChange
        {
            get
            {
                return trackBar.SmallChange * Precision;
            }
            set
            {
                trackBar.SmallChange = (int)(value / Precision);
            }
        }

        /// <summary>
        /// Large change by mouse click or PgUp/Dn buttons
        /// </summary>
        public double LargeChange
        {
            get
            {
                return trackBar.LargeChange * Precision;
            }
            set
            {
                trackBar.LargeChange = (int)(value / Precision);
            }
        }

        public RTrackBar()
        {
            InitializeComponent();
            Precision = 0.01;
            Minimum = -100;
            Maximum = 100;
            SmallChange = 0.01;
            LargeChange = 1;
        }

        private void trackBar_ValueChanged(object sender, EventArgs e)
        {
            tbValue.Text = TrackBarValue.ToString();
        }

        public void UpdateTrackBarValue()
        {
            TrackBarValue = Convert.ToDouble(tbValue.Text);
        }

        private void tbValue_Validated(object sender, EventArgs e)
        {
            TrackBarValue = Convert.ToDouble(tbValue.Text);
        }

        bool FirstTimeOnly = true;
        private void tbValue_TextChanged(object sender, EventArgs e)
        {
            if (FirstTimeOnly)
            {
                UpdateTrackBarValue();
                FirstTimeOnly = false;
            }
        }
    }
}
