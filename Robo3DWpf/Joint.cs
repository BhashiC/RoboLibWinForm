using RoboLib;
using RoboLib.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Media3D;

namespace Robo3DWpf
{
    public class Joint : ObjBase
    {
        Robo3DUserControl _userControl;

        public Model3D Model { get; set; }

        double _angle;
        [BindingTools(Unit = Units.deg, DisplayFormat = "#0.##")]
        public double Angle
        {
            get
            {
                return _angle;
            }
            set
            {
                _angle = value;
                _userControl.DoForwardKinematics();
            }
        }

        public double LowerLimit { get; set; }
        public double UpperLimit { get; set; }

        public double RotPointX { get; set; }
        public double RotPointY { get; set; }
        public double RotPointZ { get; set; }

        public int RotAxisX { get; set; }
        public int RotAxisY { get; set; }
        public int RotAxisZ { get; set; }

        public List<Joint> SubParts { get; set; }

        public Joint() { }

        public Joint(Model3D model, Robo3DUserControl userControl)
        {
            Model = model;
            _userControl = userControl;
        }

        internal void InitMainJoint(string name, double angleMin, double angleMax, int rotAxisX, int rotAxisY, int rotAxisZ,
                                double rotPointX, double rotPointY, double rotPointZ, List<Joint> subParts)
        {
            Name = name;
            LowerLimit = angleMin;
            UpperLimit = angleMax;
            RotAxisX = rotAxisX;
            RotAxisY = rotAxisY;
            RotAxisZ = rotAxisZ;
            RotPointX = rotPointX;
            RotPointY = rotPointY;
            RotPointZ = rotPointZ;
            SubParts = subParts; 
        }
    }
}
