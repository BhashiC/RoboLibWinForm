using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoboLib.Models
{
    public class PropertyPageViewModel
    {
        /// <summary>
        /// Title of the page (the tab name)
        /// </summary>
        public string PageTitle { get; set; }
        /// <summary>
        /// Type of the page, it should be a type derived from ViewPage
        /// </summary>
        public Type PageType { get; set; }
        /// <summary>
        /// Object to be bound, often it is the component, but sometimes we can add custom object
        /// </summary>
        public ObjBase Obj { get; set; }
    }
}
