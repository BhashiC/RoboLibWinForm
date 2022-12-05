using RoboLib.GUI.Controls;
using RoboLib.Models;
using RoboLib.Utils.Singletons;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RoboLib.GUI
{
    public partial class Form1Base : Form
    {
        public Form1Base()
        {
            InitializeComponent();
        }

        protected void OnForm1Load()
        {
            RefControl.Instance = this;
            DefineRobot();

            Type t = this.GetType();
            string formTitle = string.Format("{0} - Ver {1}. Launched on {2} at {3}.",
               VersionUtils.Instance.GetAssemblyName(t.Assembly),
               //System.Environment.MachineName,
               VersionUtils.Instance.GetAssemblyVersion(t.Assembly),
               DateTime.Now.ToString("dd MMM yyyy"),
               DateTime.Now.ToString("HH:mm:ss"));
            this.Text = formTitle;

            DefineBinding();
        }

        protected void OnForm1Closing(FormClosingEventArgs e) 
        {
            string message = string.Format("Do you want to close the {0} Software?", Robot.Instance.Name);
            if (MessageBox.Show(message, "Confirm Exit!", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                OnApplicationExit();
            }
            else 
            {
                e.Cancel = true;
            }
        }

        protected void OnApplicationExit()
        {
            try
            {
                Robot.Instance.SaveRobot();
                Robot.Instance.DestroyRecurse();
            }
            catch (Exception ex)
            {
                throw new RException("Robo Software Closing Error", ex);
            }
        }

        /// <summary>
        /// Override this to define Robot and  Components
        /// </summary>
        protected virtual void DefineRobot()
        {

        }

        /// <summary>
        /// Override this to define binding
        /// </summary>
        protected virtual void DefineBinding()
        {

        }
    }
}
