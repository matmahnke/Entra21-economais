using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DTO.Interfaces;
using DataAccessLayer.Infrastructure.Extensions;
using System.Data.SqlClient;
using System.Data;
using System.Xml.Serialization;
using System.IO;
using System.Xml;
using System.Xml.Linq;

namespace DataAccessLayer.Infrastructure
{
    public class SetorDAL : IProdutoSevice
    {
        public void DeleteXMLRow(Setor setor, SqlCommand where)
        {
            new DBExecuter().Execute(SqlXMLGenerator.BuildDeleteCommand(setor, where));
        }

        public void InsertXML(Setor setor)
        {
            new DBExecuter().Execute(SqlXMLGenerator.BuildInsertCommand(setor));

        }

        public List<Produto> SelectXML(SqlCommand Where)
        {

            List<Produto> lista = new List<Produto>();
            SqlCommand command = new SqlCommand();
            command.CommandText = "SELECT Produto FROM Setor ";
            command.CommandText += Where.CommandText;
            foreach (SqlParameter item in Where.Parameters)
            {
                command.Parameters.Add(new SqlParameter(item.ParameterName, item.Value));
            }

            List<string> xml = new DBExecuter().GetStringXML(command);

            //XmlSerializer serializer = new XmlSerializer(typeof(Produto));
            foreach (string item in xml)
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<Produto>));
                byte[] buffer = Encoding.UTF8.GetBytes(item);
                using (MemoryStream ms = new MemoryStream(buffer))
                {
                    lista.AddRange((List<Produto>)serializer.Deserialize(ms));
                }
            }
            return lista;
        }

        public void UpdateXML(Setor setor, SqlCommand where)
        {
            new DBExecuter().Execute(SqlXMLGenerator.BuildUpdateCommand(setor, where));
        }

        public List<string> SelectSetores(SqlCommand Where)
        {

            SqlCommand command = new SqlCommand();
            command.CommandText = "SELECT Nome FROM Setor ";
            command.CommandText += Where.CommandText;
            foreach (SqlParameter item in Where.Parameters)
            {
                command.Parameters.Add(new SqlParameter(item.ParameterName, item.Value));
            }
            List<string> lista = new DBExecuter().GetSetorString(command);

            //XmlSerializer serializer = new XmlSerializer(typeof(Produto));

            return lista;
        }

        public List<Produto> SelectXML(int codigoMercado, double p1, string p2)
        {
            List<Produto> lista = new List<Produto>();
            SqlCommand command = new SqlCommand();
            command.CommandText = "SELECT Produto FROM Setor where codigomercado = @cod ";
            command.Parameters.AddWithValue("@cod", codigoMercado);

            List<string> xml = new DBExecuter().GetStringXML(command);

            foreach (string item in xml)
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<Produto>));
                byte[] buffer = Encoding.UTF8.GetBytes(item);
                using (MemoryStream memory = new MemoryStream(buffer))
                {
                    List<Produto> produtos = (List<Produto>)serializer.Deserialize(memory);
                    foreach (var p in produtos)
                    {
                        if(p.Nome == p2 && p.Peso == p1)
                        {
                            lista.Add(p);
                        }
                    }
                }
            }
            return lista;
        }
    }
}
