using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml;
using DTO.DataAnnotations;

namespace DTO
{
    [TableName("Setor")]
    public class Setor : Entity
    {
        public string Nome { get; set; }
        public int CodigoMercado { get; set; }
        public List<Produto> Produto { get; set; }
    }
}
