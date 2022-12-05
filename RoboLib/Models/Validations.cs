using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoboLib.Models
{
    public static class Validations
    {
        /// <summary>
        /// Check is the given value is a positive number
        /// </summary>
        /// <param name="val"></param>
        /// <param name="info"></param>
        public static void ValidatePositiveNum(double val, string info) 
        {
            if (val < 0)
            {
                throw new RException(string.Format("{0} value must be Positive", info));
            }
        }
        
        /// <summary>
        /// Check is the given value is in between 0 and 1 (internal units)
        /// </summary>
        /// <param name="val"></param> value to be validate
        /// <param name="info"></param> info such as comp name and property name for ex msg
        public static void ValidatePercentage(double val, string info) 
        {
            if (val < 0 || val > 1) 
            {
                throw new RException(string.Format("{0} value must be 0 to 100", info));    
            }
        }

        /// <summary>
        /// Check is the given value is in between lowerLmt and upperLmt
        /// /// </summary>
        /// <param name="val"></param> value to be validate
        /// <param name="lowerLmt"></param> lower limit
        /// <param name="upperLmt"></param> upper limit
        /// <param name="info"></param> info such as comp name and property name for ex msg
        public static void ValidateBetweenLimits(double val, double lowerLmt, double upperLmt, string info) 
        {
            if (val < lowerLmt || val > upperLmt) 
            {
                throw new RException(string.Format("{0} value must be {1} to {2}", info, lowerLmt, upperLmt));
            }
        }
    }
}
