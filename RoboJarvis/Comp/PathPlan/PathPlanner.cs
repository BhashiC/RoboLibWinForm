using RoboJarvis.Comp.PathPlan.Pages;
using RoboLib;
using RoboLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoboJarvis.Comp.PathPlan
{
    public class PathPlanner : ComponentBase
    {
        /// <summary>
        /// List of Path patterns
        /// </summary>
        public List<PathPattern> PathPatterns { get; set; }


        /// <summary>
        /// Path pattern names
        /// </summary>
        public List<string> PathPatternNames
        {
            get
            {
                var names = PathPatterns.Select(x => x.Name).ToList<string>();
                return names;
            }
        }

        /// <summary>
        /// Working path pattern
        /// </summary>
        public PathPattern WorkingPathPattern { get; set; }

        /// <summary>
        /// Working path pattern name
        /// </summary>
        [ViewMode(PropertyViewModes.ReadOnly)]
        public string WorkingPathPatternName { get; set; }

        /// <summary>
        /// Working path pattern's executing point number
        /// </summary>
        [ViewMode(PropertyViewModes.ReadOnly)]
        public int WorkingPathPatternPointNo { get; set; }

        public PathPlanner()
        {
            PathPatterns = new List<PathPattern>();
        }

        protected override void DefinePages(Dictionary<string, Type> pageTypes)
        {
            base.DefinePages(pageTypes);
            pageTypes.Add("Path Planner", typeof(PathPlanPage));
        }
    }
}
