using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace RoboLib.Models
{
    public static class Cache
    {
        public static void LoadAssembly(Assembly assembly)
        {
            var types = assembly.GetTypes().Where(t => typeof(ObjBase).IsAssignableFrom(t)).ToList();
            if (types.Count > 0)
            {
                AddTypes(types);
            }
            DistinctByImpl(assembly.GetReferencedAssemblies().Where(x => x.FullName.Contains("RoboLib")), x => x.FullName, null).ToList()
                .ForEach(x => LoadAssembly(Assembly.Load(x)));
        }

        static Dictionary<string, Type> _typeCache = new Dictionary<string, Type>();
        public static void AddTypes(IEnumerable<Type> types)
        {
            foreach (var type in types)
            {
                _typeCache[type.Name] = type;
                _typeCache[type.FullName] = type;
            }
        }

        public static Type GetLoadedType(string typeString)
        {
            if (string.IsNullOrEmpty(typeString))
            {
                return null;
            }
            Type t;
            _typeCache.TryGetValue(typeString, out t);
             return t;
        }


        static IEnumerable<TSource> DistinctByImpl<TSource, TKey>(IEnumerable<TSource> source,
                       Func<TSource, TKey> keySelector, IEqualityComparer<TKey> comparer)
        {
            var knownKeys = new HashSet<TKey>(comparer);
            foreach (var element in source)
            {
                if (knownKeys.Add(keySelector(element)))
                {
                    yield return element;
                }
            }
        }
    }
}
