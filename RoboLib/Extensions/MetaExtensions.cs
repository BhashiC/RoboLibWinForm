using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace RoboLib.Extensions
{
    public static class MetaExtensions
    {
        /// <summary>
        /// Get Attribute marked on a PropertyInfo or MethodInfo, null if not found
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="mInfo"></param>
        /// <returns></returns>
        public static T GetAttribute<T>(this MemberInfo mInfo) where T : Attribute
        {
            var attrs = mInfo.GetCustomAttributes(typeof(T), true);
            if (attrs.Length > 0)
            {
                return (T)attrs[0];
            }
            return null;
        }
    }
}
