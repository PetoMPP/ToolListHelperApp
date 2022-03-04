using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ToolListHelperLibrary
{
    public class TableOperations
    {
        public static DataTable CreateTableFromListOfModels<T>(IEnumerable<T> models)
        {
            Type type = typeof(T);
            PropertyInfo[] properties = type.GetProperties();

            DataTable table = new DataTable("Table");
            foreach (PropertyInfo property in properties)
            {
                table.Columns.Add(property.Name, Nullable.GetUnderlyingType(property.PropertyType) ?? property.PropertyType);
            }
            foreach (T model in models)
            {
                object?[] values = new object?[properties.Length];
                for (int i = 0; i < properties.Length; i++)
                {
                    values[i] = properties[i].GetValue(model);
                }
            }
            return table;
        }
    }
}
