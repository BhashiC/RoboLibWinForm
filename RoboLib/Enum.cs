using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoboLib
{
    /// <summary>
    /// Display Units, RoboLib internal units: mm, mm/sec, deg, deg/sec, g, hz, msec
    /// </summary>
    public enum Units 
    {
        // Linear Distance
        m, mm, um,
        // Linear Speed
        m_sec, mm_sec, um_sec,
        // Linear Acceleration
        m_sec2, mm_sec2, um_sec2,
        // Angular Distance
        deg, rad,
        // Angular Speed
        deg_sec, rad_sec,
        // Angular Acceleration
        deg_sec2, rad_sec2,
        // Weight
        g, mg,
        // Frequency
        hz, Khz, Mhz,
        // Current
        A, mA,
        // Scale
        scale, percent,
        // Time
        year, month, week, day, hour, minute, sec, msec, usec,
        // Not specified
        NA,
        // those marked with NoUnit unit will never get the unit conversion when formatting and parsing
        NoUnit
    }

    /// <summary>
    /// Newlines enum
    /// </summary>
    public enum NewLines
    {
        /// <summary>
        /// \r - Carriage Return
        /// </summary>
        CR, 
        /// <summary>
        /// \n - Line Feed
        /// </summary>
        LF,
        /// <summary>
        /// \r\n - Carriage Return and Line Feed
        /// </summary>
        CRLF
    };

    /// <summary>
    /// Common binding type
    /// </summary>
    public enum BindingType
    {
        /// <summary>
        /// String
        /// </summary>
        StringBinding,
        /// <summary>
        /// Number (double or int or long)
        /// </summary>
        NumberBinding,
        /// <summary>
        /// boolean
        /// </summary>
        BooleanBinding,
        /// <summary>
        /// Enum
        /// </summary>
        EnumBinding,
        /// <summary>
        /// Other Value types that not previous ones
        /// </summary>
        OtherValueBinding,
        /// <summary>
        /// object
        /// </summary>
        ObjectBinding,
        /// <summary>
        /// Not applicable
        /// </summary>
        NA
    }

    /// <summary>
    /// Property view mode in the Components page.
    /// </summary>
    public enum PropertyViewModes
    {
        Setting,
        ReadOnly,
        NotShown
    }
}
