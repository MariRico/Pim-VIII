using System;
using System.Data.SqlClient;
using PimVIII.Entidade;
using System.Configuration;

namespace PimVIII.Entidade
{
    internal class TelefoneDAO
    {
        string strConnection = ConfigurationManager.ConnectionStrings["CharityManagement"].ConnectionString;

        internal int getIdTelefone(Telefone telefone)
        {
            int retorno = 0;
            SqlConnection conexao = new(strConnection);
            conexao.Open();
            SqlCommand cmd = new SqlCommand($@"
SELECT id 
  FROM TELEFONE 
 WHERE numero = {telefone.numero}
   and tipo = {getIdTipoTelefone(telefone.tipo)}
   and DDD = {telefone.ddd}", conexao);
            using (var dr = cmd.ExecuteReader())
                if (dr.HasRows && dr.Read())
                    retorno = Convert.ToInt32(dr[0]);

            conexao.Close();
            return retorno;
        }

        internal int getIdTipoTelefone(TipoTelefone tipoTelefone)
        {
            int retorno = 0;
            SqlConnection conexao = new(strConnection);
            conexao.Open();
            SqlCommand cmd = new SqlCommand($@"
SELECT id 
  FROM TELEFONE_TIPO 
 WHERE TIPO = '{tipoTelefone.tipo}'", conexao);
            using (var dr = cmd.ExecuteReader())
                if (dr.HasRows && dr.Read())
                    retorno = Convert.ToInt32(dr[0]);

            conexao.Close();
            return retorno;
        }

        public bool insira(int IdPessoa, Telefone telefone)
        {
            int nlinhas = 0;
            SqlConnection conexao = new(strConnection);
            conexao.Open();
            using (SqlCommand cmd = new SqlCommand(@$"
INSERT INTO PESSOA_TELEFONE (
            ID_PESSOA,
            ID_TELEFONE)
     VALUES({IdPessoa}, 
            {getIdTelefone(telefone)});", conexao))
                nlinhas = cmd.ExecuteNonQuery(); // executa cmd
            conexao.Close();
            return (nlinhas == 1);
        }

        public Telefone consultarTelefone(int idTelefone)
        {
            Telefone retorno = null;
            SqlConnection conexao = new(strConnection);
            conexao.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM TELEFONE WHERE id = " + idTelefone, conexao);
            using (var dr = cmd.ExecuteReader())
            {
                if (dr.HasRows && dr.Read())
                {
                    retorno = new(idTelefone);
                    retorno.ddd = Convert.ToInt32(dr["ddd"]);
                    retorno.numero = Convert.ToInt32(dr["numero"]);
                    retorno.tipo = consultarTipoTelefone(Convert.ToInt32(dr["tipo"]));
                }
            }
            conexao.Close();
            return retorno;
        }

        public TipoTelefone consultarTipoTelefone(int idTipoTelefone)
        {
            TipoTelefone retorno = null;
            SqlConnection conexao = new(strConnection);
            conexao.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM TELEFONE_TIPO WHERE id = " + idTipoTelefone, conexao);
            using (var dr = cmd.ExecuteReader())
            {
                if (dr.HasRows && dr.Read())
                {
                    retorno = new(idTipoTelefone);
                    retorno.tipo = dr["ddd"].ToString();
                }
            }
            conexao.Close();
            return retorno;
        }

    }
}
