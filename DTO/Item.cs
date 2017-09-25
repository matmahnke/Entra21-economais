using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Item
    {
        public string cmd { get; set; }
        public string add { get; set; }
        public string item_name { get; set; }
        public double amount { get; set; }
        public string discount_amount { get; set; }
        public string submit { get; set; }
        public int quantity { get; set; }
        public string href { get; set; }
    }
}
