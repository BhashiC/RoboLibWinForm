using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoboLib
{
    /// <summary>
    /// Base Singleton class
    /// </summary>
    /// <example>
    /// Declare and singleton class:
    /// <code>
    /// class Foo : Singleton &lt;Foo&gt;
    /// {
    /// }
    /// </code>
    /// </example>
    /// <typeparam name="T"></typeparam>
    public class Singleton<T> where T : class, new()
    {
        /// <summary>
        /// Constructor
        /// </summary>
        protected Singleton()
        {
        }

        /// <summary>
        /// Instance
        /// </summary>
        public static T Instance
        {
            get
            {
                return Nested.instance;
            }
        }

        /// <summary>
        /// Use nested to make sure lazy instantiation
        /// </summary>
        class Nested
        {
            // Explicit static constructor to tell C# compiler
            // not to mark type as beforefieldinit
            static Nested()
            {
            }

            internal static readonly T instance = new T();
        }
    }
}
