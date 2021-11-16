using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using PimVIII.Entidade;

namespace PimVIII.DAO
{
    internal class EnderecoDAO
    {
        private SqlConnection conexao;
        protected internal EnderecoDAO(SqlConnection pConexao)
        {
            conexao = pConexao;
        }
        public Endereco consulte(int intEndereco)
        {
            Endereco endereco = null;
            SqlCommand cmd = new SqlCommand("SELECT * FROM ENDERECO WHERE id = " + intEndereco, conexao);
            using (var dr = cmd.ExecuteReader())
            {
                if (dr.HasRows && dr.Read())
                {
                    endereco.bairro = dr["bairro"].ToString();
                    endereco.cep = Convert.ToInt32(dr["cep"]);
                    endereco.cidade = dr["cidade"].ToString();
                    endereco.estado = dr["estado"].ToString();
                    endereco.logradouro = dr["logradouro"].ToString();
                    endereco.numero = Convert.ToInt32(dr["numero"]);
                }
            }
            return endereco;
        }

        internal int getId(Endereco endereco)
        {
            int retorno = 0;
            SqlCommand cmd = new SqlCommand($@"
SELECT id 
  FROM ENDERECO 
 WHERE bairro = '{endereco.bairro}
   and cep = '{endereco.cep}'
   and cidade = '{endereco.cidade}'
   and estado = '{endereco.estado}'
   and logradouro = '{endereco.logradouro}'
   and numero = '{endereco.numero}'", conexao);
            using (var dr = cmd.ExecuteReader())
            {
                if (dr.HasRows && dr.Read())
                {
                    retorno = Convert.ToInt32(dr[0]);
                }
            }
            return retorno;
        }
    }
}
