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
    public static class ControlExtensions
    {
        /// <summary>
        /// Get parent control of a specific type
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="control"></param>
        /// <returns></returns>
        public static T GetParentControlOfType<T>(this Control control) where T : Control
        {
            if (control.Parent == null)
            {
                return null;
            }
            else if (control.Parent.GetType() == typeof(T))
            {
                return (T)control.Parent;
            }
            else
            {
                return control.Parent.GetParentControlOfType<T>();
            }
        }

        public static void RunAsync(this Control control, Action action)
        {
            control.Enabled = false;
            AsyncRun(control, action, () => control.Enabled = true);
        }

        static void DummyAndInvoke(Action ac)
        {
            try
            {
                Control c = RefControl.Instance;
                c.Invoke(ac);
            }
            catch (Exception ex)
            {
                
            }
    }

        /// <summary>
        /// Run an action asynchronous
        /// </summary>
        /// <param name="control"></param>
        /// <param name="action"></param>
        static void AsyncRun(Control control, Action action, Action callback)
        {
            action.BeginInvoke
               (
                   (asyncResult) =>
                   {
                       try { action.EndInvoke(asyncResult); }
                       catch (Exception ex)
                       {
                           RException.Execute(ex, "RunAsync fail!" + ex.Message);
                       }
                       DummyAndInvoke(callback);
                   }, null
                );
        }

        /// <summary>
        /// Add a child control and bring it to front. Return same child control for Fluent.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="c"></param>
        /// <param name="childControl"></param>
        /// <returns></returns>
        public static T AddAndBringToFront<T>(this Control c, T childControl) where T : Control
        {
            c.Controls.Add(childControl);
            childControl.BringToFront();
            return childControl;
        }

        public static void RenderObjBaseSettings(this Panel panel, ObjBase obj, PropertyViewModes mode = PropertyViewModes.NotShown)
        {
            var allProperties = obj.GetType().GetProperties().ToList();
            var simpleProperties = allProperties.Where(x => RUtils.Prop.IsSimpleBinding(x) && x.GetSetMethod() != null)
                                                .Where(x => !RUtils.Prop.IsPropertyViewMode(x, PropertyViewModes.NotShown)).ToList();

            if (simpleProperties == null)
            {
                return;
            }
            else
            {
                panel.AutoScroll = true;
                if (mode == PropertyViewModes.Setting)
                {
                    simpleProperties = simpleProperties.Where(x => !RUtils.Prop.IsPropertyViewMode(x, PropertyViewModes.ReadOnly)).ToList();
                    simpleProperties.ForEach(p => p.CreateSettingControlAndBind(obj, c =>
                    {
                        c.Dock = DockStyle.Top;
                        panel.Controls.Add(c);
                    }));
                }
                else
                {
                    simpleProperties = simpleProperties.Where(x => RUtils.Prop.IsPropertyViewMode(x, PropertyViewModes.ReadOnly)).ToList();
                    simpleProperties.ForEach(p => p.CreateSettingControlAndBind(obj, c =>
                    {
                        if (c is RTextBox)
                        {
                            (c as RTextBox).SetReadOnly(true);
                        }
                        c.Dock = DockStyle.Top;
                        c.Enabled = false;
                        panel.Controls.Add(c);
                    }));
                }
               
            }
        }

        /// <summary>
        /// Run an action against a control if the action is not null, why reserve the control type for fluent call.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="control"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        public static T RunAction<T>(this T control, Action<Control> action) where T : Control
        {
            if (action != null)
            {
                action(control);
            }
            return control;
        }
    }
}
