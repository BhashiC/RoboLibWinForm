using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoboJarvis
{
    public enum CompNames
    {
        Jarvis, 
        Joint1, Joint2, Joint3,
        Joint4, Joint5, Joint6,
        J1Rs232, J2Rs232, J3Rs232,
        J4Rs232, J5Rs232, J6Rs232,
        PathPlan
    }

    public enum RunModes 
    {
        run1, run2, run3, run4, run5
    }

    public enum TestPos 
    {
        TestPos1, TestPos2
    }

    public enum PlugInTypes 
    {
        MKS42A57A
    }

    public enum RotateDirections
    {
        Positive, Negative
    }
}
