using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoboLib.GUI.Controls
{
    public class BindingManagerCheckBox : BindingManager
    {
        CustomBinding _binding;
        protected override void OnBindToProperty()
        {
            base.OnBindToProperty();
            _binding = new CustomBinding("Checked", _boundObj, _pInfo.Name);
            BoundControl.DataBindings.Add(_binding);
            BoundControl.MouseUp += (s, e) => ForceValidate();
            _binding.EnableBindingComplete(() => NotifyChanges());
        }

        protected override void OnPropertyChanged(object newVal)
        {
            base.OnPropertyChanged(newVal);
            bool isChecked = (bool)newVal;
            BoundControl.BackColor = isChecked ? Color.LimeGreen : Color.LightCoral;
        }

        protected override void OnDisposing()
        {
            base.OnDisposing();
            BoundControl.MouseUp -= (s, e) => ForceValidate();
            if (_binding != null)
            {
                _binding.Dispose();
            }
        }
    }
}
