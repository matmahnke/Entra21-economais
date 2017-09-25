using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DTO.Interfaces;
using DataAccessLayer.Infrastructure.Extensions;
using System.Data.SqlClient;
using System.Data;
using System.Xml.Serialization;
using System.IO;
using System.Xml;
using System.Xml.Linq;

namespace DataAccessLayer.Infrastructure
{
    public class SetorDAL : IProdutoSevice
    {
        public void InsertXML(List<Produto> lista, Setor setor)
        {
            new DBExecuter().Execute(SqlXMLGenerator.BuildInsertCommand(lista, setor));

        }

        public List<Produto> SelectXML(string where)
        {

            List<Produto> lista = new List<Produto>();
            SqlCommand command = new SqlCommand();
            command.CommandText = "SELECT Produto FROM Setor "+where;
            string xml = new DBExecuter().GetStringXML(command);

            //XmlSerializer serializer = new XmlSerializer(typeof(Produto));

             XmlSerializer serializer = new XmlSerializer(typeof(List<Produto>));
            byte[] buffer = Encoding.UTF8.GetBytes(xml);
            using (MemoryStream ms = new MemoryStream(buffer))
            {
                lista = (List<Produto>)serializer.Deserialize(ms);
            }
            return lista;
        }

        public void UpdateXML(List<Produto> lista, Setor setor)
        {
            new DBExecuter().Execute(SqlXMLGenerator.BuildUpdateCommand(setor));
        }
        
    }
}
