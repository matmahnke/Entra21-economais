using DTO;
using DTO.Interfaces;
using DataAccessLayer.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using DataAccessLayer.Infrastructure.Extensions;
using DTO.DataAnnotations;

namespace DataAccessLayer
{
    public class UsuarioDAL : IEntityCRUD<Setor>
    {

        public int Delete(Setor item)
        {
            return new DBExecuter().Execute(SqlGenerator<Setor>.BuildDeleteCommand(item));
        }

        public List<Setor> GetALL()
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "SELECT * FROM Usuario";
            DataTable table = new DBExecuter().GetData(command);
            if (table.Rows.Count == 0)
            {
                return null;
            }
            return table.ToObjectCollection<Setor>();
        }


        public void Insert(Setor item)
        {
            new DBExecuter().Execute(SqlGenerator<Setor>.BuildInsertCommand(item));

        }

        public int Update(Setor item)
        {
            return new DBExecuter().Execute(SqlGenerator<Setor>.BuildUpdateCommand(item));

            return 0;
        }
    }
}
