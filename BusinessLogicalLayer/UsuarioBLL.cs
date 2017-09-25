using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using DTO;
using DataAccessLayer.Infrastructure.Extensions;
using System.Data.SqlClient;
using DataAccessLayer.Infrastructure;

namespace BusinessLogicalLayer
{
    public class UsuarioBLL
    {
        UsuarioDAL usuarioDAL = new UsuarioDAL();
        public string atualizaUsuario(Usuario usuario)
        {
            ValidacoesBLL validacoes = new ValidacoesBLL();
            StringBuilder builder = validacoes.validaUsuario(usuario);
            try
            {
                if (builder.Length != 0) { return builder.ToString(); }
            }
            catch (Exception)
            {
                try
                {
                    usuarioDAL.Update(usuario);
                    return "Atualizado com sucesso!";
                }
                catch (Exception)
                {
                    return "Erro na atualização.";
                }
            }
            return null;
        }
        public string inseriUsuario(Usuario user)
        {
            ValidacoesBLL validacoes = new ValidacoesBLL();
            StringBuilder builder = validacoes.validaUsuario(user);
            try
            {
                if (builder.Length != 0) { return builder.ToString(); }
            }
            catch (Exception)
            {
                try
                {
                    usuarioDAL.Insert(user);
                    return "Conta criada com sucesso!";
                }
                catch (Exception)
                {
                    return "Erro no cadastro";
                }
            }
            return null;


        }
        public Usuario selecionarPorID(int ID)
        {
            SqlWhereUsuario where = new SqlWhereUsuario();
            SqlCommand comando = where.selecionarPorID(ID);
            List<Usuario> lista = usuarioDAL.GetALL(comando);
            Usuario retorno = new Usuario();
            foreach (Usuario item in lista)
            {
                retorno.ID = item.ID;
                retorno.Nome = item.Nome;
                retorno.Sobrenome = item.Sobrenome;
                retorno.Senha = item.Senha;
                retorno.Localizacao = item.Localizacao;
                retorno.Email = item.Email;
                retorno.ListaFavoritos = item.ListaFavoritos;
                retorno.UltimaLista = item.UltimaLista;
                return retorno;
            }
            return null;
        }

    }
}
