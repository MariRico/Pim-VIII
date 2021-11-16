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
            using (SqlCommand cmd = new SqlCommand($"DELETE PESSOA WHERE CPF = {p.cpf};", conexao))
            {
                conexao.Open(); // abre a conexão com o banco
                cmd.ExecuteNonQuery(); // executa cmd
                conexao.Close();
            }
            return retorno;
        }

        public bool insira(Pessoa p)
        {
            bool retorno = false;
            int id = new EnderecoDAO(conexao).getId(p.endereco);
            using (SqlCommand cmd = new SqlCommand($"INSERT INTO PESSOA( CPF, ENDERECO, NOME) VALUES({p.cpf},{id},'{p.nome}');", conexao))
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
    }
}
