using DataAccessLayer;
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
    public class LoginBLL
    {
        public object verificaLogin(string login, string senha)
        {
            //objetos
            List<Usuario> usuario = new List<Usuario>();
            List<Supermercado> supermercado = new List<Supermercado>();

            SqlWhereSupermercado wheres = new SqlWhereSupermercado();
            SqlWhereUsuario where = new SqlWhereUsuario();
            UsuarioDAL usuariodal = new UsuarioDAL();
            SupermercadoDAL supermercadodal = new SupermercadoDAL();
            try
            {
                SqlCommand comando = where.verificaLoginUsuario(login, senha);
                usuario = usuariodal.GetALL(comando);
                if (usuario.Count <= 0)
                    throw new Exception();
            }
            catch (Exception)
            {
                try
                {
                    SqlCommand comando = wheres.verificaLoginSupermercado(login, senha);
                    supermercado = supermercadodal.GetALL(comando);

                }
                catch (Exception)
                {
                    //mensagem de login invalido
                    throw;
                }
            }
            //verificação de objeto
            try
            {
                if (usuario.Count > 0)
                {
                    Usuario usuarioReturn = new Usuario();
                    foreach (Usuario item in usuario)
                    {
                        usuarioReturn.ID = item.ID;
                        usuarioReturn.Nome = item.Nome;
                        usuarioReturn.Senha = item.Senha;
                        usuarioReturn.Sobrenome = item.Sobrenome;
                        usuarioReturn.UltimaLista = item.UltimaLista;
                        usuarioReturn.Localizacao = item.Localizacao;
                        ///
                        return usuarioReturn;
                    }
                }
            }
            catch (Exception)
            {
                Supermercado supermercadoReturn = new Supermercado();
                foreach (Supermercado item in supermercado)
                {
                    supermercadoReturn.ID = item.ID;
                    return supermercadoReturn;
                }

            }


            return null;
        }
    }
}
