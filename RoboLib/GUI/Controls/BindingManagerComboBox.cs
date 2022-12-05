using RoboLib.Extensions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RoboLib.GUI.Controls
{
    public class BindingManagerComboBox : BindingManager
    {
        public BindingManagerComboBox() { }

        protected override void OnBindToProperty()
        {
            base.OnBindToProperty();
            IList dataSource = new List<string>() { (_getter(_pInfo.Name, _boundObj) ?? "").ToString() };

            if (_pInfo.PropertyType == typeof(string))
            {
                // string type is allow to bind for combo box    
            }
            else if (_pInfo.PropertyType.IsEnum)
            {
                // enum type is allow to bind for combo box
                dataSource = (IList)Enum.GetValues(_pInfo.PropertyType);
            }
            else
            {
                throw new RException("BindingMangerComboBox only supports Enum and String types!");
            }

            if (BoundControl is ComboBox)
            {
                var cb = BoundControl as ComboBox;
                cb.DataSource = dataSource;  // Enum data source is show here, for string List call AddStringSource function      
                cb.SelectedItem = _getter(_pInfo.Name, _boundObj);
                cb.DropDownStyle = ComboBoxStyle.DropDownList;
                cb.SelectionChangeCommitted += new EventHandler(cb_SelectionChangeCommitted);
                cb.Resize += (s, e) => cb_Resized(cb);
            }
            else
            {
                throw new RException("BindingMangerComboBox only supports Winforms ComboBox");
            }
        }

        void cb_Resized(ComboBox cb)
        {
            try
            {
                cb.SelectionLength = 0; // Prevent ComboBox perform the selection on the text (highlight)
            }
            catch { }
        }

        void cb_SelectionChangeCommitted(object sender, EventArgs e)
        {
            // We have to manual set the property, since the binding does not do it
            _boundObj.GetType().GetProperty(_propertyName).SetValue(_boundObj, sender.GetType().GetProperty("SelectedItem").GetValue(sender));
            //NotifyChanges();
        }

        protected override void OnPropertyChanged(object newVal)
        {
            BoundControl.GetType().GetProperty("SelectedItem").SetValue(BoundControl, newVal);
        }

        /// <summary>
        /// Need only for string lists, enums will auto add when BindToPropertry 
        /// </summary>
        /// <param name="dataSource"></param>
        /// <returns></returns>
        public BindingManagerComboBox UseDataSource(IList<string> dataSource, bool allowUserToAddData = false)
        {
            string val = _getter(_pInfo.Name, _boundObj) as string;
            if (!string.IsNullOrEmpty(val) && !dataSource.Contains(val))
            {
                dataSource.Add(val); // Make sure the current item is always in the list
            }
            BoundControl.GetType().GetProperty("DataSource").SetValue(BoundControl, dataSource);
            BoundControl.GetType().GetProperty("SelectedItem").SetValue(BoundControl, val);
            BoundControl.GetType().GetProperty("DropDownStyle").
                SetValue(BoundControl, allowUserToAddData ? ComboBoxStyle.DropDown : ComboBoxStyle.DropDownList);

            if (allowUserToAddData) SetupDataSourceUpdate();

            return this;
        }

        void SetupDataSourceUpdate()
        {
            BoundControl.KeyDown += new KeyEventHandler(BoundControl_KeyDown);
        }

        void BoundControl_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                UpdateDataSource(true);
            }
            else if (e.KeyValue == 46)
            {
                UpdateDataSource(false);
            }
        }


        void UpdateDataSource(bool add)
        {
            string text = BoundControl.GetType().GetProperty("Text").GetValue(BoundControl) as string;
            var dataSource = BoundControl.GetType().GetProperty("DataSource").GetValue(BoundControl) as IList<string>;

            if (string.IsNullOrEmpty(text))
            {   //if text is empty no need to modify the DataSource
                return;
            }
            if (add)
            {
                if (!dataSource.Any(x => x == text))
                {
                    dataSource.Add(text);
                }
            }
            else
            {
                if (dataSource.Any(x => x == text))
                {
                    dataSource.Remove(text);
                }
            }
            BoundControl.GetType().GetProperty("DataSource").SetValue(BoundControl, null);
            BoundControl.GetType().GetProperty("DataSource").SetValue(BoundControl, dataSource);
            BoundControl.GetType().GetProperty("SelectedItem").SetValue(BoundControl, add ? text : string.Empty);

            cb_SelectionChangeCommitted(BoundControl, null);
        }

        protected override void OnDisposing()
        {
            base.OnDisposing();
            (BoundControl as ComboBox).SelectionChangeCommitted -= new EventHandler(cb_SelectionChangeCommitted);
            BoundControl.KeyDown -= new KeyEventHandler(BoundControl_KeyDown);
            (BoundControl as ComboBox).Resize -= (s, e) => cb_Resized(BoundControl as ComboBox);
        }
    }
}
