using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml;
using System.IO;

namespace DataAccessLayer.Infrastructure
{
    public class DBExecuter
    {
        private ConnectionHelper helper =
            new ConnectionHelper();

        public int Execute(SqlCommand command)
        {
            using (helper)
            {
                helper.Setup(command);
                return command.ExecuteNonQuery();
            }
        }
        public DataTable GetData(SqlCommand command)
        {
            using (helper)
            {
                helper.Setup(command);
                DataTable table = new DataTable();
                table.Load(command.ExecuteReader());
                return table;
            }
        }
        public string GetStringXML(SqlCommand command)
        {
            string xml;
            using (helper)
            {
                helper.Setup(command);
                SqlDataReader reader = command.ExecuteReader();
                reader.Read();
                xml = (string)reader["Produto"];
            }
            return xml;
        }
    }
}
