using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Infrastructure.Extensions
{
    public class SqlWhereSupermercado
    {
        public SqlCommand verificaLoginSupermercado(string cnpj, string senha)
        {
            StringBuilder comando = new StringBuilder();
            comando.AppendFormat("WHERE CNPJ = @CNPJ AND Senha = @Senha");
            SqlCommand command = new SqlCommand();
            command.CommandText = comando.ToString();
            command.Parameters.AddWithValue("@CNPJ", cnpj);
            command.Parameters.AddWithValue("@Senha", senha);
            return command;
        }

        public SqlCommand selecionarPorID(int ID)
        {
            StringBuilder comando = new StringBuilder();
            comando.AppendFormat("WHERE Id = @Id");
            SqlCommand command = new SqlCommand();
            command.CommandText = comando.ToString();
            command.Parameters.AddWithValue("@Id", ID);
            return command;
        }
        public SqlCommand selecionaSeExistirCNPJ(string cnpj)
        {
            StringBuilder comando = new StringBuilder();
            comando.AppendFormat("WHERE CNPJ = @CNPJ");
            SqlCommand command = new SqlCommand();
            command.CommandText = comando.ToString();
            command.Parameters.AddWithValue("@CNPJ", cnpj);
            return command;
        }
    }
}
