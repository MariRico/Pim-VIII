using PimVIII.Entidade;
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

            using (SqlCommand cmd = new SqlCommand("INSERT INTO PESSOA( ID, CPF, ENDERECO, NOME) VALUES(2,21521795878,1,'Teste2');", conexao))
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
                //pessoa.endereco = dr["endereco"]
            }
            return pessoa;
        }
    }
}
