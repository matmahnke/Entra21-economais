using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Infrastructure.Extensions
{
    public class SqlWhereUsuario
    {
        public SqlCommand verificaLoginUsuario(string email, string senha)
        {
            StringBuilder comando = new StringBuilder();
            comando.AppendFormat("WHERE Email = '" + email + "' AND Senha = '" + senha + "'");
            SqlCommand command = new SqlCommand();
            command.CommandText = comando.ToString();
            //command.Parameters.AddWithValue("@Email", email);
            //command.Parameters.AddWithValue("@Senha", senha);
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
        public SqlCommand selecionaSeExistirEmail(string email)
        {
            StringBuilder comando = new StringBuilder();
            comando.AppendFormat("WHERE Email = @Email");
            SqlCommand command = new SqlCommand();
            command.Parameters.AddWithValue("@Email", email);
            command.CommandText = comando.ToString();
            return command;
        }
    }
}
