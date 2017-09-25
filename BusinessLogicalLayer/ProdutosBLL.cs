using DataAccessLayer.Infrastructure;
using DataAccessLayer.Infrastructure.Extensions;
using DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgShopAPP
{
    public class ProdutosBLL
    {
        public List<Produto> BuscarTudo()
        {
            SetorDAL setor = new SetorDAL();
            SqlCommand command = new SqlCommand();
            return setor.SelectXML(command);
        }

        public List<Produto> Buscar(string Pesquisa)
        {
            SetorDAL setor = new SetorDAL();
            SqlCommand command = new SqlCommand();
            List<Produto> Produtos = setor.SelectXML(command);

            string[] pesquisa = Pesquisa.Split(' ');
            foreach (Produto produto in Produtos)
            {
                produto.importancia = 0;
                if (produto.Nome.Contains(pesquisa.ToString()))
                {
                    produto.importancia++;
                }
                if (produto.Peso.ToString().Contains(pesquisa.ToString()))
                {
                    produto.importancia++;
                }
            }

            Produtos.RemoveAll(p => p.importancia == 0);
            Produtos = Produtos.OrderByDescending(p => p.importancia).ToList();
            return Produtos;
        }

        public class ProdutosComparer : IEqualityComparer<Produto>
        {
            public bool Equals(Produto x, Produto y)
            {
                if ((x.Nome == y.Nome) && (x.Peso == y.Peso))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            public int GetHashCode(Produto obj)
            {
                return obj.Nome.GetHashCode();
            }
        }
    }
}
