using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Infrastructure
{
    /// <summary>
    /// Classe responsável por gerenciar as conexões
    /// com a base de dados. Futuramente, será
    /// implementado Multibanco.
    /// </summary>
    class ConnectionHelper : IDisposable
    {
        private SqlConnection connection;
        private static string connectionString;

        //Construtor estático. Executado apenas
        //UMA VEZ PELA APLICAÇÃO, permitindo
        //que façamos algum tipo de inicialização
        //mais custosa.
        static ConnectionHelper()
        {
            connectionString =
            ConfigurationManager.ConnectionStrings["CurrentDB"]
                                .ConnectionString;
        }
        //Construtor não estático. Executado CADA vez que o objeto
        //foi instanciado.
        public ConnectionHelper()
        {
            //Ao nascer o objeto  ConnectionHelper, nasce um SqlConnection.
            connection = new SqlConnection(connectionString);
        }
        public void OpenConnection()
        {
            if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }
        }

        public void Dispose()
        {
            if (connection.State == System.Data.ConnectionState.Open)
            {
                connection.Close();
            }
        }

        public void Setup(SqlCommand command)
         {
            command.Connection = connection;
            OpenConnection();
        }

    }
}
