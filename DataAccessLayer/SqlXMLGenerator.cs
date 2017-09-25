using DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml;
using System.IO;
using System.Xml.Serialization;
using System.Reflection;
using DTO.DataAnnotations;

namespace DataAccessLayer.Infrastructure.Extensions
{
    public class SqlXMLGenerator
    {
        #region
        public static SqlCommand BuildInsertCommand(List<Produto> lista, Setor setor)
        {
            string xml = BuildXML(lista);
            StringBuilder comando = new StringBuilder();
            comando.AppendFormat("INSERT INTO Setor (Nome, CodigoMercado, Produto) VALUES (@Nome, @CodigoMercado, @Produto)");
            SqlCommand command = new SqlCommand();
            command.CommandText = comando.ToString();
            command.Parameters.AddWithValue("@Nome", setor.Nome);
            command.Parameters.AddWithValue("@CodigoMercado", setor.CodigoMercado);
            command.Parameters.AddWithValue("@Produto", xml.ToString());
            command.CommandText = comando.ToString();
            return command;
        }
        private static string BuildXML(List<Produto> lista)
        {
            XmlSerializer xml = new XmlSerializer(typeof(List<Produto>));
            using (MemoryStream ms = new MemoryStream())
            {
                xml.Serialize(ms, lista);
                ms.Position = 0;
                return Encoding.UTF8.GetString(ms.ToArray());
            }
        }
        #endregion
        #region
        public static SqlCommand BuildUpdateCommand(Setor item)
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendFormat("UPDATE Setor SET Produto=@Produto WHERE Nome = @Nome AND CodigoMercado = @CodigoMercado");
            SqlCommand command = new SqlCommand();
            string produto = BuildXML(item.Produto);
            command.CommandText = builder.ToString();
            command.Parameters.AddWithValue("@Produto", produto);
            command.Parameters.AddWithValue("@Nome", item.Nome);
            command.Parameters.AddWithValue("@CodigoMercado", item.CodigoMercado);
            return command;
        }
        #endregion
    }
}
