using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Models
{
    public class MercadoMenorPrecoViewModels
    {
        public Supermercado Mercado { get; set; }
        public double Preco { get; set; }
        public double Proximidade { get; set; }
        public List<Item> Itens { get; set; }
    }
}