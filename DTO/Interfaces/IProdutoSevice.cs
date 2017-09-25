using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Interfaces
{
    public interface IProdutoSevice
    {
        void UpdateXML(Setor setor, SqlCommand where);
        List<Produto> SelectXML(SqlCommand where);
        void InsertXML(Setor setor);
        void DeleteXMLRow(Setor setor, SqlCommand where);
    }
}
