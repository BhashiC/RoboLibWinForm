using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RoboLib.Utils.Singletons
{
    public class SystemUtils : Singleton<SystemUtils>
    {
        /// <summary>
        /// Install unhandled exception handling, both GUI and non GUI
        /// </summary>
        public void InstallUnhandledExceptionHandling()
        {
            // Handling UI thread unhandle exceptions.
            Application.ThreadException += (s, e) =>
            {
                RException.Execute(e.Exception, string.Format("{0} Error!", (Assembly.GetEntryAssembly() ?? Assembly.GetExecutingAssembly()).GetName().Name));
            };
            // Set the unhandled exception mode to force all Windows Forms errors to go through
            // our handler.
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            // Add the event handler for handling non-UI thread exceptions to the event. 
            AppDomain.CurrentDomain.UnhandledException += (s, e) =>
            {
                // Unhandled Exception has occured in a non-GUI thread
                // We have no way to prevent the application from termination.
                // So instead of keep silence and log, we inform user that we are closing.
                new RException(string.Format("A FATAL error has occured! {0} need to be closed.", (Assembly.GetEntryAssembly() ?? Assembly.GetExecutingAssembly()).GetName().Name)
                    , e.ExceptionObject as Exception).Execute("We are closing");
            };
        }

        /// <summary>
        /// Use this to run application exclusively
        /// </summary>
        /// <param name="newForm"></param>
        public void RunApplicationExclusive(Form newForm)
        {
            string appName = (Assembly.GetEntryAssembly() ?? Assembly.GetExecutingAssembly()).GetName().Name;
            bool ok;
            System.Threading.Mutex m = new System.Threading.Mutex(true, appName, out ok);

            if (!ok)
            {
                MessageBox.Show(string.Format("Another {0} is running!", appName), "Stop", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            try
            {
                Application.Run(newForm);
            }
            finally
            {
                m.ReleaseMutex();
            }
        }
    }
}
