using RoboJarvis.Comp.Motion.Pages;
using RoboLib;
using RoboLib.Extensions;
using RoboLib.Models;
using RoboLib.Models.Communication.Pages;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Windows.Forms;
using RoboLib.Models.Communication;

namespace RoboJarvis.Comp.Motion
{
    public class Axis : ComponentBase
    {
        /// <summary>
        /// True when axis is moving
        /// </summary>
        [JsonIgnore,ViewMode(PropertyViewModes.ReadOnly)]
        public bool IsMoving { get; set; }

        /// <summary>
        /// True when axis is enabled
        /// </summary>
        [JsonIgnore, ViewMode(PropertyViewModes.ReadOnly)]
        public bool AxisEnabled { get; set; }

        /// <summary>
        /// Current position of the axis
        /// </summary>
        [BindingTools(Unit = Units.deg, DisplayFormat = "#0.##"), ViewMode(PropertyViewModes.ReadOnly)]
        public double CurrentPosition { get; set; }

        double _homePosition;
        /// <summary>
        /// Home position of the axis
        /// </summary>
        [BindingTools(Unit = Units.deg, DisplayFormat = "#0.##")]
        public double HomePosition
        {
            get
            {
                return _homePosition;
            }
            set
            {
                Validations.ValidateBetweenLimits(value, LowerLimit, UpperLimit, this.Name + " HomePosition");
                _homePosition = value;
            }
        }

        double _homeSpeed;
        /// <summary>
        /// Home speed of the axis
        /// </summary>
        [BindingTools(Unit = Units.percent, DisplayFormat = "#0.##")]
        public double HomeSpeed
        {
            get
            {
                return _homeSpeed;
            }
            set
            {
                Validations.ValidatePercentage(value, this.Name + " HomSpeed");
                _homeSpeed = value;
            }
        }

        double _jogDistance;
        /// <summary>
        /// Jog distance
        /// </summary>
        [BindingTools(Unit = Units.deg, DisplayFormat = "#0.##")]
        public double JogDistance
        {
            get
            {
                return _jogDistance;
            }
            set
            {
                Validations.ValidatePositiveNum(value, this.Name + " JogDistance");
                _jogDistance = value;
            }
        }

        double _jogSpeed;
        [BindingTools(Unit = Units.percent, DisplayFormat = "#0.##")]
        public double JogSpeed
        {
            get
            {
                return _jogSpeed;
            }
            set
            {
                Validations.ValidatePercentage(value, this.Name + " JogSpeed");
                _jogSpeed = value;
            }
        }

        /// <summary>
        /// Lower limit of the axis
        /// </summary>
        [BindingTools(Unit = Units.deg, DisplayFormat = "#0.##")]
        public double LowerLimit { get; set; }

        /// <summary>
        /// Upper limit of the axis
        /// </summary>
        [BindingTools(Unit = Units.deg, DisplayFormat = "#0.##")]
        public double UpperLimit { get; set; }

        public List<AxisPosition> Positions { set; get; }

        /// <summary>
        /// Home time out
        /// </summary>
        [BindingTools(Unit = Units.msec)]
        public double HomeTimeout { get; set; }

        /// <summary>
        /// Move time out
        /// </summary>
        [BindingTools(Unit = Units.msec)]
        public double MoveTimeout { get; set; }

        public Axis()
        {
            HomePosition = 0;
            HomeSpeed = 0.1;
            JogDistance = 1;
            JogSpeed = 0.1;
            Positions = new List<AxisPosition>();
        }

        protected override void DefinePages(Dictionary<string, Type> pageTypes)
        {
            base.DefinePages(pageTypes);
            pageTypes.Add("Motion", typeof(MKSAxisPage));
        }

        protected override void OnInitializeRecurse()
        {
            base.OnInitializeRecurse();
            SetTestPositions();
        }

        /// <summary>
        /// Set Axis lower and upper limits
        /// </summary>
        internal void SetDefaultLimits()
        {
            string name = this.Name;

            if (name == CompNames.Joint1.ToString())
            {
                LowerLimit = -170;
                UpperLimit = 170;
            }
            else if (name == CompNames.Joint2.ToString())
            {
                LowerLimit = -65;
                UpperLimit = 85;
            }
            else if (name == CompNames.Joint3.ToString())
            {
                LowerLimit = -90;
                UpperLimit = 30;
            }
            else if (name == CompNames.Joint4.ToString())
            {
                LowerLimit = -90;
                UpperLimit = 90;
            }
            else if (name == CompNames.Joint5.ToString())
            {
                LowerLimit = -90;
                UpperLimit = 90;
            }
            else if (name == CompNames.Joint6.ToString())
            {
                LowerLimit = -170;
                UpperLimit = 170;
            }
        }

        /// <summary>
        /// Set default test positions and speeds
        /// </summary>
        internal void SetTestPositions()
        {
            string name = this.Name;
            string pos1 = TestPos.TestPos1.ToString();
            string pos2 = TestPos.TestPos2.ToString();

            if (name == CompNames.Joint1.ToString())
            {
                Positions.AddIfNotExist((p) => p.Name.Equals(pos1), () => new AxisPosition(this, pos1, 10, 0.1));
                Positions.AddIfNotExist((p) => p.Name.Equals(pos2), () => new AxisPosition(this, pos2, 20, 0.1));
            }
            else if (name == CompNames.Joint2.ToString())
            {
                Positions.AddIfNotExist((p) => p.Name.Equals(pos1), () => new AxisPosition(this, pos1, 10, 0.2));
                Positions.AddIfNotExist((p) => p.Name.Equals(pos2), () => new AxisPosition(this, pos2, 20, 0.2));
            }
            else if (name == CompNames.Joint3.ToString())
            {
                Positions.AddIfNotExist((p) => p.Name.Equals(pos1), () => new AxisPosition(this, pos1, 10, 0.3));
                Positions.AddIfNotExist((p) => p.Name.Equals(pos2), () => new AxisPosition(this, pos2, 20, 0.3));
            }
            else if (name == CompNames.Joint4.ToString())
            {
                Positions.AddIfNotExist((p) => p.Name.Equals(pos1), () => new AxisPosition(this, pos1, 10, 0.4));
                Positions.AddIfNotExist((p) => p.Name.Equals(pos2), () => new AxisPosition(this, pos2, 20, 0.4));
            }
            else if (name == CompNames.Joint5.ToString())
            {
                Positions.AddIfNotExist((p) => p.Name.Equals(pos1), () => new AxisPosition(this, pos1, 10, 0.5));
                Positions.AddIfNotExist((p) => p.Name.Equals(pos2), () => new AxisPosition(this, pos2, 20, 0.5));
            }
            else if (name == CompNames.Joint6.ToString())
            {
                Positions.AddIfNotExist((p) => p.Name.Equals(pos1), () => new AxisPosition(this, pos1, 10, 0.6));
                Positions.AddIfNotExist((p) => p.Name.Equals(pos2), () => new AxisPosition(this, pos2, 20, 0.6));
            }
        }

        /// <summary>
        /// Enable an axis
        /// </summary>
        public void SetAxisEnable()
        {
            try
            {
                DoSetAxisEnable();
            }
            catch (Exception ex)
            {
                throw new RException(string.Format("{0} SetAxisEnable fail!", this.Name), ex);
            }
        }

        /// <summary>
        /// Set enabled an axis. Override in plugin
        /// </summary>
        protected virtual void DoSetAxisEnable()
        {
            AxisEnabled = true;
        }

        /// <summary>
        /// Disabled an axis
        /// </summary>
        public void SetAxisDisable()
        {
            try
            {
                DoSetAxisDisable();
            }
            catch (Exception ex)
            {
                throw new RException(string.Format("{0} SetAxisDisable fail!", this.Name), ex);
            }
        }

        /// <summary>
        /// Set disabled an axis. Override in plugin
        /// </summary>
        protected virtual void DoSetAxisDisable()
        {
            AxisEnabled = false;
        }

        /// <summary>
        /// Move Home axis
        /// </summary>
        public void MoveHome()
        {
            if (HomeSpeed == 0)
            {
                MessageBox.Show("Home Speed is 0, Please set Home Speed!", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                IsMoving = true;
                DoMoveHome();
            }
            catch (Exception ex)
            {
                throw new RException(string.Format("{0} MoveHome fail!", this.Name), ex);
            }
            finally
            {
                IsMoving = false;
            }
        }

        /// <summary>
        /// Move Home axis, Override in plugin
        /// </summary>
        protected virtual void DoMoveHome()
        {
            Thread.Sleep(20);
            SetCurrentPosition(HomePosition);
        }

        /// <summary>
        /// Move Absolute axis
        /// </summary>
        public void MoveAbs(double position, double speed)
        {
            if (speed == 0)
            {
                MessageBox.Show("Travel Speed is 0, Please set the Speed!", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                if (!IsSafeToMove(position))
                {
                    return;
                }
                IsMoving = true;
                DoMoveAbs(position, speed);
            }
            catch (Exception ex)
            {
                throw new RException($"{this.Name} MoveAbs fail!", ex);
            }

            finally
            {
                IsMoving = false;
            }
        }

        /// <summary>
        /// Move Absolute axis, Override in plugin
        /// </summary>
        /// <param name="speed"></param>
        protected virtual void DoMoveAbs(double position, double speed)
        {
            speed = speed * 200; // Maximum speed 200mms-1 for simulation

            var sBase = CurrentPosition;
            var t = 1000 * Math.Abs(position - sBase) / speed; // time in msec
            if (position < CurrentPosition)
            {
                speed *= -1;
            }
            Stopwatch sw = Stopwatch.StartNew();
            while (sw.ElapsedMilliseconds < t)
            {
                SetCurrentPosition(sBase + speed * sw.ElapsedMilliseconds / 1000);
                Thread.Sleep(10);
            }
            sw.Stop();
            SetCurrentPosition(position);
        }

        /// <summary>
        /// Move Relative axis
        /// </summary>
        /// <param name="pos"></param>
        /// <param name="speed"></param>
        public void MoveRel(double distance, double speed)
        {
            if (speed == 0)
            {
                MessageBox.Show("Jog Speed is 0, Please set Jog Speed!", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                double finalPos = CurrentPosition + distance;
                if (!IsSafeToMove(finalPos))
                {
                    return;
                }
                IsMoving = true;
                DoMoveRel(distance, speed);
            }
            catch (Exception ex)
            {
                throw new RException($"{this.Name} MoveRel fail!", ex);
            }
            finally
            {
                IsMoving = false;
            }
        }

        /// <summary>
        /// Move Relative axis, Override in plugin
        /// </summary>
        /// <param name="distance"></param>
        /// <param name="speed"></param>
        protected virtual void DoMoveRel(double distance, double speed)
        {
            speed = speed * 200; // Maximum speed 200mms-1 for simulation

            double setPos = CurrentPosition + distance;
            var sBase = CurrentPosition;
            var t = 1000 * Math.Abs(distance) / speed; //time in msec
            if (distance < 0)
            {
                speed *= -1;
            }
            Stopwatch sw = Stopwatch.StartNew();
            while (sw.ElapsedMilliseconds < t)
            {
                SetCurrentPosition(sBase + speed * sw.ElapsedMilliseconds / 1000);
                Thread.Sleep(10);
            }
            sw.Stop();
            SetCurrentPosition(setPos);
        }

        /// <summary>
        /// Reads current position of the axis
        /// </summary>
        void ReadCurrentPosition()
        {
            try
            {
                DoReadCurrentPosition();
            }
            catch (Exception ex)
            {
                throw new RException($"{this.Name} ReadCurrentPosition fail!", ex);
            }
        }

        /// <summary>
        /// Reads current position of the axis, Override in plugin
        /// </summary>
        protected virtual void DoReadCurrentPosition()
        {

        }

        /// <summary>
        /// Set current position of the axis
        /// </summary>
        void SetCurrentPosition(double position)
        {
            try
            {
                DoSetCurrentPosition(position);
            }
            catch (Exception ex)
            {
                throw new RException($"{this.Name} SetCurrentPosition fail!", ex);
            }
        }

        /// <summary>
        /// Set current position of the axis, Override in plugin
        /// </summary>
        protected virtual void DoSetCurrentPosition(double position)
        {
            CurrentPosition = position;
        }

        public void JogPlus()
        {
            MoveRel(JogDistance, JogSpeed);
        }

        public void JogMinus()
        {
            MoveRel(-JogDistance, JogSpeed);
        }

        bool IsSafeToMove(double finalPos) 
        {
            if (finalPos < LowerLimit || finalPos > UpperLimit)
            {
                string msg = string.Format("{0} Cannot move to position: {1}" +
                                           "\n Safety Lower Limit: {2}" +
                                           "\n Safety Upper Limit: {3}",
                                           this.Name, finalPos, LowerLimit, UpperLimit);

                MessageBox.Show(msg, "Safety Limits Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else 
            {
                return true;
            }
        }
    }
}
