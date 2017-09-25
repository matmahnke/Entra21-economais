using DTO.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    [TableName("Usuario")]
    public class Usuario : Entity
    {
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Senha { get; set; }
        public string Localizacao { get; set; }
        public string Email { get; set; }
        public string ListaFavoritos { get; set; }
        public string UltimaLista { get; set; }
    }
}
