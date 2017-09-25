using DataAccessLayer.Infrastructure.Extensions;
using DTO;
using DTO.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Infrastructure
{
    public class SupermercadoDAL : IEntityCRUD<Supermercado>
    {
        public int Delete(Supermercado item)
        {
            return new DBExecuter().Execute(SqlGenerator<Supermercado>.BuildDeleteCommand(item));
        }

        public List<Supermercado> GetALL()
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "SELECT * FROM Supermercado";
            DataTable table = new DBExecuter().GetData(command);
            if (table.Rows.Count == 0)
            {
                return null;
            }
            return table.ToObjectCollection<Supermercado>();
        }

        public void Insert(Supermercado item)
        {
            new DBExecuter().Execute(SqlGenerator<Supermercado>.BuildInsertCommand(item));

        }

        public int Update(Supermercado item)
        {
            new DBExecuter().Execute(SqlGenerator<Supermercado>.BuildUpdateCommand(item));
            return 0;
        }
    }
}
