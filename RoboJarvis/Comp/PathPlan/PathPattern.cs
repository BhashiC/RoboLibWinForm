using RoboLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoboJarvis.Comp.PathPlan
{
    public class PathPattern : ObjBase
    {
        public List<WorkPoint> WorkPoints { get; set; }

        public PathPattern()
        {

        }

        public PathPattern(string name)
        {
            Name = name;
            WorkPoints = new List<WorkPoint>();
        }
    }
}
