using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Interfaces
{
    public interface IProdutoSevice
    {
        void UpdateXML(Setor setor);
        List<Produto> SelectXML(string where);
        void InsertXML(Setor setor);
        void DeleteXMLRow(Setor setor);
    }
}
