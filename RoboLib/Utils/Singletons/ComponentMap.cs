using RoboLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoboLib.Utils.Singletons
{
    public class ComponentMap : Singleton<ComponentMap>
    {
        Dictionary<string, ComponentBase> _compMap = new Dictionary<string, ComponentBase>();

        /// <summary>
        /// Get the component by name cast it to provided type
        /// </summary>
        /// <typeparam name="T"></typeparam> Component Type
        /// <param name="compName"></param> Component Name
        /// <returns></returns>
        public T GetComponent<T>(string compName) where T : ComponentBase
        {
            return (T)_compMap[compName];
        }

        /// <summary>
        /// Add component to Map
        /// </summary>
        /// <param name="comp"></param>
        /// <returns></returns>
        public ComponentBase AddToMap(ComponentBase comp)
        {
            if (!string.IsNullOrEmpty(comp.Name))
            {
                _compMap[comp.Name] = comp;
            }
            return comp;
        }

        /// <summary>
        /// Remove component from Map
        /// </summary>
        /// <param name="comp"></param>
        /// <returns></returns>
        public ComponentBase RemoveFromMap(ComponentBase comp)
        {
            if (!string.IsNullOrEmpty(comp.Name))
            {
                _compMap.Remove(comp.Name);
            }
            return comp;
        }

    }
}
