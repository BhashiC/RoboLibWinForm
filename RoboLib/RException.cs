using RoboLib.Utils.Singletons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RoboLib
{
    public class RException : ApplicationException
    {
        /// <summary>
        /// Constructor without innner exception
        /// </summary>
        /// <param name="caption"></param>
        public RException(string caption) : this(caption, null)
        {

        }

        /// <summary>
        /// Constructor with inner exception
        /// </summary>
        /// <param name="caption"></param>
        /// <param name="innerException"></param>
        public RException(string caption, Exception innerException) : base(caption, innerException)
        {

        }

        internal RException Execute(string caption)
        {
            Swallower.Instance.ExecuteException(this, caption);
            return this;
        }

        /// <summary>
        /// Executing an exception with message
        /// </summary>
        /// <param name="ex"></param>
        /// <param name="caption"></param>
        /// <returns></returns>
        public static RException Execute(Exception ex, string caption)
        {
            if (ex == null)
            {
                return null;
            }

            // Don't take in the useless TargetInvocationException
            if ((ex is System.Reflection.TargetInvocationException) && ex.InnerException != null)
            {
                ex = ex.InnerException;
            }

            // Handling
            var rEx = ex as RException;
            if (rEx != null)
            {
                return rEx.Execute(caption);
            }
            else
            {
                // Other exception
                return (new RException(ex.GetType() + "\n" + ex.Message, ex)).Execute(caption);
            }
        }
    }
}
