using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoboLib.Extensions
{
    public static class EnumerableExtensions
    {
        /// <summary>
        /// Add an item to list if not exist by predicate
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="predicate"></param>
        /// <param name="createFunc"></param>
        /// <returns></returns>
        public static T AddIfNotExist<T>(this IList<T> list, Func<T, bool> predicate, Func<T> createFunc)
        {
            T item = list.FirstOrDefault(predicate);
            if (item == null) 
            {
                item = createFunc();
                list.Add(item);
            }
            return item;
        }
    }
}
