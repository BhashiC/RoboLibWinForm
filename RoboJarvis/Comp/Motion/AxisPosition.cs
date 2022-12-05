using RoboLib;
using RoboLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoboJarvis.Comp.Motion
{
    public class AxisPosition : ObjBase
    {
        public Axis Axis { get; set; }

        double _position;
        /// <summary>
        /// Absolute position value
        /// </summary>
        [BindingTools(Unit = Units.deg, DisplayFormat = "#0.##")]
        public double Position 
        { 
            get
            {
                return _position;
            } 
            set
            {
                if (Axis != null)
                {
                    Validations.ValidateBetweenLimits(value, Axis.LowerLimit, Axis.UpperLimit, 
                        string.Format("{0} {1} Position", Axis.Name, Name));
                }
                _position = value;
            } 
        }

        double _speed;
        /// <summary>
        /// Travel speed to the position
        /// </summary>
        [BindingTools(Unit = Units.percent, DisplayFormat = "#0.##")]
        public double Speed 
        {
            get
            {
                return _speed;
            }
            set 
            {   if (Axis != null)
                {
                    Validations.ValidatePercentage(value, string.Format("{0} {1} Speed", Axis.Name, Name));
                }
                _speed = value;
            }
        }

        public AxisPosition() 
        {

        }

        /// <summary>
        /// Position Constructor
        /// </summary>
        /// <param name="axis"></param>
        /// <param name="name"></param>
        /// <param name="position"></param>
        /// <param name="speed"></param>
        public AxisPosition(Axis axis, string name, double position, double speed) 
        {
            Axis = axis;
            Name = name;
            Position = position;
            Speed = speed;
        }
    }
}
