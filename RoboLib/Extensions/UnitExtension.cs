using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoboLib.Extensions
{
    public static class UnitExtension
    {
        /// <summary>
        /// Convert from Deg to Radian
        /// </summary>
        /// <param name="deg"></param>
        /// <returns></returns>
        public static double DegToRad(this double deg)
        {
            return (deg * Math.PI) / 180;
        }

        /// <summary>
        /// Convert from Radian to Deg
        /// </summary>
        /// <param name="rad"></param>
        /// <returns></returns>
        public static double RadToDeg(this double rad)
        {
            return (rad * 180) / Math.PI;
        }

        /// <summary>
        /// Make display label for a unit
        /// </summary>
        /// <param name="unit"></param>
        /// <returns></returns>
        public static string MakeDisplayLabel(this Units unit)
        {
            var unitString = unit.ToString().Replace('_', '/');
            unitString = unitString.Replace("percent", "%");
            return unitString;
        }

        /// <summary>
        /// Convert a value in a specific unit to internal unit
        /// RoboLib internal units: mm, mm/sec, mm/sec2, deg, deg/sec, deg/sec2, g, hz, msec
        /// </summary>
        /// <param name="val"></param>
        /// <param name="fromUnit"></param>
        /// <returns></returns>
        public static double UnitToInternal(this double val, Units fromUnit)
        {
            switch (fromUnit)
            {
                case Units.m:
                    return val * 1000;
                case Units.mm:
                    return val;
                case Units.um:
                    return val / 1000;
                case Units.m_sec:
                    return val * 1000;
                case Units.mm_sec:
                    return val;
                case Units.um_sec:
                    return val / 1000;
                case Units.m_sec2:
                    return val * 1000;
                case Units.mm_sec2:
                    return val;
                case Units.um_sec2:
                    return val / 1000;
                case Units.deg:
                    return val;
                case Units.rad:
                    return RadToDeg(val);
                case Units.deg_sec:
                    return val;
                case Units.rad_sec:
                    return RadToDeg(val);
                case Units.deg_sec2:
                    return val;
                case Units.rad_sec2:
                    return RadToDeg(val);
                case Units.g:
                    return val;
                case Units.mg:
                    return val / 1000;
                case Units.hz:
                    return val;
                case Units.Khz:
                    return val * 1000;
                case Units.Mhz:
                    return val * 1000000;
                case Units.A:
                    return val * 1000;
                case Units.mA:
                    return val;
                case Units.scale:
                    return val;
                case Units.percent:
                    return val / 100;
                case Units.year:
                    return val * 365.25 * 24 * 60 * 60.0 * 1000;
                case Units.month:
                    return val * 30 * 24 * 60 * 60.0 * 1000;
                case Units.week:
                    return val * 7 * 24 * 60 * 60.0 * 1000;
                case Units.day:
                    return val * 24 * 60 * 60.0 * 1000;
                case Units.hour:
                    return val * 60 * 60.0 * 1000;
                case Units.minute:
                    return val * 60.0 * 1000;
                case Units.sec:
                    return val * 1000;
                case Units.msec:
                    return val;
                case Units.usec:
                    return val / 1000;
                case Units.NA:
                    return val;
                default:
                    return val;
            }
        }

        /// <summary>
        /// Convert a value from internal unit to a specified unit
        /// RoboLib internal units: mm, mm/sec, mm/sec2, deg, deg/sec, deg/sec2, g, hz, msec
        /// </summary>
        /// <param name="val"></param>
        /// <param name="toUnit"></param>
        /// <returns></returns>
        public static double UnitToExternal(this double val, Units toUnit) 
        {
            switch (toUnit)
            {
                case Units.m:
                    return val / 1000;
                case Units.mm:
                    return val;
                case Units.um:
                    return val * 1000;
                case Units.m_sec:
                    return val / 1000;
                case Units.mm_sec:
                    return val;
                case Units.um_sec:
                    return val * 1000;
                case Units.m_sec2:
                    return val / 1000;
                case Units.mm_sec2:
                    return val;
                case Units.um_sec2:
                    return val * 1000;
                case Units.deg:
                    return val;
                case Units.rad:
                    return DegToRad(val);
                case Units.deg_sec:
                    return val;
                case Units.rad_sec:
                    return DegToRad(val);
                case Units.deg_sec2:
                    return val;
                case Units.rad_sec2:
                    return DegToRad(val);
                case Units.g:
                    return val;
                case Units.mg:
                    return val * 1000;
                case Units.hz:
                    return val;
                case Units.Khz:
                    return val / 1000;
                case Units.Mhz:
                    return val / 1000000;
                case Units.A:
                    return val / 1000;
                case Units.mA:
                    return val;
                case Units.scale:
                    return val;
                case Units.percent:
                    return val * 100;
                case Units.year:
                    return val / (365.25 * 24 * 60 * 60.0 * 1000);
                case Units.month:
                    return val / (30 * 24 * 60 * 60.0 * 1000);
                case Units.week:
                    return val / (7 * 24 * 60 * 60.0 * 1000);
                case Units.day:
                    return val / (24 * 60 * 60.0 * 1000);
                case Units.hour:
                    return val / (60 * 60.0 * 1000);
                case Units.minute:
                    return val / (60.0 * 1000);
                case Units.sec:
                    return val / 1000;
                case Units.msec:
                    return val;
                case Units.usec:
                    return val * 1000;
                case Units.NA:
                    return val;
                default:
                    return val;
            }
        }
    }
}
