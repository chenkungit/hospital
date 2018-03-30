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
    public class SDataTableUtil
    {
        /// <summary>
        /// Converts a Generic List into a DataTable
        /// 一个list对象(不支持处理复杂类型)返回一个描述对象的DataTable
        /// </summary>
        /// <param name="list"></param>
        /// <param name="typ"></param>
        /// <returns></returns>
        public static DataTable ToDataTable<T>(IEnumerable<T> list)
        {
            DataTable dt = new DataTable();

            // Get a list of all the properties on the object
            PropertyInfo[] pi = typeof(T).GetProperties();

            // Loop through each property, and add it as a column to the datatable
            foreach (PropertyInfo p in pi)
            {
                // The the type of the property
                Type columnType = p.PropertyType;

                // We need to check whether the property is NULLABLE
                if (p.PropertyType.IsGenericType && p.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>))
                {
                    // If it is NULLABLE, then get the underlying type. eg if "Nullable<int>" then this will return just "int"
                    columnType = p.PropertyType.GetGenericArguments()[0];
                }

                // Add the column definition to the datatable.
                dt.Columns.Add(new DataColumn(p.Name, columnType));
            }

            if (list != null && list.ToList().Count > 0)
            {
                // For each object in the list, loop through and add the data to the datatable.
                foreach (object obj in list)
                {
                    object[] row = new object[pi.Length];
                    int i = 0;

                    foreach (PropertyInfo p in pi)
                    {
                        row[i++] = p.GetValue(obj, null);
                    }

                    dt.Rows.Add(row);
                }
            }
            return dt;
        }
    }
}
