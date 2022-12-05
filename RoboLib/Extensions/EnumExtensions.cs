using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoboLib.Extensions
{
    public static class EnumExtensions
    {
        /// <summary>
        /// From NewLines enum to string
        /// </summary>
        /// <param name="newLine"></param>
        /// <returns></returns>
        public static string AsString(this NewLines newLine)
        {
            switch (newLine)
            {
                case NewLines.CR:
                    return "\r";
                case NewLines.LF:
                    return "\n";
                case NewLines.CRLF:
                default:
                    return "\r\n";
            }
        }
    }
}
