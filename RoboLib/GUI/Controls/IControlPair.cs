using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RoboLib.GUI.Controls
{
    public interface IControlPair
    {
        Control LabelControl { get; }
        Control ValueControl { get; }
        string LabelText { get; set; }
        string ValueText { get; set; }
    }
}
