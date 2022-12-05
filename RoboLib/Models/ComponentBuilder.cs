using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoboLib.Models
{
    public class ComponentBuilder
    {
        ComponentBase _parent;
        string _name;
        Type _tGeneric;
        string _pluginType = "NA";

        public static ComponentBuilder DefineComponent(ComponentBase parent, string name, Type tGeneric)
        {
            return new ComponentBuilder() { _parent = parent, _name = name, _tGeneric = tGeneric };
        }

        Action<ComponentBase> _firstTimeInit;
        /// <summary>
        /// Specify the First Time Init
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="firstTimeInit"></param>
        /// <returns></returns>
        public ComponentBuilder WithFirstTimeInit<T>(Action<T> firstTimeInit) where T : ComponentBase 
        {
            _firstTimeInit = delegate (ComponentBase c) 
            { 
                firstTimeInit((T)c); 
            };
            return this;
        }

        /// <summary>
        /// Specify component plugin type
        /// </summary>
        /// <param name="pluginType"></param>
        /// <returns></returns>
        public ComponentBuilder WithPluginType(string pluginType)
        {
            _pluginType = pluginType;
            return this;
        }

        public T Build<T>() where T : ComponentBase
        {
            return (T) ComponentBase.CreateComponent(_parent, _name, _tGeneric, _pluginType, _firstTimeInit);
        }
    }
}
