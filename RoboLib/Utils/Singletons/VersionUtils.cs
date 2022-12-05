using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace RoboLib.Utils.Singletons
{
    public class VersionUtils : Singleton<VersionUtils>
    {
        /// <summary>
        /// Get the assembly .exe name
        /// </summary>
        /// <param name="assy"></param>
        /// <returns></returns>
        public string GetAssemblyName(Assembly assy)
        {
            return Path.GetFileNameWithoutExtension(assy.ManifestModule.Name);
        }

        /// <summary>
        /// Get the assembly version
        /// </summary>
        /// <param name="assy"></param>
        public string GetAssemblyVersion(Assembly assy)
        {
            object[] attrs = assy.GetCustomAttributes(typeof(AssemblyFileVersionAttribute), true);
            string version = "Version Unknown!";
            if (attrs != null && attrs.Length > 0)
            {
                version = ((AssemblyFileVersionAttribute)attrs[0]).Version;
            }
            string[] split = version.Split('.');
            if (split.Length == 3)
            {
                // Official
                version = string.Format("{0}.{1}.{2} Official", split[0], split[1], split[2]);
            }
            else if (split.Length == 4)
            {
                version = string.Format("{0}.{1}.{2} RC{3}", split[0], split[1], split[2], split[3]);
            }
            return version;
        }
    }
}
