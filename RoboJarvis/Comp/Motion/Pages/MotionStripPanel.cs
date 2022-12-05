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
    public partial class MotionStripPanel : ViewPage
    {
        AxisPosition _axisPos;
        public MotionStripPanel()
        {
            InitializeComponent();
        }

        protected override void DefineBinding(ObjBase objBase)
        {
            base.DefineBinding(objBase);
            _axisPos = objBase as AxisPosition;

            rtbPosition.LabelText = _axisPos.Name;
            rtbPosition.BindToProperty(_axisPos, "Position", false);
            rtbSpeed.BindToProperty(_axisPos, "Speed", false);
        }

        public void SetPositionName(string name) 
        {
            rtbPosition.LabelText = name;
        }

        private void btnMove_Click(object sender, EventArgs e)
        {
            btnMove.RunAsync(() => _axisPos.Axis.MoveAbs(_axisPos.Position, _axisPos.Speed));
        }
    }
}
