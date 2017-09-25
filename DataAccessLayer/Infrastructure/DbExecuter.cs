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
        public List<string> GetStringXML(SqlCommand command)
        {
            List<string> xml = new List<string>();
            using (helper)
            {
                helper.Setup(command);
                /*SqlDataReader reader = command.ExecuteReader();
                reader.Read();
                foreach (SqlDataReader item in reader)
                {
                    xml += (string)item["Produto"];
                }*/
                DataTable table = new DataTable();
                table.Load(command.ExecuteReader());
                foreach (DataRow item in table.Rows)
                {
                    string x = (string)item["Produto"];
                    xml.Add(x);
                }
            }
            return xml;
        }
        public List<string> GetSetorString(SqlCommand command)
        {
            List<string> xml = new List<string>();
            using (helper)
            {
                helper.Setup(command);
                /*SqlDataReader reader = command.ExecuteReader();
                reader.Read();
                foreach (SqlDataReader item in reader)
                {
                    xml += (string)item["Produto"];
                }*/
                DataTable table = new DataTable();
                table.Load(command.ExecuteReader());
                foreach (DataRow item in table.Rows)
                {
                    string x = (string)item["Nome"];
                    xml.Add(x);
                }
            }
            return xml;
        }
    }
}
