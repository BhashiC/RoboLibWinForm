using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoboLib
{
    /// <summary>
    /// ObjBase property mark with this to ignore in some logics
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public sealed class CrossReference : Attribute
    {
    }

    /// <summary>
    /// To display a ViewPage as the selected page on a selected component in the tree
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public sealed class ActivePage : Attribute
    {
    }

    /// <summary>
    /// Attributes which can help to improve gui bindings (decode in side Binding Manager)
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public sealed class BindingTools : Attribute
    {
        /// <summary>
        /// Display Units
        /// </summary>
        public Units Unit { get; set; }

        /// <summary>
        /// Display format string
        /// </summary>
        public string DisplayFormat { get; set; }

        /// <summary>
        /// Constructor to set Units and DisplayFormat
        /// </summary>
        /// <param name="unit"></param>
        /// <param name="displayFormat"></param>
        public BindingTools(Units unit, string displayFormat)
        {
            Unit = unit;
            DisplayFormat = displayFormat;
        }

        /// <summary>
        /// Default Constructor
        /// </summary>
        public BindingTools() : this(Units.NA, null)
        {
        }
    }

    /// <summary>
    /// Attribute to mark a string property to be selected from a list in general setting pages
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public sealed class SelectFrom : Attribute
    {
        /// <summary>
        /// List of strings for data source binding
        /// </summary>
        public List<string> DataSourceList { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="listPropertyName"></param>
        public SelectFrom(List<string> dataSourceList)
        {
            DataSourceList = new List<string>();
            DataSourceList = dataSourceList;
        }
    }


    /// <summary>
    /// Attribute to mark a property display behavior in components page
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public sealed class ViewMode : Attribute
    {
        /// <summary>
        /// Propety View mode in the component page
        /// </summary>
        public PropertyViewModes PropertyViewMode { get; set; }

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="guiType"></param>
        public ViewMode(PropertyViewModes mode)
        {
            PropertyViewMode = mode;
        }

    }
}
