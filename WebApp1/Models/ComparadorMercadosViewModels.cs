using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Models
{
    public class ComparadorMercadosViewModels
    {
        public List<MercadoViewModels> MercadosMenorPreco { get; set; }
        public List<MercadoViewModels> MercadosMaisProximos { get; set; }
        public MercadoViewModels MercadoNossaSugestao { get; set; }
        public List<MercadoViewModels> OutrosMercados { get; set; }
    }
}