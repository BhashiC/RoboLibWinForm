using RoboLib.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RoboLib.GUI.Controls
{
    /// <summary>
    /// Custom Binding class, to handle un-necessary notification (all bound controls get notified when single property changed)
    /// </summary>
    public class CustomBinding : Binding, IDisposable
    {
        INotifyPropertyChanged _dataSource;
        public CustomBinding(string propertyName, INotifyPropertyChanged dataSource, string dataMember,
            DataSourceUpdateMode dataSourceUpdateMode = DataSourceUpdateMode.OnValidation,
            object nullValue = null, string formatString = null)
            : base(propertyName, dataSource, dataMember)
        {
            this.DataSourceUpdateMode = dataSourceUpdateMode;
            this.NullValue = nullValue;
            this.FormatString = formatString;
            _dataSource = dataSource;
            _dataSource.PropertyChanged += new PropertyChangedEventHandler(_dataSource_PropertyChanged);
        }

        void _dataSource_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            var val = sender.ToString();
            this.ControlUpdateMode = ControlUpdateMode.Never; // Never auto update the Control
            if (e.PropertyName == this.BindingMemberInfo.BindingField) // Instead, force ReadValue when the exact PropertyName changed
            { 
                this.ReadValue();
            }
        }

        /// <summary>
        /// Enable the binding completed handling.
        /// </summary>
        /// <param name="notifyChanges"></param>
        /// <param name="useErrProvider"></param>
        /// <returns></returns>
        public CustomBinding EnableBindingComplete(Action notifyChanges, bool useErrProvider = false)
        {
            this.FormattingEnabled = true;
            _notifyChanges = notifyChanges;
            if (useErrProvider)
                _errProvider = new ErrorProvider();
            this.BindingComplete += new BindingCompleteEventHandler(CustomBinding_BindingComplete);
            return this;
        }

        ErrorProvider _errProvider;
        Action _notifyChanges;
        void CustomBinding_BindingComplete(object sender, BindingCompleteEventArgs e)
        {
            if (e.BindingCompleteContext == BindingCompleteContext.DataSourceUpdate)
            {
                var c = e.Binding.BindableComponent as Control;
                if (e.BindingCompleteState == BindingCompleteState.Success)
                {
                    if (c is TextBox) 
                    {
                        c.BackColor = SystemColors.Window;
                    }
                    SetError(c, _errProvider, string.Empty);
                    _notifyChanges.Elvis(x => x());
                }
                else
                {
                    if (c is TextBox)
                    {
                        c.BackColor = Color.Pink;
                    }
                    SetError(c, _errProvider, e.ErrorText);
                }
            }
        }

        /// <summary>
        /// Set th Error provider
        /// </summary>
        /// <param name="c"></param>
        /// <param name="errProvider"></param>
        /// <param name="errText"></param>
        public void SetError(Control c, ErrorProvider errProvider, string errText)
        {
            errProvider = errProvider ?? new ErrorProvider();
            var padding = c.Parent.Padding;
            if (!string.IsNullOrEmpty(errText))
            {
                c.Parent.Padding = new Padding(0, 0, 15, 0);
            }
            else
            {
                if (c.Parent.Padding.All != 0)
                {
                    c.Parent.Padding = new Padding(0);
                }
            }
            errProvider.SetError(c, errText);
        }

        public void Dispose()
        {
            _dataSource.PropertyChanged -= new PropertyChangedEventHandler(_dataSource_PropertyChanged);
            this.BindingComplete -= new BindingCompleteEventHandler(CustomBinding_BindingComplete);
            _errProvider.Elvis(x => x.Dispose());  
        }
    }
}
