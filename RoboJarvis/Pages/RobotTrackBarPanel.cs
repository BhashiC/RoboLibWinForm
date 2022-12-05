using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RoboLib.GUI.Pages;
using RoboLib.Models;
using RoboJarvis.Comp.Motion;
using RoboLib.Extensions;
using Robo3DWpf;

namespace RoboJarvis.Pages
{
    public partial class RobotTrackBarPanel : ViewPage
    {
        JarvisRobot _robot;
        Robo3DUserControl _wpfControl;

        public RobotTrackBarPanel()
        {
            InitializeComponent();
        }

        protected override void DefineBinding(ObjBase objBase)
        {
            base.DefineBinding(objBase);

            _robot = objBase as JarvisRobot;
            _wpfControl = _robot.RoboModelWpfControl;
            var kinematics = _wpfControl.RobotKinematics;
            var joints = _wpfControl.MainJoints;

            rtbToolTipXCoordinate.SetReadOnly(true);
            rtbToolTipXCoordinate.BindToProperty(kinematics, "EndEffectorXCoordinate", false);
            rtbToolTipYCoordinate.SetReadOnly(true);
            rtbToolTipYCoordinate.BindToProperty(kinematics, "EndEffectorYCoordinate", false);
            rtbToolTipZCoordinate.SetReadOnly(true);
            rtbToolTipZCoordinate.BindToProperty(kinematics, "EndEffectorZCoordinate", false);

            rtrbarEndPointX.Minimum = -550;
            rtrbarEndPointX.Maximum = 550;
            rtrbarEndPointX.BindToProperty(kinematics, "EndPointXCoordinate", false);
            rtrbarEndPointY.Minimum = -550;
            rtrbarEndPointY.Maximum = 550;
            rtrbarEndPointY.BindToProperty(kinematics, "EndPointYCoordinate", false);
            rtrbarEndPointZ.Minimum = 0;
            rtrbarEndPointZ.Maximum = 815;
            rtrbarEndPointZ.BindToProperty(kinematics, "EndPointZCoordinate", false);

            foreach (Joint j in joints)
            {
                if (j.Name == CompNames.Joint1.ToString())
                {
                    rtrbarJoint1.Minimum = j.LowerLimit;
                    rtrbarJoint1.Maximum = j.UpperLimit;
                    rtrbarJoint1.BindToProperty(j, "Angle", false);
                }
                else if (j.Name == CompNames.Joint2.ToString())
                {
                    rtrbarJoint2.Minimum = j.LowerLimit;
                    rtrbarJoint2.Maximum = j.UpperLimit;
                    rtrbarJoint2.BindToProperty(j, "Angle", false);
                }
                else if (j.Name == CompNames.Joint3.ToString())
                {
                    rtrbarJoint3.Minimum = j.LowerLimit;
                    rtrbarJoint3.Maximum = j.UpperLimit;
                    rtrbarJoint3.BindToProperty(j, "Angle", false);
                }
                else if (j.Name == CompNames.Joint4.ToString())
                {
                    rtrbarJoint4.Minimum = j.LowerLimit;
                    rtrbarJoint4.Maximum = j.UpperLimit;
                    rtrbarJoint4.BindToProperty(j, "Angle", false);
                }
                else if (j.Name == CompNames.Joint5.ToString())
                {
                    rtrbarJoint5.Minimum = j.LowerLimit;
                    rtrbarJoint5.Maximum = j.UpperLimit;
                    rtrbarJoint5.BindToProperty(j, "Angle", false);
                }
                else if (j.Name == CompNames.Joint6.ToString())
                {
                    rtrbarJoint6.Minimum = j.LowerLimit;
                    rtrbarJoint6.Maximum = j.UpperLimit;
                    rtrbarJoint6.BindToProperty(j, "Angle", false);
                }
            }
        }
    }
}
