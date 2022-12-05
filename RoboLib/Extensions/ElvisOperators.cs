using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoboLib.Extensions
{
    public static class ElvisOperators
    {
        /// <summary>
        /// Elvis: Get Property on an obj, return default value if obj is null.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TReturn"></typeparam>
        /// <param name="obj"></param>
        /// <param name="selector"></param>
        /// <returns></returns>
        public static TReturn Elvis<T, TReturn>(this T obj, Func<T, TReturn> selector) where T : class
        {
            if (obj == null)
                return default(TReturn);
            return selector(obj);
        }

        /// <summary>
        /// Elvis: Call an action on obj, do nothing if obj is null.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <param name="actionOnObj"></param>
        public static void Elvis<T>(this T obj, Action<T> actionOnObj) where T : class
        {
            if (obj != null)
                actionOnObj(obj);
        }
    }
}
