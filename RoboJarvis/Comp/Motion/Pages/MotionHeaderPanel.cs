using RoboLib.Extensions;
using RoboLib.GUI.Pages;
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

namespace RoboJarvis.Comp.Motion.Pages
{
    public partial class MotionHeaderPanel : ViewPage
    {
        Axis _axis;
        public MotionHeaderPanel()
        {
            InitializeComponent();
        }

        protected override void DefineBinding(ObjBase objBase)
        {
            base.DefineBinding(objBase);
            _axis = objBase as Axis;

            lblAxisName.Text = _axis.Name;
            rtbCurrentPosition.SetReadOnly(true);
            rtbCurrentPosition.BindToProperty(_axis, "CurrentPosition", false);
            rcbEnabled.SetReadOnly(true);
            rcbEnabled.BindToProperty(_axis, "AxisEnabled", false);
            _axis.PropertyChanged += new PropertyChangedEventHandler(_axis_PropertyChanged);
            _axis_PropertyChanged(null, new PropertyChangedEventArgs("AxisEnabled"));
        }

        void _axis_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "AxisEnabled")
            {
                btnEnable.Text = _axis.AxisEnabled ? "Disable" : "Enable";
            }
        }

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            _axis.PropertyChanged -= new PropertyChangedEventHandler(_axis_PropertyChanged);
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void btnEnable_Click(object sender, EventArgs e)
        {
            btnEnable.Enabled = false;
            try
            {
                if (_axis.AxisEnabled)
                {
                    _axis.SetAxisDisable();
                }
                else
                {
                    _axis.SetAxisEnable();
                }
            }
            finally
            {
                btnEnable.Enabled = true;
            }
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            btnHome.RunAsync(() => _axis.MoveHome());
        }
    }
}
