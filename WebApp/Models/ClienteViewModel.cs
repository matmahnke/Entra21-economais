using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Models
{
    public class ClienteViewModel
    {
       public int ID {get;set;}                 
       public string Nome {get;set;}
       public string Email {get;set;}
       public string CPF {get;set;}
       public bool Ativo { get; set;}
    }
}