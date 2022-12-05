using Newtonsoft.Json;
using Robo3DWpf;
using RoboLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoboJarvis
{
    public class JarvisRobot : Robot
    {
        [JsonIgnore]
        public Robo3DUserControl RoboModelWpfControl { get; set; }

        public JarvisRobot() { }
    }
}
