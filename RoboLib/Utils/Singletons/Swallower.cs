using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RoboLib.Utils.Singletons
{
    public class Swallower : Singleton<Swallower>
    {
        public void ExecuteException(RException ex, string caption, int swallowTimeMsec = 1000)
        {
            
            var exString = ex.ToString();
            //Remove Stack Trace and Display only the required information
            var ExMes = exString.Split(new[] { "Server stack trace" }, StringSplitOptions.RemoveEmptyEntries);
            MessageBox.Show(ExMes[0], caption);

            //MessageBox.Show(MessageWithLastTrackableCallStack(ex), caption);
        }

        /// <summary>
        /// Get the message with last trackable callstack
        /// </summary>
        /// <param name="ex"></param>
        /// <returns></returns>
        string MessageWithLastTrackableCallStack(Exception ex)
        {
            try
            {
                var stackTrace = GetUsableStackTrace(ex);
                // The trackable one is the one that ending with line xxx
                var trackableStack = stackTrace.Split(new[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries)
                    .FirstOrDefault(x => Char.IsDigit(x[x.Length - 1]));
                var split = trackableStack.Split(new[] { "(", ".cs:" }, StringSplitOptions.RemoveEmptyEntries);
                return string .Format("{0}{1} {2}",ex.Message, split.First(), split.Last());
            }
            catch
            {
                return ex.Message;
            }
        }

        /// <summary>
        /// Return the usable stack trace by tracking down InnerException if current one is null.
        /// </summary>
        /// <param name="ex"></param>
        /// <returns></returns>
        string GetUsableStackTrace(Exception ex)
        {
            var stackTrace = ex.StackTrace;
            if (string.IsNullOrEmpty(stackTrace) && ex.InnerException != null)
            {
                return GetUsableStackTrace(ex.InnerException);
            }
            else
            {
                return stackTrace;
            }
        }
    }
}
