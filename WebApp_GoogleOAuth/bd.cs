using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebApp_GoogleOAuth
{
    public class bd
    {
        string strligacao;
        SqlConnection ligacaoBD;

        public bd()
        {
            strligacao = ConfigurationManager.ConnectionStrings["sql"].ToString();
            ligacaoBD = new SqlConnection(strligacao);
            try
            {
                ligacaoBD.Open();
            }
            catch (Exception erro)
            {
                Console.Write(erro.Message);

            }
        }

        ~bd()
        {
            try
            {
                ligacaoBD.Close();
                ligacaoBD.Dispose();
            }
            catch (Exception erro)
            {
                Console.Write(erro.Message);
            }
        }
        //consultas
        public DataTable devolveconsulta(string sql)
        {

            SqlCommand comando = new SqlCommand(sql, ligacaoBD);
            DataTable registos = new DataTable();


            SqlDataReader dados = comando.ExecuteReader();
            registos.Load(dados);
            comando.Dispose();
            return registos;

        }

        public DataTable devolveconsulta(string sql, List<SqlParameter> parametros)
        {

            SqlCommand comando = new SqlCommand(sql, ligacaoBD);
            comando.Parameters.AddRange(parametros.ToArray());
            DataTable registos = new DataTable();


            SqlDataReader dados = comando.ExecuteReader();
            registos.Load(dados);
            comando.Dispose();
            return registos;

        }
        public bool executacomando(string sql)
        {
            try
            {
                SqlCommand comando = new SqlCommand(sql, ligacaoBD);
                comando.ExecuteNonQuery();
                comando.Dispose();
            }
            catch (Exception erro)
            {
                Console.Write(erro.Message);
                return false;
            }
            return true;
        }

        public bool executacomando(string sql, List<SqlParameter> parametros)
        {

            try
            {
                SqlCommand comando = new SqlCommand(sql, ligacaoBD);
                comando.Parameters.AddRange(parametros.ToArray());
                comando.ExecuteNonQuery();
                comando.Dispose();
            }
            catch (Exception erro)
            {
                Console.Write(erro.Message);
                return false;
            }
            return true;
        }
    }
}