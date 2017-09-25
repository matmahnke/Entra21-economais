using DataAccessLayer.Infrastructure;
using DataAccessLayer.Infrastructure.Extensions;
using DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicalLayer
{
    public static class SetorBLL
    {
        public static double TrazPreco(Item produto, int codigoMercado)
        {
            SetorDAL setordal = new SetorDAL();
            SqlWhereSetor comando = new SqlWhereSetor();

            // SqlCommand comand = comando.XmlLike2andCod("Nome", produto.item_name, "Peso", produto.amount.ToString(), codigoMercado);
            List<Produto> lista = setordal.SelectXML(codigoMercado, Convert.ToDouble(produto.amount),produto.item_name);
            double precoProduto = 0;
            foreach (Produto item in lista)
            {
                precoProduto = item.Preco;
            }
            return precoProduto;
        }
        public static List<Produto> trazProdutosDoMercado(int id)
        {
            SetorDAL DAL = new SetorDAL();
            SqlWhereSetor where = new SqlWhereSetor();
            SqlCommand comando = where.XmlCod(id);
            List<Produto> produtos = DAL.SelectXML(comando);
            return produtos;
        }
        public static List<string> trazListaDeSetores(int id)
        {
            SetorDAL dal = new SetorDAL();
            SqlWhereSetor where = new SqlWhereSetor();
            List<string> lista = dal.SelectSetores(where.XmlCod(id));
            return lista;
        }

    }
}
