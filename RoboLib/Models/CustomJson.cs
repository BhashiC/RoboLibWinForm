using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using RoboLib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace RoboLib.Models
{
    /// <summary>
    /// Class for helping deserialize component structure (heterogenous), also support ObjBase
    /// </summary>
    public class ComponentConverter : Newtonsoft.Json.Converters.CustomCreationConverter<ObjBase>
    {
        public override ObjBase Create(Type objectType)
        {
            throw new NotImplementedException();
        }

        public ObjBase Create(Type objectType, JObject jObject)
        {
            string typeString = (string)jObject.Property("PlugInType");
            Type t = null;
            if (typeString != null)
            {
                t = typeString.Elvis(s => s.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries).Select(x => x.Trim()))
                            .Select(x => Cache.GetLoadedType(x)).FirstOrDefault(x => x != null);
            }
            if (t == null)
            {
                typeString = (string)jObject.Property("ThisType");
                t = Cache.GetLoadedType(typeString);
            }
            if (t == null)
            {
                typeString = (string)jObject.Property("GenericType");
                t = Cache.GetLoadedType(typeString);
            }
            if (t == null)
            {
                if (typeof(ComponentBase).IsAssignableFrom(objectType))
                {
                    t = typeof(ComponentBase); // Final fallback to avoid throw when developer remove class
                }
                else
                {
                    t = typeof(ObjBase); // Final fallback to avoid throw when developer remove class
                }
            }
            return (ObjBase)Activator.CreateInstance(t);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JObject jObject = JObject.Load(reader);
            ObjBase target = null;
            if (jObject != null)
            {
                if (jObject["$ref"] != null)
                {
                    // Handling reference: when using PreserveReferencesHandling.Objects 
                    string id = (jObject["$ref"] as JValue).Value as string;
                    target = serializer.ReferenceResolver.ResolveReference(serializer, id) as ObjBase;
                }
                else
                {
                    target = Create(objectType, jObject);
                    serializer.Populate(jObject.CreateReader(), target);
                }
            }
            return target;
        }
    }

    public class CustomStringEnumConverter : StringEnumConverter
    {
        public CustomStringEnumConverter()
            : base()
        {
            AllowIntegerValues = true;
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            try
            {
                return base.ReadJson(reader, objectType, existingValue, serializer);
            }
            catch
            {
                return default(int);
            }
        }
    }

    /// <summary>
    /// Class for helping order base class first in serialization
    /// </summary>
    public class DefaultPropertyOrderContractResolver : DefaultContractResolver
    {
        // From http://stackoverflow.com/questions/32571695/order-of-fields-when-serializing-the-derived-class-in-json-net
        // As of 7.0.1, Json.NET suggests using a static instance for "stateless" contract resolvers, for performance reasons.
        // http://www.newtonsoft.com/json/help/html/ContractResolver.htm
        // http://www.newtonsoft.com/json/help/html/M_Newtonsoft_Json_Serialization_DefaultContractResolver__ctor_1.htm

        protected override IList<JsonProperty> CreateProperties(Type type, MemberSerialization memberSerialization)
        {
            var properties = base.CreateProperties(type, memberSerialization);
            if (properties != null)
            {
                var list = properties.OrderBy(p => IsReferenceType(p.PropertyType)).ThenByDescending(p => p.Order).ToList();
                return list;
            }
            return properties;
        }

        /// <summary>
        /// Check given type is a reference type or not, string is not considered reference type
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public static bool IsReferenceType(Type t)
        {
            return !t.IsValueType && t != typeof(string);
        }
    }

    public static class CustomJsonSettings
    {
        public static List<JsonConverter> DefaultConverters() { return _defaultConverters; }

        static List<JsonConverter> _defaultConverters = new List<JsonConverter>() { new ComponentConverter(), new CustomStringEnumConverter() };

        static JsonSerializerSettings _mLibDefault = new JsonSerializerSettings()
        {
            ContractResolver = new DefaultPropertyOrderContractResolver(),
            Converters = _defaultConverters,
            ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            PreserveReferencesHandling = PreserveReferencesHandling.Objects,
            NullValueHandling = NullValueHandling.Ignore,
            Formatting = Formatting.Indented,
            Error = HandleDeserializationError
        };

        static void HandleDeserializationError(object sender, ErrorEventArgs errorArgs)
        {
            var ex = errorArgs.ErrorContext.Error;
            //StatusMessage.New(Utils.Severities.Warning).Show(U.MessageComp, MException.Execute(ex).Message);
            errorArgs.ErrorContext.Handled = true;
        }

        /// <summary>
        /// The Default JsonSerializerSettings. Apply for Machine Serialization/Deserialization.
        /// </summary>
        public static JsonSerializerSettings MLibDefault
        {
            get { return _mLibDefault; }
        }
    }
}
