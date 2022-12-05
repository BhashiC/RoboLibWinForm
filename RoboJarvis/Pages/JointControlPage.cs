using RoboJarvis.Comp.Motion;
using RoboJarvis.Comp.Motion.Pages;
using RoboLib.GUI.Pages;
using RoboLib.Models;
using RoboLib.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RoboJarvis.Pages
{
    public partial class JointControlPage : ViewPage
    {
        JarvisRobot _robot;
        public JointControlPage()
        {
            InitializeComponent();
        }

        protected override void DefineBinding(ObjBase objBase)
        {
            base.DefineBinding(objBase);
            _robot = objBase as JarvisRobot;
            var joints = _robot.Children.Where(x => x.GenericType == typeof(MKSAxis).Name).ToList();
            joints.Reverse();
            foreach (MKSAxis j in joints) 
            {
                MKSAxisPage axisPage = new MKSAxisPage();
                axisPage.PerformBinding(j);
                flpanelJoints.AddAndBringToFront<MKSAxisPage>(axisPage);
            }
        }
    }
}
