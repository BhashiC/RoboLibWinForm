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
    public partial class MKSAxisPage : ViewPage
    {
        Axis _axis;
        public MKSAxisPage()
        {
            InitializeComponent();
        }

        protected override void DefineBinding(ObjBase objBase)
        {
            base.DefineBinding(objBase);
            _axis = objBase as Axis;

            motionHeaderPanel1.PerformBinding(_axis);
            jogPanel1.PerformBinding(_axis);
            softLimitPanel1.PerformBinding(_axis);
            mksSettingsPanel1.PerformBinding(_axis);

            for (int i = _axis.Positions.Count - 1; i >= 0; i--)
            {
                flpPositions.AddAndBringToFront(new MotionStripPanel().PerformBinding(_axis.Positions.ElementAt(i)));
            }
        }
    }
}
