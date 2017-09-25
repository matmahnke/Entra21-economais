using DTO.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Produto
    {
        public string Nome { get; set; }
        public double Preco { get; set; }
        public int Quantidade { get; set; }
        public double Peso { get; set; }
        public string Imagem { get; set; }
        public double Promocao { get; set; }
        public DateTime DataDeInicio { get; set; }
        public DateTime DataDeTermino { get; set; }
    }
}
