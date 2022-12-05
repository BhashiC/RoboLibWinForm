using RoboJarvis.Comp.Motion;
using RoboLib.Extensions;
using RoboLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace MKS42A57A
{
    public class MKS42A57A : MKSAxis
    {
        readonly object _lockMKS = new object();

        protected override void OnAfterInitializeRecurse()
        {
            base.OnAfterInitializeRecurse();

            if (RS232.ComPorts.Any(x => x == RS232.ComPort))
            {
                RS232.Connect();
                if (RS232.Connected)
                {
                    DoSetCurrentPosition(CurrentPosition);
                    DoReadCurrentPosition();
                    DoSetAxisEnable();
                }
            }
        }

        protected override void DoMoveAbs(double position, double speed)
        {
            lock (_lockMKS)
            {
                if (UseGearBox)
                {
                    position = position * GearRation;
                }

                string cmd;
                cmd = string.Format($"{MKSCmds.MoveSpeed}{speed.UnitToExternal(Units.percent)}");
                CheckOkAndAlert(RS232.ReadPortCmd(cmd), "SetVelocity");

                cmd = string.Format($"{MKSCmds.MovePosition}{position}");
                CheckOkAndAlert(RS232.ReadPortCmd(cmd), "DoMoveAbs");

                Thread.Sleep(300);
                DoReadCurrentPosition();
            }
        }

        protected override void DoMoveRel(double distance, double speed)
        {
            lock (_lockMKS)
            {
                if (UseGearBox)
                {
                    distance = distance * GearRation;
                }

                string cmd;
                cmd = string.Format($"{MKSCmds.MoveSpeed}{speed.UnitToExternal(Units.percent)}");
                CheckOkAndAlert(RS232.ReadPortCmd(cmd), "SetVelocity");

                cmd = string.Format($"{MKSCmds.JogDistance}{distance}");
                CheckOkAndAlert(RS232.ReadPortCmd(cmd), "DoMoveRel");

                Thread.Sleep(300);
                DoReadCurrentPosition();
            }
        }

        protected override void DoSetAxisEnable()
        {
            lock (_lockMKS)
            {
                string cmd;
                cmd = string.Format($"{MKSCmds.Enable}");
                CheckOkAndAlert(RS232.ReadPortCmd(cmd), "DoSetAxisEnable");
                AxisEnabled = true;
                //MKS driver will auto set current position to Zero when we enable the motor
                //But actual hardware is not at the Zero degree position at the moment
                //To avoid this problem we manually set the current position from the software to MKS driver
                DoSetCurrentPosition(CurrentPosition);
            }
        }

        protected override void DoSetAxisDisable()
        {
            lock (_lockMKS)
            {
                string cmd;
                cmd = string.Format($"{MKSCmds.Disable}");
                CheckOkAndAlert(RS232.ReadPortCmd(cmd), "DoSetAxisDisable");
                AxisEnabled = false;
            }
        }

        protected override void DoSetMicoStep(string microStep)
        {
            lock (_lockMKS)
            {
                string cmd;
                cmd = string.Format($"{MKSCmds.SetStepSize}{microStep}");
                CheckOkAndAlert(RS232.ReadPortCmd(cmd), "DoSetMicoStep");
            }
        }

        protected override void DoSetHoldCurrent(string holdCurr)
        {
            lock (_lockMKS)
            {
                string cmd;
                cmd = string.Format($"{MKSCmds.SetHoldCurrent}{holdCurr}");
                CheckOkAndAlert(RS232.ReadPortCmd(cmd), "DoSetHoldCurrent");
            }
        }

        protected override void DoSetMotorCurrent(string motorCurr)
        {
            lock (_lockMKS)
            {
                string cmd;
                cmd = string.Format($"{MKSCmds.SetMotorCurrent}{motorCurr}");
                CheckOkAndAlert(RS232.ReadPortCmd(cmd), "DoSetMotorCurrent");
            }
        }

        protected override void DoCalibrate()
        {
            lock (_lockMKS)
            {
                string cmd;
                cmd = string.Format($"{MKSCmds.Calibrate}");
                string res = RS232.ReadPortCmd(cmd);
                CheckOkAndAlert(RS232.ReadPortCmd(cmd), "DoCalibrate");
                DoReadCurrentPosition();
            }
        }

        protected override void DoMoveHome()
        {
            var angle = HomeRotateAngle;

            lock (_lockMKS)
            {
                if (UseGearBox)
                {
                    angle = HomeRotateAngle * GearRation;
                }

                string cmd;
                cmd = string.Format($"{MKSCmds.HomeSpeed}{HomeSpeed.UnitToExternal(Units.percent)}");
                CheckOkAndAlert(RS232.ReadPortCmd(cmd), "SetVelocity");

                cmd = string.Format($"{MKSCmds.Home}{angle}");
                CheckOkAndAlert(RS232.ReadPortCmd(cmd), "DoMoveAbs");

                Thread.Sleep(300);
                DoReadCurrentPosition();
            }
        }

        protected override void DoReadCurrentPosition()
        {
            string cmd = "";
            string pos = "";

            try
            {
                cmd = string.Format($"{MKSCmds.GetCurrentPos}");
                pos = RS232.ReadPortCmd(cmd);
                if (UseGearBox)
                {
                    CurrentPosition = Convert.ToDouble(pos) / GearRation;
                }
                else
                {
                    CurrentPosition = Convert.ToDouble(pos);
                }
            }
            catch (Exception ex)
            {
                throw new RException($"{this.Name} DoReadCurrentPosition fail! Response: {pos}", ex);
            }
        }

        protected override void DoSetCurrentPosition(double position)
        {
            if (UseGearBox)
            {
                position = position * GearRation;
            }

            string cmd;
            cmd = string.Format($"{MKSCmds.SetAngle}{position}");
            string res = RS232.ReadPortCmd(cmd);
            CheckOkAndAlert(RS232.ReadPortCmd(cmd), "DoSetCurrentPosition");
            DoReadCurrentPosition();
        }

        /// <summary>
        /// Check res contains 'OK'
        /// </summary>
        /// <param name="res"></param>
        /// <param name="detail"></param>
        void CheckOkAndAlert(string res, string detail)
        {
            if (!res.Contains("OK"))
            {
                throw new RException($"{this.Name} {detail} fail, Response is: {res}");
            }
        }

        /// <summary>
        /// Command List
        /// </summary>
        internal static class MKSCmds
        {
            internal const string Calibrate = "C";
            internal const string SetZero = "Z";
            internal const string SetAngle = "p";
            internal const string GetCurrentPos = "A";
            internal const string GetMeasError = "e";

            internal const string MoveSpeed = "V";
            internal const string MovePosition = "P";
            internal const string JogDistance = "J";
            internal const string MoveMax = "M";

            internal const string SetStepSize = "T";
            internal const string SetHoldCurrent = "H";
            internal const string SetMotorCurrent = "L";

            internal const string Enable = "E1";
            internal const string Disable = "E0";
            internal const string FeedBkOn = "F1";
            internal const string FeedBkOff = "F0";
            internal const string FactoryReset = "X";

            internal const string Home = "O";
            internal const string HomeSpeed = "s";
        }
    }
}
