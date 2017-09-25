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
    class ValidacoesBLL
    {

        public StringBuilder validaSupermercado(Supermercado supermercado)
        {
            Boolean emailindisponivel = verificaDisponibilidadeDeEmailSupermercado(supermercado.Email);
            Boolean indisponivel = verificaDisponibilidadeDeCNPJ(supermercado.CNPJ);
            StringBuilder erros = new StringBuilder();
            if (indisponivel) { erros.AppendLine("CNPJ Já está em uso."); }
            if (emailindisponivel) { erros.AppendLine("Email já está em uso."); }
            if (string.IsNullOrEmpty(supermercado.Nome))
            {
                erros.AppendLine("Digite o Nome.");
            }
            else
            {
                if (supermercado.Nome.Length < 3)
                {
                    erros.AppendLine("Nome inválido.");
                }
            }
            if (string.IsNullOrEmpty(supermercado.RazaoSocial))
            {
                erros.AppendLine("Digite a razão social.");
            }
            if (string.IsNullOrEmpty(supermercado.CNPJ))
            {
                erros.AppendLine("Digite o CNPJ.");
            }
            else
            {
                Boolean valido = validaCNPJ(supermercado.CNPJ);
                if (valido == false)
                {
                    erros.AppendLine("CNPJ inválido.");
                }
            }
            if (string.IsNullOrEmpty(supermercado.Endereco))
            {
                erros.AppendLine("Digite o bairro.");
            }
            if (string.IsNullOrEmpty(supermercado.Telefone))
            {
                erros.AppendLine("Digite o Telefone.");
            }
            else
            {
                if (supermercado.Telefone.Length < 8)
                {
                    erros.AppendLine("Telefone inválido.");
                }
            }
            if (string.IsNullOrEmpty(supermercado.Email))
            {
                erros.AppendLine("Digite o email.");
            }
            else
            {
                Boolean valido = validaEmail(supermercado.Email);
                if (valido == false)
                {
                    erros.AppendLine("Email inválido.");
                }
            }
            if (string.IsNullOrEmpty(supermercado.Senha))
            {
                erros.AppendLine("Digite a senha.");
            }
            else
            {
                if (supermercado.Senha.Length < 4)
                {
                    erros.AppendLine("A senha deve conter no mínimo 4 carácteres.");
                }
            }

            if (erros.Length == 0)
            {
                return null;
            }
            else
            {
                return erros;
            }
        }
        public StringBuilder validaUsuario(Usuario user)
        {
            Boolean indisponivel = verificaDisponibilidadeDeEmail(user.Email);
            StringBuilder erros = new StringBuilder();
            if (indisponivel) { erros.AppendLine("Email já está em uso."); }
            if (string.IsNullOrEmpty(user.Nome))
            {
                erros.AppendLine("Digite o nome.");

            }
            else
            {
                if (user.Nome.Length < 3)
                {
                    erros.AppendLine("Nome deve conter no mínimo 3 dígitos.");
                }
            }
            if (string.IsNullOrEmpty(user.Sobrenome))
            {
                erros.AppendLine("Digite o sobrenome.");

            }
            else
            {
                if (user.Sobrenome.Length < 3)
                {
                    erros.AppendLine("Sobrenome deve conter no mínimo 3 dígitos.");
                }
            }
            if (string.IsNullOrEmpty(user.Senha))
            {
                erros.AppendLine("Digite a senha.");
            }
            else
            {
                if (user.Senha.Length < 4)
                {
                    erros.AppendLine("Senha deve conter no mínimo 4 dígitos.");
                }
            }
            if (string.IsNullOrEmpty(user.Email))
            {
                erros.AppendLine("Digite o email.");
            }
            else
            {
                Boolean emailvalido = validaEmail(user.Email);
                if (emailvalido == false)
                {
                    erros.AppendLine("Email inválido");
                }
            }
            if (erros.Length == 0)
            {
                return null;
            }
            else
            {
                return erros;
            }
        }

        public Boolean validaEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public Boolean validaCNPJ(string cnpj)
        {

            Int32[] digitos, soma, resultado;

            Int32 nrDig;

            String ftmt;

            Boolean[] cnpjOk;

            cnpj = cnpj.Replace("/", "");

            cnpj = cnpj.Replace(".", "");

            cnpj = cnpj.Replace("-", "");

            if (cnpj == "00000000000000")
            {

                return false;

            }

            ftmt = "6543298765432";

            digitos = new Int32[14];

            soma = new Int32[2];

            soma[0] = 0;

            soma[1] = 0;

            resultado = new Int32[2];

            resultado[0] = 0;

            resultado[1] = 0;

            cnpjOk = new Boolean[2];

            cnpjOk[0] = false;

            cnpjOk[1] = false;

            try
            {

                for (nrDig = 0; nrDig < 14; nrDig++)
                {

                    digitos[nrDig] = int.Parse(cnpj.Substring(nrDig, 1));

                    if (nrDig <= 11)

                        soma[0] += (digitos[nrDig] *

                        int.Parse(ftmt.Substring(nrDig + 1, 1)));

                    if (nrDig <= 12)

                        soma[1] += (digitos[nrDig] *

                        int.Parse(ftmt.Substring(nrDig, 1)));

                }

                for (nrDig = 0; nrDig < 2; nrDig++)
                {

                    resultado[nrDig] = (soma[nrDig] % 11);

                    if ((resultado[nrDig] == 0) || (resultado[nrDig] == 1))

                        cnpjOk[nrDig] = (digitos[12 + nrDig] == 0);

                    else

                        cnpjOk[nrDig] = (digitos[12 + nrDig] == (

                        11 - resultado[nrDig]));

                }

                return true;

            }

            catch
            {

                return false;

            }
        }
        private Boolean verificaDisponibilidadeDeEmail(string email)
        {
            UsuarioDAL usuario = new UsuarioDAL();
            SqlWhereUsuario where = new SqlWhereUsuario();
            try
            {
                SqlCommand comando = where.selecionaSeExistirEmail(email);
                List<Usuario> usuarios = usuario.GetALL(comando);

                if (usuarios.Count <= 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }

        }
        private Boolean verificaDisponibilidadeDeEmailSupermercado(string email)
        {
            SupermercadoDAL usuario = new SupermercadoDAL();
            SqlWhereUsuario where = new SqlWhereUsuario();
            try
            {
                SqlCommand comando = where.selecionaSeExistirEmail(email);
                List<Supermercado> supermercados = usuario.GetALL(comando);

                if (supermercados.Count <= 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }

        }
        private Boolean verificaDisponibilidadeDeCNPJ(string cnpj)
        {

            SupermercadoDAL dal = new SupermercadoDAL();
            SqlWhereSupermercado where = new SqlWhereSupermercado();
            try
            {
                string cnpjaux = cnpj.Replace("/", "").Replace(".", "").Replace("-", "");
                SqlCommand comando = where.selecionaSeExistirCNPJ(cnpjaux);
                List<Supermercado> usuarios = dal.GetALL(comando);

                if (usuarios.Count <= 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }

        }
    }
}
