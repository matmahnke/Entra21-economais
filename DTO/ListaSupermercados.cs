﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ListaSupermercados
    {
        public string Nome { get; set; }
        public string Maps { get; set; }
        public List<Item> Itens { get; set; }
    }
}
