using PimVIII.Entidade;
using System;
using System.Data;
using System.Data.SqlClient;


namespace PimVIII.DAO
{
    public class PessoaDAO
    {
        private SqlConnection conexao = new SqlConnection("Data Source=LAPTOP-SELTI3K7\\LOCAL1;Initial Catalog=PIM_VIII;User ID=sa;Password=123");

        public bool exclua(Pessoa p)
        {
            bool retorno = false;
            // Coloque o código aqui

            return retorno;
        }

        public bool insira(Pessoa p)
        {
            bool retorno = false;
            // Coloque o código aqui

            using (SqlCommand cmd = new SqlCommand($"INSERT INTO PESSOA( CPF, ENDERECO, NOME) VALUES({p.cpf},{p.endereco},'{p.nome}');", conexao))
            {
                conexao.Open(); // abre a conexão com o banco
                cmd.ExecuteNonQuery(); // executa cmd
                conexao.Close();
            }
            return retorno;
        }

        public bool altere(Pessoa p)
        {
            bool retorno = false;
            // Coloque o código aqui

            return retorno;
        }

        public Pessoa consulte(long cpf)
        {
            Pessoa pessoa = null;
            SqlCommand cmd = new SqlCommand("SELECT * FROM PESSOA WHERE CPF = " + cpf, conexao);
            using (var dr = cmd.ExecuteReader())
            {
                if (dr.HasRows && dr.Read())
                {
                    EnderecoDAO enderecoDAO = new(conexao);

                    pessoa.endereco = enderecoDAO.consulte(Convert.ToInt32(dr["endereco"]));
                    pessoa.cpf = Convert.ToInt64(dr["endereco"]);
                    pessoa.nome = dr["nome"].ToString();
                    pessoa.telefones = null;
                }
            }
            return pessoa;
        }

        private class EnderecoDAO
        {
            private SqlConnection conexao;
            EnderecoDAO(SqlConnection pConexao)
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
        }
    }
}
