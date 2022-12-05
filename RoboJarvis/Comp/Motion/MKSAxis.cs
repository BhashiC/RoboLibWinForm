using Newtonsoft.Json;
using RoboLib;
using RoboLib.Models.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RoboJarvis.Comp.Motion
{
    public class MKSAxis : Axis
    {
        /// <summary>
        /// MKS micro step options
        /// </summary>
        [JsonIgnore]
        public List<string> MicroSteps;

        /// <summary>
        /// MKS hold current options
        /// </summary>
        [JsonIgnore]
        public List<string> HoldCurrents;

        /// <summary>
        /// MKS motor current options
        /// </summary>
        [JsonIgnore]
        public List<string> MotorCurrents;

        /// <summary>
        /// Micro Step size
        /// </summary>
        public string MicroStep { get; set; }

        /// <summary>
        /// Holding current
        /// </summary>
        [BindingTools(Unit = Units.mA)]
        public string HoldCurrent { get; set; }

        /// <summary>
        /// Motor current
        /// </summary>
        [BindingTools(Unit = Units.mA)]
        public string MotorCurrent { get; set; }

        /// <summary>
        /// Set True if motor couple with gear ratio
        /// </summary>
        public bool UseGearBox { get; set; }

        /// <summary>
        /// Gear box reduction ration
        /// </summary>
        public double GearRation { get; set; }

        /// <summary>
        /// Send angle for the home command
        /// </summary>
        [BindingTools(Unit = Units.deg, DisplayFormat = "#0.##"), ViewMode(PropertyViewModes.ReadOnly)]
        public double HomeRotateAngle
        {
            get
            {
                return HomeDirection == RotateDirections.Positive ? 360 : -360;
            }
            set { }
        }

        /// <summary>
        /// Home function rotate direction
        /// </summary>
        public RotateDirections HomeDirection { get; set; }

        /// <summary>
        /// RS232 communication mdule
        /// </summary>
        [JsonIgnore]
        public RS232 RS232
        {
            get
            {
                return this.GetFirstChild(x => x is RS232) as RS232;
            }
        }

        public MKSAxis()
        {
            MotorCurrent = "500";
            HoldCurrent = "500";
            MicroStep = "16";
        }

        protected override void OnInitializeRecurse()
        {
            base.OnInitializeRecurse();

            HoldCurrents = HoldCurrents ?? new List<string>()
            {
               "100", "200", "300", "400", "500", "600", "700", "800", "900", "1000",
               "1100", "1200", "1300", "1400", "1500", "1600", "1700", "1800", "1900", "2000",
               "2100", "2200", "2300", "2400", "2500", "2600", "2700", "2800", "2900", "3000",
               "3100", "3200", "3300"
            };
            MotorCurrents = MotorCurrents ?? new List<string>()
            {
                "100", "200", "300", "400", "500", "600", "700", "800", "900", "1000",
               "1100", "1200", "1300", "1400", "1500", "1600", "1700", "1800", "1900", "2000",
               "2100", "2200", "2300", "2400", "2500", "2600", "2700", "2800", "2900", "3000",
               "3100", "3200", "3300"
            };
            MicroSteps = MicroSteps ?? new List<string>()
            {
                "1", "2", "4", "8", "16", "32", "64", "128", "256"
            };

        }

        protected override void OnAfterInitializeRecurse()
        {
            base.OnAfterInitializeRecurse();
            InitRS232Help();
            InitGearRatio();
        }

        void InitRS232Help()
        {
            if (RS232 != null)
            {
                RS232.CommandList = new List<string>();
                RS232.CommandList.Add("C => Calibrate the motor");
                RS232.CommandList.Add("k => Get calibration error");
                RS232.CommandList.Add("e => Get measure error");
                RS232.CommandList.Add("A => Get current position");
                RS232.CommandList.Add("Z => Set current position as Zero position");
                RS232.CommandList.Add("Vxx => Set Travel speed");
                RS232.CommandList.Add("Mxx => Move to Abs angle with max speed");
                RS232.CommandList.Add("Pxx => Move to Abs angle with Travel speed");
                RS232.CommandList.Add("Jxx => Jog with Travel speed");
                RS232.CommandList.Add("E1 or E0 => Motor enable or disable");
                RS232.CommandList.Add("F1 or F0 => Feedback control On or Off");
                RS232.CommandList.Add("T => Set step size 2, 4, 8, 16.....256");
                RS232.CommandList.Add("L => Set motor current 100, 200, 300.....3300");
                RS232.CommandList.Add("H => Set hold current 100, 200, 300.....3300");
                RS232.CommandList.Add("X => Factory Resetting!, Wait 15sec Reconnect");
                RS232.CommandList.Add("s => Home movement speed");
                RS232.CommandList.Add("Oxx => Home command rotate target angle");
            }
        }

        void InitGearRatio()
        {
            string name = this.Name;

            if (name == CompNames.Joint1.ToString())
            {
                GearRation = 19.2;
            }
            else if (name == CompNames.Joint2.ToString())
            {
                GearRation = 19;
            }
            else if (name == CompNames.Joint3.ToString())
            {
                GearRation = 19;
            }
            else if (name == CompNames.Joint4.ToString())
            {
                GearRation = 20;
            }
            else if (name == CompNames.Joint5.ToString())
            {
                GearRation = 40;
            }
            else if (name == CompNames.Joint6.ToString())
            {
                GearRation = 40;
            }
        }

        /// <summary>
        /// Set Micro Steps size
        /// </summary>
        /// <param name="microStep"></param>
        public void SetMicroStep(string microStep)
        {
            try
            {
                DoSetMicoStep(microStep);
            }
            catch (Exception ex)
            {
                throw new RException(string.Format("{0} SetMicroSteps fail!", this.Name), ex);
            }
        }

        /// <summary>
        /// Set Micro Step size, Override in plugin
        /// </summary>
        /// <param name="microStep"></param>
        protected virtual void DoSetMicoStep(string microStep)
        {
            MessageBox.Show(string.Format($"{this.Name} Micro Steps Set to: {microStep}"), "Information",
               MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// Set Hold Current
        /// </summary>
        /// <param name="holdCurr"></param>
        public void SetHoldCurrent(string holdCurr)
        {
            try
            {
                DoSetHoldCurrent(holdCurr);
            }
            catch (Exception ex)
            {
                throw new RException(string.Format("{0} SetHoldCurrent fail!", this.Name), ex);
            }
        }

        /// <summary>
        /// Set Hold Current, Override in plugin
        /// </summary>
        /// <param name="holdCurr"></param>
        protected virtual void DoSetHoldCurrent(string holdCurr) 
        {
            MessageBox.Show(string.Format($"{this.Name} Hold Current set to: {holdCurr}"), "Information", 
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// Set Motor Current
        /// </summary>
        /// <param name="motorCurr"></param>
        public void SetMotorCurrent(string motorCurr) 
        {
            try
            {
                DoSetMotorCurrent(motorCurr);
            }
            catch (Exception ex)
            {
                throw new RException(string.Format("{0} SetMotorCurrent fail!", this.Name), ex);
            }
        }

        /// <summary>
        /// Set Motor Current, Override in plugin
        /// </summary>
        /// <param name="motorCurr"></param>
        protected virtual void DoSetMotorCurrent(string motorCurr) 
        {
            MessageBox.Show(string.Format($"{this.Name} Motor Current Set to: {motorCurr}"), "Information",
               MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// Calibrate motor
        /// </summary>
        public void Calibrate() 
        {
            try
            {
                DoCalibrate();
            }
            catch (Exception ex)
            {
                throw new RException(string.Format("{0} Calibrate fail!", this.Name), ex);
            }
        }

        protected virtual void DoCalibrate() 
        {
            MessageBox.Show(string.Format($"{this.Name} Motor Calibrated"), "Information",
               MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
