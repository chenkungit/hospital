using SCommon.SAttribute;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace SCommon.SUtil
{
    /// <summary>
    /// 
    /// </summary>
    public class SComboBoxData
    {
        public SComboBoxData(object _data, string _display)
        {
            this.Data = _data;
            this.Display = _display;
        }

        public object Data { get; set; }

        public string Display { get; set; }

        public override string ToString()
        {
            if (this.Display != null && this.Display.Length > 0)
            {
                return this.Display;
            }
            else
            {
                return base.ToString();
            }
        }
    }

    public class SComboBoxUtil
    {
        public static void BindingData<T>(ComboBox cb, IList<T> list, string displayProperty)
        {
            if (cb != null && list != null && list.Count > 0)
            {
                PropertyInfo pi = typeof(T).GetProperty(displayProperty);
                for (int i = 0; i < list.Count; i++)
                {
                    object _data = list[i];
                    SComboBoxData cbData = new SComboBoxData(_data, pi.GetValue(_data, null).ToString());
                    cb.Items.Add(cbData);
                }
            }
        }
    }
}
