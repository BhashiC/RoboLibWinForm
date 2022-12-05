using RoboJarvis.Comp.Motion;
using RoboLib;
using RoboLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoboJarvis.Comp.PathPlan
{
    public class WorkPoint : ObjBase
    {
        /// <summary>
        /// Executing order of the point
        /// </summary>
        public int No { get; set; }

        /// <summary>
        /// End point X coordinate
        /// </summary>
        [BindingTools(Unit = Units.mm, DisplayFormat = "#0.##")]
        public double Xcoordinate { get; set; }

        /// <summary>
        /// End point Y coordinate
        /// </summary>
        [BindingTools(Unit = Units.mm, DisplayFormat = "#0.##")]
        public double Ycoordinate { get; set; }

        /// <summary>
        /// End point Z coordinate
        /// </summary>
        [BindingTools(Unit = Units.mm, DisplayFormat = "#0.##")]
        public double Zcoordinate { get; set; }

        double _j1Pos;
        /// <summary>
        /// Joint1 position
        /// </summary>
        [BindingTools(Unit = Units.deg, DisplayFormat = "#0.##")]
        public double J1Pos
        {
            get
            {
                return _j1Pos;
            }
            set
            {
                CheckAxisLimits(value, CompNames.Joint1.ToString(), No);
                _j1Pos = value;
            }
        }

        double _j2Pos;
        /// <summary>
        /// Joint2 position
        /// </summary>
        [BindingTools(Unit = Units.deg, DisplayFormat = "#0.##")]
        public double J2Pos
        {
            get
            {
                return _j2Pos;
            }
            set
            {
                CheckAxisLimits(value, CompNames.Joint2.ToString(), No);
                _j2Pos = value;
            }
        }

        double _j3Pos;
        /// <summary>
        /// Joint3 position
        /// </summary>
        [BindingTools(Unit = Units.deg, DisplayFormat = "#0.##")]
        public double J3Pos
        {
            get
            {
                return _j3Pos;
            }
            set
            {
                CheckAxisLimits(value, CompNames.Joint3.ToString(), No);
                _j3Pos = value;
            }
        }

        double _j4Pos;
        /// <summary>
        /// Joint4 position
        /// </summary>
        [BindingTools(Unit = Units.deg, DisplayFormat = "#0.##")]
        public double J4Pos
        {
            get
            {
                return _j4Pos;
            }
            set
            {
                CheckAxisLimits(value, CompNames.Joint4.ToString(), No);
                _j4Pos = value;
            }
        }

        double _j5Pos;
        /// <summary>
        /// Joint5 position
        /// </summary>
        [BindingTools(Unit = Units.deg, DisplayFormat = "#0.##")]
        public double J5Pos
        {
            get
            {
                return _j5Pos;
            }
            set
            {
                CheckAxisLimits(value, CompNames.Joint5.ToString(), No);
                _j5Pos = value;
            }
        }

        double _j6Pos;
        /// <summary>
        /// Joint6 position
        /// </summary>
        public double J6Pos
        {
            get
            {
                return _j6Pos;
            }
            set
            {
                CheckAxisLimits(value, CompNames.Joint6.ToString(), No);
                _j6Pos = value;
            }
        }

        double _speed;
        /// <summary>
        /// Moving Speed of the robot (percentage)
        /// </summary>
        [BindingTools(Unit = Units.percent, DisplayFormat = "#0.##")]
        public double Speed
        {
            get
            {
                return _speed;
            }
            set
            {
                Validations.ValidatePercentage(value, this.No + "Speed");
                _speed = value;
            }
        }

        public WorkPoint() { }
        
        public WorkPoint(int no, double pos1, double pos2, double pos3, double pos4, double pos5, double pos6, double speed)
        {
            No = no;
            J1Pos = pos1;
            J2Pos = pos2;
            J3Pos = pos3;
            J4Pos = pos4;
            J5Pos = pos5;
            J6Pos = pos6;
            Speed = speed;
        }

        /// <summary>
        /// Check Axis safety limits before input the data to the work point
        /// </summary>
        /// <param name="val"></param>
        /// <param name="axisName"></param>
        /// <param name="No"></param>
        public void CheckAxisLimits(double val, string axisName, int No)
        {
            MKSAxis axis = null;
            try
            {
                axis = RUtils.Map.GetComponent<MKSAxis>(axisName);
            }
            catch { }
            if (axis != null)
            {
                Validations.ValidateBetweenLimits(val, axis.LowerLimit, axis.UpperLimit, axisName + " -> Point No: " + No);
            }
        }
    }
}
