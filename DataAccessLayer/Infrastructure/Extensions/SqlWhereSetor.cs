using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Infrastructure.Extensions
{
    public class SqlWhereSetor
    {
        public SqlCommand XmlLike(string tag, string like)
        {
            StringBuilder comando = new StringBuilder();
            comando.AppendFormat("WHERE Produto.value('(/ArrayOfProduto/Produto/" + tag + ")[1]', 'varchar(MAX)') LIKE '%" + like + "%'");
            SqlCommand command = new SqlCommand();
            command.CommandText = comando.ToString();
            return command;
        }
        public SqlCommand XmlLike(string setor, int codMercado, string tag, string like)
        {
            StringBuilder comando = new StringBuilder();
            comando.AppendFormat("WHERE Setor = '" + setor + "' AND CodigoMercado = '" + codMercado + "' Produto.value('(/ArrayOfProduto/Produto/" + tag + ")[1]', 'varchar(MAX)') LIKE '%" + like + "%'");
            SqlCommand command = new SqlCommand();
            command.CommandText = comando.ToString();
            return command;
        }
        public SqlCommand XmlLikeandCod(string tag, string like, int codigo)
        {
            StringBuilder comando = new StringBuilder();
            comando.AppendFormat("WHERE CodigoMercado = @CodigoMercado AND Produto.value('(/ArrayOfProduto/Produto/" + tag + ")[1]', 'varchar(MAX)') LIKE '%" + like + "%'");
            SqlCommand command = new SqlCommand();
            command.Parameters.AddWithValue("@CodigoMercado", codigo);
            command.CommandText = comando.ToString();
            return command;
        }
        public SqlCommand XmlLike2andCod(string tag, string like, string tag2, string like2, int codigo)
        {
            StringBuilder comando = new StringBuilder();
            comando.AppendFormat("WHERE CodigoMercado = @CodigoMercado AND Produto.value('(/ArrayOfProduto/Produto/" + tag + ")[1]', 'varchar(MAX)') LIKE '%" + like + "%' AND Produto.value('(/ArrayOfProduto/Produto/" + tag2 + ")[1]', 'varchar(MAX)') LIKE '%" + like2 + "%'");
            SqlCommand command = new SqlCommand();
            command.Parameters.AddWithValue("@CodigoMercado", codigo);
            command.CommandText = comando.ToString();
            return command;
        }
        public SqlCommand XmlCod(int codigo)
        {
            StringBuilder comando = new StringBuilder();
            comando.AppendFormat("WHERE CodigoMercado = @CodigoMercado");
            SqlCommand command = new SqlCommand();
            command.Parameters.AddWithValue("@CodigoMercado", codigo);
            command.CommandText = comando.ToString();
            return command;
        }
        public SqlCommand XmlCodAndSetor(int codigo, string setor)
        {
            StringBuilder comando = new StringBuilder();
            comando.AppendFormat("WHERE CodigoMercado = @CodigoMercado AND Nome = @Nome");
            SqlCommand command = new SqlCommand();
            command.Parameters.AddWithValue("@CodigoMercado", codigo);
            command.Parameters.AddWithValue("@Nome", setor);
            command.CommandText = comando.ToString();
            return command;
        }
    }
}
