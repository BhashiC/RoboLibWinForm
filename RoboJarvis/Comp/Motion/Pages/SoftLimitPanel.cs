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
    public partial class SoftLimitPanel : ViewPage
    {
        Axis _axis;

        public SoftLimitPanel()
        {
            InitializeComponent();
        }

        protected override void DefineBinding(ObjBase objBase)
        { 
            base.DefineBinding(objBase);
            _axis = objBase as Axis;

            rtbLowerLimit.BindToProperty(_axis, "LowerLimit", false);
            rtbUpperLimit.BindToProperty(_axis, "UpperLimit", false);
        }
    }
}
