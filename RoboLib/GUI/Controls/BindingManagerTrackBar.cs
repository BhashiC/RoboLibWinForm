using RoboLib.Extensions;
using RoboLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RoboLib.GUI.Controls
{
    public class BindingManagerTrackBar : BindingManager
    {
        public BindingManagerTrackBar() { }
        CustomBinding _binding;
        protected override void OnBindToProperty()
        {
            base.OnBindToProperty();
            _binding = new CustomBinding("Text", _boundObj, _pInfo.Name);
            _binding.Format += new ConvertEventHandler(_binding_Format);
            _binding.Parse += new ConvertEventHandler(_binding_Parse);
            BoundControl.DataBindings.Add(_binding);
            BoundControl.TextChanged += (s, e) => ForceValidate();
            _binding.EnableBindingComplete(() => NotifyChanges());
        }

        bool FirstTimeOnly = true;
        protected override void OnPropertyChanged(object newVal)
        {
            var rtrbarContainer = BoundControl.GetParentControlOfType<RTrackBar>();
            if (rtrbarContainer != null && FirstTimeOnly)
            {
                rtrbarContainer.UpdateTrackBarValue();
                FirstTimeOnly = false;
            }
        }

        void _binding_Parse(object sender, ConvertEventArgs e)
        {
            e.Value = ParseValue(e.Value.ToString());
        }

        object ParseValue(string val)
        {
            var unit = BindingTool.Unit;
            if (unit != Units.NA)
            {
                double num = 0.00;
                double.TryParse(val, out num);
                return Convert.ChangeType(num.UnitToInternal(unit), _pInfo.PropertyType);
            }
            return Convert.ChangeType(val, _pInfo.PropertyType, System.Globalization.CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Event indicates that the textbox is updating from data source. Take this chance to customize the textbox
        /// such as BackColor. 
        /// </summary>
        /// <remarks>There is a better way to customize textbox backcolor, that is pass in a validation</remarks>
        public event Action<Control, ObjBase> evTextboxUpdating;

        void _binding_Format(object sender, ConvertEventArgs e)
        {
            if (e.Value == null)
            {
                return;
            }
            if (evTextboxUpdating != null && sender is Binding)
            {
                evTextboxUpdating(BoundControl, (sender as Binding).BindingManagerBase.Current as ObjBase);
            }

            //if (_validation != null)
            //{
            //    var color = _validation.GetValidationColor(e.Value);
            //    if (_changeForeGroundOnValidation)
            //        SetForeColor(color);
            //    else
            //        SetBackColor(color);
            //}
            e.Value = MakeDisplayString(e.Value);
        }

        protected override void OnDisposing()
        {
            base.OnDisposing();
            BoundControl.TextChanged -= (s, e) => ForceValidate();
            if (_binding != null)
            {
                _binding.Format -= new ConvertEventHandler(_binding_Format);
                _binding.Parse -= new ConvertEventHandler(_binding_Parse);
                _binding.Dispose();
            }          
        }
    }
}
