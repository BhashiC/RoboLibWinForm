using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RoboLib.Models;
using RoboLib.Extensions;

namespace RoboLib.GUI.Pages
{
    public partial class ComponentGeneralPage : ViewPage
    {
        public ComponentGeneralPage()
        {
            InitializeComponent();
        }

        ObjBase _boundObj;
        protected override void DefineBinding(ObjBase objBase)
        {
            base.DefineBinding(objBase);
            _boundObj = objBase ?? Robot.Instance;
            Dock = DockStyle.Left;
            panelViewOnly.RenderObjBaseSettings(_boundObj, PropertyViewModes.ReadOnly);
            panelSettings.RenderObjBaseSettings(_boundObj, PropertyViewModes.Setting);
        }
    }
}
