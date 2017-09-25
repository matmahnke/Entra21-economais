using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO.DataAnnotations;

namespace DTO
{
    public class Entity
    {
        [NonEditable()]
        public int ID { get; set; }
    }
}
