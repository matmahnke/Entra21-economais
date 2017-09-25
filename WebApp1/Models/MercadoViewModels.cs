using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Models
{
    public class MercadoViewModels
    {
        public Supermercado SuperMercado { get; set; }
        public double PrecoFinal { get; set; }
        public double Proximidade { get; set; }
        public List<Item> Itens { get; set; }
        public List<Item> ItensNaoEncontrados { get; set; }
    }
}