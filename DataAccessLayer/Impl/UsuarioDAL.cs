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
    public class UsuarioDAL : IEntityCRUD<Usuario>
    {

        public int Delete(Usuario item)
        {
            return new DBExecuter().Execute(SqlGenerator<Usuario>.BuildDeleteCommand(item));
        }

        public List<Usuario> GetALL(SqlCommand Where)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "SELECT * FROM Usuario ";
            command.CommandText += Where.CommandText;
            foreach (SqlParameter item in Where.Parameters)
            {
                command.Parameters.Add(new SqlParameter(item.ParameterName, item.Value));
            }
            DataTable table = new DBExecuter().GetData(command);
            if (table.Rows.Count == 0)
            {
                return null;
            }
            return table.ToObjectCollection<Usuario>();
        }


        public void Insert(Usuario item)
        {
            new DBExecuter().Execute(SqlGenerator<Usuario>.BuildInsertCommand(item));

        }

        public int Update(Usuario item)
        {
            return new DBExecuter().Execute(SqlGenerator<Usuario>.BuildUpdateCommand(item));

            return 0;
        }
    }
}
