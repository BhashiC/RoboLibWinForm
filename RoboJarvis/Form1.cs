using Robo3DWpf;
using RoboJarvis.Comp.Motion;
using RoboJarvis.Comp.PathPlan;
using RoboJarvis.Pages;
using RoboLib;
using RoboLib.Extensions;
using RoboLib.GUI;
using RoboLib.GUI.Pages;
using RoboLib.Models;
using RoboLib.Models.Communication;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RoboJarvis
{
    public partial class Form1 : Form1Base
    {
        JarvisRobot _robot;
        Robo3DUserControl _robo3DUserControl;
        PathPlanner _pathPlanner;

        public Form1()
        {
            InitializeComponent();
        }

        protected override void DefineRobot()
        {
            base.DefineRobot();

            _robot = SystemBuilder.Instance.InitializeRoboLib().DefineRobot(CompNames.Jarvis.ToString(), typeof(JarvisRobot)).Build<JarvisRobot>();
            var controller1 = ComponentBuilder.DefineComponent(_robot, CompNames.Joint1.ToString(), typeof(MKSAxis))
                .WithFirstTimeInit<MKSAxis>(x => x.SetDefaultLimits())
                .WithPluginType(PlugInTypes.MKS42A57A.ToString()).Build<MKSAxis>();
            var controller2 = ComponentBuilder.DefineComponent(_robot, CompNames.Joint2.ToString(), typeof(MKSAxis))
                .WithFirstTimeInit<MKSAxis>(x => x.SetDefaultLimits())
                .WithPluginType(PlugInTypes.MKS42A57A.ToString()).Build<MKSAxis>();
            var controller3 = ComponentBuilder.DefineComponent(_robot, CompNames.Joint3.ToString(), typeof(MKSAxis))
                .WithFirstTimeInit<MKSAxis>(x => x.SetDefaultLimits())
                .WithPluginType(PlugInTypes.MKS42A57A.ToString()).Build<MKSAxis>();
            var controller4 = ComponentBuilder.DefineComponent(_robot, CompNames.Joint4.ToString(), typeof(MKSAxis))
                .WithFirstTimeInit<MKSAxis>(x => x.SetDefaultLimits())
                .WithPluginType(PlugInTypes.MKS42A57A.ToString()).Build<MKSAxis>();
            var controller5 = ComponentBuilder.DefineComponent(_robot, CompNames.Joint5.ToString(), typeof(MKSAxis))
                .WithFirstTimeInit<MKSAxis>(x => x.SetDefaultLimits())
                .WithPluginType(PlugInTypes.MKS42A57A.ToString()).Build<MKSAxis>();
            var controller6 = ComponentBuilder.DefineComponent(_robot, CompNames.Joint6.ToString(), typeof(MKSAxis))
                .WithFirstTimeInit<MKSAxis>(x => x.SetDefaultLimits())
                .WithPluginType(PlugInTypes.MKS42A57A.ToString()).Build<MKSAxis>();
            ComponentBuilder.DefineComponent(controller1, CompNames.J1Rs232.ToString(), typeof(RS232)).Build<RS232>();
            ComponentBuilder.DefineComponent(controller2, CompNames.J2Rs232.ToString(), typeof(RS232)).Build<RS232>();
            ComponentBuilder.DefineComponent(controller3, CompNames.J3Rs232.ToString(), typeof(RS232)).Build<RS232>();
            ComponentBuilder.DefineComponent(controller4, CompNames.J4Rs232.ToString(), typeof(RS232)).Build<RS232>();
            ComponentBuilder.DefineComponent(controller5, CompNames.J5Rs232.ToString(), typeof(RS232)).Build<RS232>();
            ComponentBuilder.DefineComponent(controller6, CompNames.J6Rs232.ToString(), typeof(RS232)).Build<RS232>();
            _pathPlanner = ComponentBuilder.DefineComponent(_robot, CompNames.PathPlan.ToString(), typeof(PathPlanner)).Build<PathPlanner>();


            _robot.InitializeRecurse();         
        }

        protected override void DefineBinding()
        {
            base.DefineBinding();

            // Create the WPF UserControl
            _robo3DUserControl = new Robo3DUserControl();

            // Assign the WPF UserControl to the ElementHost control's
            // Child property.
            //this.BackColor = Color.FromArgb(135, 128, 136);
            this.BackColor = Color.FromArgb(142, 136, 142);
            toolStrip1.BackColor = Color.FromArgb(62, 62, 66);
            elementHost1.Child = _robo3DUserControl;
            _robot.RoboModelWpfControl = _robo3DUserControl;

            jointAngleTrackBarPanel1.PerformBinding(_robot);
            pathPlanPage1.PerformBinding(_pathPlanner);
        }
        //protected override void ona

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            OnForm1Closing(e);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            OnForm1Load();
        }

        private void toolStripButtonSettings_Click(object sender, EventArgs e)
        {
            using (var frm = new SettingsForm())
            {
                frm.ShowDialog();
            }
        }

        private void toolStripButtonJoints_Click(object sender, EventArgs e)
        {
            using (var frm = new Form()
            {
                Width = 970,
                Height = 840,
                Text = "Joint Control Page",
                ShowIcon = false,
                StartPosition = FormStartPosition.CenterParent,
                //MaximizeBox = false,
                BackColor = Color.FromArgb(62, 62, 66),
                MinimizeBox = false,
                FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow,
                AutoScroll = true
            })
            {
                JointControlPage jointPage = new JointControlPage() { Dock = DockStyle.Fill };
                jointPage.PerformBinding(_robot);
                frm.AddAndBringToFront<JointControlPage>(jointPage);
                frm.ShowDialog();
            }
        }
    }
}
