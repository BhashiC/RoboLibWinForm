using RoboLib.Utils.Singletons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoboLib
{
    public static class RUtils
    {
        /// <summary>
        /// Easy access to Component Map
        /// </summary>
        public static ComponentMap Map
        {
            get
            {
                return ComponentMap.Instance;
            }
        }

        public static PropMeta Prop
        {
            get
            {
                return PropMeta.Instance;
            }
        }
    }
}
