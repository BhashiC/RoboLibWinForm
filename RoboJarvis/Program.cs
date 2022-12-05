using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;
using RoboLib.Utils.Singletons;
using System.Configuration;
using System.IO;

namespace RoboJarvis
{
    static class Program
    {
        static Dictionary<string, Assembly> _loadAssemblies = new Dictionary<string, Assembly>();

        static Program()
        {
            AppDomain.CurrentDomain.AssemblyResolve += new ResolveEventHandler(OnAssemblyResolve);
        }

        static Assembly OnAssemblyResolve(object sender, ResolveEventArgs args)
        {
            // Ignore missing resources
            if (args.Name.Contains(".resources"))
                return null;
            
            // Check for assemblies already loaded
            Assembly assembly = AppDomain.CurrentDomain.GetAssemblies().FirstOrDefault(a => a.FullName == args.Name);
            if (assembly != null)
                return assembly;

            // Try to load by filename - split out the filename of the full assembly name
            // and append the base path of the original assembly (ie. look in the same dir)
            string filename = args.Name.Split(',')[0] + ".dll".ToLower();

            string referenceFolder = @"C:\RoboFactory\Ref";
            string asmFile = string.Format(@"{0}\{1}", referenceFolder, filename);
            try
            {
                return System.Reflection.Assembly.LoadFrom(asmFile);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            SystemUtils.Instance.InstallUnhandledExceptionHandling();
            SystemUtils.Instance.RunApplicationExclusive(new Form1());
        }
    }
}
