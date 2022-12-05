using RoboLib.GUI.Controls;
using RoboLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RoboLib.Extensions
{
    public static class BindingExtensions
    {
        public static T BindToProperty<T>(this Control control, ObjBase obj, string propertyName, bool settingBind = false) where T : BindingManager
        {
            if (control is IControlPair)
            {
                var pair = control as IControlPair;
                return (T)pair.ValueControl.BindToProperty<T>(obj, propertyName, settingBind).LabelWithUnits(pair.LabelControl);
            }

            if (control is RCheckBox)
            {
                var rcb = control as RCheckBox;
                return (T)rcb.ValueControl.BindToProperty<T>(obj, propertyName, settingBind);
            }


            var pInfo = obj.GetType().GetProperty(propertyName);
            var bindingTool = pInfo.GetAttribute<BindingTools>() ?? new BindingTools();

            T bindingManager = (T)(Activator.CreateInstance(typeof(T)));
            bindingManager.BindToProperty(control, obj, propertyName, bindingTool);
            control.Tag = bindingManager;
            return bindingManager;
        }

        public static BindingManagerTextBox BindToProperty(this RTextBox control, ObjBase obj, string propertyName, bool settingBind = false)
        {
            return control.BindToProperty<BindingManagerTextBox>(obj, propertyName, settingBind);
        }

        public static BindingManagerComboBox BindToProperty(this RComboBox control, ObjBase obj, string propertyName, bool settingBind = false)
        {
            return control.BindToProperty<BindingManagerComboBox>(obj, propertyName, settingBind);
        }

        public static BindingManagerCheckBox BindToProperty(this RCheckBox control, ObjBase obj, string propertyName, bool settingBind = false)
        {
            return control.BindToProperty<BindingManagerCheckBox>(obj, propertyName, settingBind);
        }

        public static BindingManagerTrackBar BindToProperty(this RTrackBar control, ObjBase obj, string propertyName, bool settingBind = false)
        {
            return control.BindToProperty<BindingManagerTrackBar>(obj, propertyName, settingBind);
        }

        public static Control CreateSettingControlAndBind(this PropertyInfo pInfo, ObjBase obj, Action<Control> doBeforeBind = null)
        {
            switch (RUtils.Prop.GetBindingType(pInfo.PropertyType))
            {
                case BindingType.StringBinding:
                    var selectFrom = pInfo.GetAttribute<SelectFrom>();
                    if (selectFrom != null)
                    {
                        return (new RComboBox() { Name = "rbb" + pInfo.Name, LabelText = pInfo.Name }).RunAction<RComboBox>(doBeforeBind)
                            .BindToProperty(obj, pInfo.Name, true).UseDataSource(selectFrom.DataSourceList).BoundControl;
                    }
                    else
                    {
                        return (new RTextBox() { Name = "rtb" + pInfo.Name, LabelText = pInfo.Name }).RunAction<RTextBox>(doBeforeBind)
                            .BindToProperty(obj, pInfo.Name, true).BoundControl;
                    }
                case BindingType.BooleanBinding:
                    return (new RCheckBox() { Name = "rcb" + pInfo.Name, LabelText = pInfo.Name }).RunAction<RCheckBox>(doBeforeBind)
                        .BindToProperty(obj, pInfo.Name, true).BoundControl;
                case BindingType.EnumBinding:
                    return (new RComboBox() { Name = "cbb" + pInfo.Name, LabelText = pInfo.Name }).RunAction<RComboBox>(doBeforeBind)
                        .BindToProperty(obj, pInfo.Name, true).BoundControl;
                case BindingType.OtherValueBinding:
                case BindingType.NumberBinding:
                    return (new RTextBox() { Name = "tb" + pInfo.Name, LabelText = pInfo.Name }).RunAction<RTextBox>(doBeforeBind)
                        .BindToProperty(obj, pInfo.Name, true).BoundControl;
                default:
                    return null;
            }
        }
    }
}
