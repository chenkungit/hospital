using SCommon.SAttribute;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using UBaseLib.Models;

namespace SCommon.SUtil
{
    public class SGridViewUtil
    {
        ///// 将泛型集合类转换成DataTable    
        ///// </summary>    
        ///// <typeparam name="T">集合项类型</typeparam>    
        ///// <param name="list">集合</param>    
        ///// <param name="propertyName">需要返回的列的列名</param>    
        ///// <returns>数据集(表)</returns>    
        //public static void ToDataTable<T>(IList<T> list, DataGridView sender, params string[] viewName)
        //{
        //    // sender.DataSource = null;
        //    sender.Rows.Clear();
        //    sender.Columns.Clear();
        //    //获取所有的字段信息
        //    //FieldInfo[] f = typeof(T).GetFields();
        //    PropertyInfo[] property = typeof(T).GetProperties();
        //    DataTable result = new DataTable();
        //    if (viewName != null)
        //    {
        //        for (int k = 0; k < viewName.Length; k++)
        //        {
        //            DataGridViewColumn column = new DataGridViewColumn();
        //            column.Visible = true;
        //            DataGridViewCell dgvcell = new DataGridViewTextBoxCell();
        //            column.CellTemplate = dgvcell;
        //            column.Name = viewName[k];
        //            sender.Columns.Add(column);
        //        }
        //    }
        //    //遍历每个字段；
        //    for (int i = 0; i < property.Length; i++)
        //    {
        //        //获取每个字段上所有的 Attribute
        //        var attr = property[i].GetCustomAttributes(false);

        //        //查看每个字段上应用的所有Attribute
        //        foreach (Attribute a in attr)
        //        {
        //            //判断Attribute 中是否 为 SModelMethodAttribute
        //            if (a is SModelPropertyAttribute)
        //            {
        //                DataGridViewColumn column = new DataGridViewColumn();
        //                DataGridViewCell dgvcell = new DataGridViewTextBoxCell();
        //                column.CellTemplate = dgvcell;
        //                string d = (a as SModelPropertyAttribute).Display;
        //                if (null != viewName)
        //                {
        //                    if (!viewName.Contains(property[i].Name))
        //                    {
        //                        column.Visible = false;
        //                        column.HeaderText = d;
        //                        column.Name = property[i].Name;
        //                        sender.Columns.Add(column);
        //                    }
        //                    else
        //                    {
        //                        sender.Columns[property[i].Name].HeaderText = d;
        //                    }
        //                }
        //                else
        //                {
        //                    column.HeaderText = d;
        //                    sender.Columns.Add(column);
        //                    column.Name = property[i].Name;
        //                }
        //            }
        //        }
        //    }
        //    if (list.Count > 0)
        //    {
        //        for (int i = 0; i < list.Count; i++)
        //        {
        //            int index = sender.Rows.Add();

        //            DataGridViewRow row = sender.Rows[i];
        //            foreach (PropertyInfo pi in property)
        //            {
        //                if (pi.PropertyType.BaseType.FullName.StartsWith("SCommon.CARecord.BaseModel"))
        //                {
        //                    object obj = pi.GetValue(list[i], null);
        //                    Type entityType = pi.PropertyType;
        //                    PropertyInfo[] entityPis = entityType.GetProperties();
        //                    //遍历每个字段；
        //                    foreach (PropertyInfo entityPi in entityPis)
        //                    {
        //                        //获取每个字段上所有的 Attribute
        //                        var attr = entityPi.GetCustomAttributes(false);
        //                        //查看每个字段上应用的所有Attribute
        //                        foreach (Attribute a in attr)
        //                        {
        //                            //判断Attribute 中是否 为 SModelMethodAttribute
        //                            if (a is Castle.ActiveRecord.PrimaryKeyAttribute)
        //                            {
        //                                row.Cells[pi.Name].Value = entityPi.GetValue(obj, null);
        //                                break;
        //                            }
        //                        }
        //                    }
        //                }
        //                else
        //                {
        //                    row.Cells[pi.Name].Value = pi.GetValue(list[i], null);
        //                }
        //            }
        //            // sender.Rows.Add(row);
        //        }
        //    }
        //}

        /// <summary>
        /// 绑定DataGridView的数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="dataGridView"></param>
        /// <param name="visiblePropertyName"></param>
        public static void ToDataTable<T>(IList<T> list, DataGridView dataGridView, params string[] visiblePropertyName)
        {
            #region 设置dataTable
            DataTable dataTable = SDataTableUtil.ToDataTable<T>(list);
            dataGridView.DataSource = dataTable;
            #endregion

            #region 设置列头名称，以及哪些列显示
            //获取所有的字段信息
            //FieldInfo[] f = typeof(T).GetFields();
            PropertyInfo[] property = typeof(T).GetProperties();

            //遍历每个字段；
            for (int i = 0; i < property.Length; i++)
            {
                //获取每个字段上所有的 Attribute
                var attr = property[i].GetCustomAttributes(false);
                DataGridViewColumn column = dataGridView.Columns[property[i].Name];

                //查看每个字段上应用的所有Attribute
                foreach (Attribute a in attr)
                {
                    //判断Attribute 中是否 为 SModelMethodAttribute
                    if (a is SModelPropertyAttribute)
                    {
                        string columnHeaderName = (a as SModelPropertyAttribute).Display;
                        if (null != columnHeaderName && columnHeaderName.Length>0)
                        {
                            column.HeaderText = columnHeaderName;
                        }
                    }

                    if (visiblePropertyName != null && visiblePropertyName.Length>0)
                    {
                        if (visiblePropertyName.Contains(property[i].Name))
                            column.Visible = true;
                        else
                            column.Visible = false;
                    }
                }
            }
            #endregion
        }

        /// <summary>
        /// 绑定DataGridView的数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="dataGridView"></param>
        /// <param name="visiblePropertyName"></param>
        public static void BindingData<T>(IList<T> list, DataGridView dataGridView, params string[] visiblePropertyName)
        {
            // 设置数据源
            SortableBindingList<T> datasource = null;
            if (dataGridView.DataSource != null && dataGridView.DataSource as SortableBindingList<T> != null)
            {
                datasource = dataGridView.DataSource as SortableBindingList<T>;
                datasource.Clear();

                // 清除原有排序
                if (dataGridView.SortedColumn != null
                    && dataGridView.SortOrder != SortOrder.None)
                {
                    DataGridViewColumn column = dataGridView.SortedColumn;
                    DataGridViewColumnSortMode sortMode = column.SortMode;

                    column.SortMode = DataGridViewColumnSortMode.NotSortable;
                    column.SortMode = sortMode;
                }
            }
            else
            {
                datasource = new SortableBindingList<T>();
                dataGridView.DataSource = datasource;

                #region 设置列头名称，以及哪些列显示
                //获取所有的字段信息
                //FieldInfo[] f = typeof(T).GetFields();
                PropertyInfo[] property = typeof(T).GetProperties();

                //遍历每个字段；
                for (int i = 0; i < property.Length; i++)
                {
                    //获取每个字段上所有的 Attribute
                    var attr = property[i].GetCustomAttributes(false);
                    DataGridViewColumn column = dataGridView.Columns[property[i].Name];

                    //// 设置列
                    //if (column == null)
                    //{
                    //    //声明一个新的列
                    //    column = new DataGridViewColumn();
                    //    column.Name = property[i].Name;
                    //    column.DataPropertyName = property[i].Name;
                    //    column.HeaderText = property[i].Name;

                    //    //定义单元格模板
                    //    DataGridViewTextBoxCell dgvcell = new DataGridViewTextBoxCell();//这里根据自己需要来定义不同模板。当前模板为“文本单元格”
                    //    column.CellTemplate = dgvcell;//设置模板
                    //    dataGridView.Columns.Add(column);
                    //}

                    // 设置显示名称
                    foreach (Attribute a in attr)
                    {
                        if (a is SModelPropertyAttribute)
                        {
                            string columnHeaderName = (a as SModelPropertyAttribute).Display;
                            if (null != columnHeaderName && columnHeaderName.Length > 0)
                            {
                                column.HeaderText = columnHeaderName;
                            }
                        }
                    }

                    // 设置是否显示
                    if (visiblePropertyName != null && visiblePropertyName.Length > 0)
                    {
                        if (visiblePropertyName.Contains(property[i].Name))
                            column.Visible = true;
                        else
                            column.Visible = false;
                    }
                }
                #endregion
            }

            if (list != null && list.Count>0){
                foreach(T entity in list)
                    datasource.Add(entity);
            }
        }
    }
}
