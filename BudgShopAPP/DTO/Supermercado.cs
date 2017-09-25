using DTO.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    [TableName("Supermercado")]
    public class Supermercado : Entity
    {
        public string Nome { get; set; }
        public string RazaoSocial { get; set; }
        public string Maps { get; set; }
        public string CNPJ { get; set; }
        public string Bairro { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Logo { get; set; }
    }
}
