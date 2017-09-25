using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Infrastructure.Extensions
{
    static class SqlExtensions
    {
        public static T ToObject<T>(this DataRow row)
        {
            T item = Activator.CreateInstance<T>();
            foreach (PropertyInfo propriedade in typeof(T).GetProperties())
            {
                propriedade.SetValue(item, row[propriedade.Name]);
            }
            return item;
        }
        public static List<T> ToObjectCollection<T>(this DataTable table)
        {
            List<T> items = Activator.CreateInstance<List<T>>();
            foreach (DataRow row in table.Rows)
            {
                items.Add(ToObject<T>(row));
            }
            return items;
        }

    }
}
