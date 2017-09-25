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
    public class SupermercadoBLL
    {
        SupermercadoDAL supermercadoDAL = new SupermercadoDAL();
        public string atualizaSupermercado(Supermercado supermercado)
        {
            ValidacoesBLL validacoes = new ValidacoesBLL();
            StringBuilder builder = validacoes.validaSupermercado(supermercado);
            try
            {
                if (builder.Length != 0) { return builder.ToString(); }
            }
            catch (Exception)
            {
                try
                {
                    supermercado.CNPJ = supermercado.CNPJ.Replace(".", "").Replace("-", "").Replace("/", "");
                    supermercadoDAL.Update(supermercado);
                    return "Atualização feita com sucesso!";
                }
                catch (Exception)
                {
                    return "Erro na atualização";
                }
            }
            return null;
        }
        public string inseriSupermercado(Supermercado supermercado)
        {
            ValidacoesBLL validacoes = new ValidacoesBLL();
            StringBuilder builder = validacoes.validaSupermercado(supermercado);
            try
            {
                if (builder.Length != 0) { return builder.ToString(); }
            }
            catch (Exception)
            {
                try
                {
                    supermercado.CNPJ = supermercado.CNPJ.Replace(".", "").Replace("-", "").Replace("/", "");
                    supermercadoDAL.Insert(supermercado);
                    return "Cadastro realizado com sucesso!";
                }
                catch (Exception)
                {
                    return "Erro no cadastro";
                }
            }
            return null;
        }
        public Supermercado selecionaSupermercado(int ID)
        {
            SqlWhereSupermercado where = new SqlWhereSupermercado();
            SqlCommand comando = where.selecionarPorID(ID);
            List<Supermercado> lista = supermercadoDAL.GetALL(comando);
            Supermercado retorno = new Supermercado();
            foreach (Supermercado item in lista)
            {
                retorno.ID = item.ID;
                retorno.Nome = item.Nome;
                retorno.RazaoSocial = item.RazaoSocial;
                retorno.Maps = item.Maps;
                retorno.CNPJ = item.CNPJ;
                retorno.Endereco = item.Endereco;
                retorno.Telefone = item.Telefone;
                retorno.Email = item.Email;
                retorno.Senha = item.Senha;
                retorno.Logo = item.Logo;
                return retorno;
            }
            return null;
        }

        public List<Supermercado> selecionaTodosSupermercado()
        {
            SqlCommand comando = new SqlCommand();
            List<Supermercado> lista = supermercadoDAL.GetALL(comando);
            return lista;
        }
    }
}
