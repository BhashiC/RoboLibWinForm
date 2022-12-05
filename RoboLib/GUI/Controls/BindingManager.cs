using RoboLib.Extensions;
using RoboLib.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RoboLib.GUI.Controls
{
    public class BindingManager
    {
        /// <summary>
        /// The control that is binding
        /// </summary>
        public Control BoundControl { get; private set; }

        /// <summary>
        /// The binding tool for display purposes
        /// </summary>
        public BindingTools BindingTool { get; private set; }

        /// <summary>
        /// The property name of binding target
        /// </summary>
        protected string _propertyName;

        /// <summary>
        /// The bound obj
        /// </summary>
        protected ObjBase _boundObj;

        /// <summary>
        /// The PropertyInfo that is binding target
        /// </summary>
        protected PropertyInfo _pInfo;

        /// <summary>
        /// The type of binding property, used when _pInfo still not available (when binding master detail, we do not get the detail obj yet)
        /// </summary>
        protected Type _propertyType;

        /// <summary>
        /// The cached getter
        /// </summary>
        protected PropertyGetterDelegate _getter;

        /// <summary>
        /// Delegate for expression based property getter
        /// </summary>
        /// <param name="propertyName"></param>
        /// <param name="instance"></param>
        /// <returns></returns>
        public delegate object PropertyGetterDelegate(string propertyName, object instance);

        public BindingManager() { }

        public PropertyGetterDelegate GetterOf()
        {
            return (s, i) => Getter(s)(i);
        }

        public Func<object, object> Getter(string propertyName)
        {
            return (i) => _boundObj.GetType().GetProperty(propertyName).GetValue(i, null);
        }

        internal void BindToProperty(Control boundControl, ObjBase obj, string propertyName, BindingTools bindingtool)
        {
            BoundControl = boundControl;
            BindingTool = bindingtool;
            _propertyName = propertyName;
            _boundObj = obj;
            _pInfo = _boundObj.GetType().GetProperty(propertyName);
            _propertyType = _pInfo.PropertyType;
            _getter = GetterOf();
            _boundObj.PropertyChanged += new PropertyChangedEventHandler(OnPropertyChanged);
            OnBindToProperty();
            OnPropertyChanged(null, new PropertyChangedEventArgs(_pInfo.Name));
            boundControl.Disposed += (s, e) => OnDisposing();
        }

        void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == _pInfo.Name)
            {
                OnPropertyChanged(_getter(_pInfo.Name, _boundObj));
            }
        }

        /// <summary>
        /// Derived Control must handle this to perform display when PropertyChanged if not doing Binding
        /// </summary>
        /// <param name="newVal"></param>
        protected virtual void OnPropertyChanged(object newVal) { }

        /// <summary>
        /// Derived class should handle this to do binding.
        /// </summary>
        protected virtual void OnBindToProperty() { }

        /// <summary>
        /// Force the container of the control to perform Validate
        /// </summary>
        protected void ForceValidate()
        {
            var rtbContainer = BoundControl.GetParentControlOfType<RTextBox>();
            if (rtbContainer != null)
            {
                rtbContainer.BeginInvoke(new Func<bool>(rtbContainer.Validate)); // Allow data source to update, otherwise there is chance that 
                // when we come to verify changes in NotifyChanges, data source is still not updated yet making Apply/Cancel not shown
                rtbContainer.ActiveControl = BoundControl;
            }

            var rcbContainer = BoundControl.GetParentControlOfType<RCheckBox>();
            if (rcbContainer != null)
            {
                rcbContainer.BeginInvoke(new Func<bool>(rcbContainer.Validate));
                rcbContainer.ActiveControl = BoundControl;
            }

            var rtrbarContainer = BoundControl.GetParentControlOfType<RTrackBar>();
            if (rtrbarContainer != null)
            {
                rtrbarContainer.BeginInvoke(new Func<bool>(rtrbarContainer.Validate));
                rtrbarContainer.ActiveControl = BoundControl;
            }
        }

        /// <summary>
        /// Make the display string considered Unit and FormatString (in BindingHelper)
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        protected string MakeDisplayString(object val)
        {
            if (val == null) return "NULL";
            
            var t = val.GetType();

            if (t == typeof(int) || t == typeof(double) || t == typeof(long))
            {
                return ConstructString(Convert.ToDouble(val), BindingTool.Unit, BindingTool.DisplayFormat);
            }
            return val.ToString();
        }

        string ConstructString(double val, Units unit, string formatString)
        {
            if (unit != Units.NA && unit != Units.NoUnit)
            {
                val = val.UnitToExternal(unit);
            }

            if (!string.IsNullOrEmpty(formatString))
            {
                return val.ToString(formatString);
            }
            else
            {
                return val.ToString();
            }
        }

        protected void NotifyChanges(ObjBase boundObj = null, PropertyInfo pInfo = null)
        {

        }

        /// <summary>
        /// Create Label text with Units
        /// </summary>
        /// <param name="labelControl"></param>
        /// <param name="showUnit"></param>
        /// <returns></returns>
        public BindingManager LabelWithUnits(Control labelControl = null)
        {
            string unit;
            if ((BindingTool != null) && (BindingTool.Unit != Units.NA))
            {
                if (BindingTool.Unit != Units.percent)
                {
                    unit = string.Format("({0})", BindingTool.Unit);
                }
                else 
                {
                    unit = "(%)";
                }
            }
            else
            {
                unit = "";
            }

            labelControl.Text = string.Format("{0} {1}", labelControl.Text, unit);
            return this;
        }

        /// <summary>
        /// Derived Control should handle this to unregister/dispose events/things.
        /// </summary>
        protected virtual void OnDisposing()
        {
            if (_boundObj != null)
            {
                // There is binding, unregister all events
                _boundObj.PropertyChanged -= new PropertyChangedEventHandler(OnPropertyChanged);
            }
        }
    }
}
