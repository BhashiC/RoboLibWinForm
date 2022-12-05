using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace RoboLib.Utils.Singletons
{
    public class PropMeta : Singleton<PropMeta>
    {
        public BindingType GetBindingType(Type t)
        {
            if (t == typeof(string))
            {
                return BindingType.StringBinding;
            }
            else if (t == typeof(double) || t == typeof(int) || t == typeof(long))
            {
                return BindingType.NumberBinding;
            }
            else if (t == typeof(bool))
            {
                return BindingType.BooleanBinding;
            }
            else if (t.IsEnum)
            {
                return BindingType.EnumBinding;
            }
            else if (t.IsValueType)
            {
                return BindingType.OtherValueBinding;
            }
            else
            {
                return BindingType.NA;
            }
        }

        /// <summary>
        /// Check whether this property provides simple binding
        /// </summary>
        /// <param name="property"></param>
        /// <returns></returns>
        public bool IsSimpleBinding(PropertyInfo property)
        {
            BindingType bindingType = GetBindingType(property.PropertyType);
            return bindingType < BindingType.ObjectBinding;
        }

        /// <summary>
        /// Check whether this property is marked with a specified View Mode type
        /// </summary>
        /// <param name="pInfo"></param>
        /// <param name="mode"></param>
        /// <returns></returns>
        public bool IsPropertyViewMode(PropertyInfo pInfo, PropertyViewModes mode)
        {
            var attr = pInfo.GetCustomAttribute(typeof(ViewMode));
            if (attr == null)
            {
                return false;
            }
            return (attr as ViewMode).PropertyViewMode == mode;
        }
    }
}
