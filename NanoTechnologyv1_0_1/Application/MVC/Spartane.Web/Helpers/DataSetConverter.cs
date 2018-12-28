using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;

namespace Spartane.Web.Helpers
{
    public static class DataSetConverter
    {
        public static DataTable ToDataTable<T>(this IList<T> data)
        {
            string currentCulture = Thread.CurrentThread.CurrentCulture.Name;
            //For Export Set this culture 
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-us");

            PropertyDescriptorCollection props =
                TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();
            for (int i = 0; i < props.Count; i++)
            {
                PropertyDescriptor prop = props[i];
                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);            
            }
            object[] values = new object[props.Count];
            foreach (T item in data)
            {
                for (int i = 0; i < values.Length; i++)
                {
                    values[i] = props[i].GetValue(item);
                }

                table.Rows.Add(values);
            }
            //Set back the original culture
            foreach (var column in table.Columns.Cast<DataColumn>().ToArray())
            if(table.AsEnumerable().All(dr=> dr.IsNull(column.ColumnName)))
                table.Columns.Remove(column);
            
            return table;
        }
    }
}
