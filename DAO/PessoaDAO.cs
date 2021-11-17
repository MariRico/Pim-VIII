using PimVIII.Entidade;
using System;
using System.Data;
using System.Data.SqlClient;


namespace PimVIII.DAO
{
    public class PessoaDAO
    {
        string strConnection = "Data Source=LAPTOP-SELTI3K7\\LOCAL1;Initial Catalog=PIM_VIII;User ID=sa;Password=123";
        public bool exclua(Pessoa p)
        {
            SqlConnection conexao = new(strConnection);
            conexao.Open(); // abre a conexão com o banco
            int nlinhas = 0;
            using (SqlCommand cmd = new SqlCommand($"DELETE PESSOA WHERE CPF = {p.cpf};", conexao))
                nlinhas = cmd.ExecuteNonQuery(); // executa cmd
                
            conexao.Close();
            return (nlinhas == 1);
        }

        public bool insira(Pessoa p)
        {
            SqlConnection conexao = new(strConnection);
            conexao.Open(); // abre a conexão com o banco
            int nlinhas = 0, idEndereco = 0;
            
            EnderecoDAO enderecoDAO = new();
            while (idEndereco == 0)
            {
                idEndereco = enderecoDAO.getId(p.endereco);
                // Se nao tiver o registro então vamos inserir no banco de dados antes
                if(idEndereco == 0)
                    enderecoDAO.insira(p.endereco);
            }

            using (SqlCommand cmd = new SqlCommand($"INSERT INTO PESSOA( CPF, ENDERECO, NOME) VALUES({p.cpf},{idEndereco},'{p.nome}');", conexao))
                nlinhas = cmd.ExecuteNonQuery(); // executa cmd
            
            conexao.Close();
            return (nlinhas == 1);
        }

        public bool altere(Pessoa pessoa)
        {
            bool retorno = false;
            

            return retorno;
        }

        public Pessoa consulte(long cpf)
        {
            Pessoa pessoa = null;
            SqlConnection conexao = new(strConnection);
            conexao.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM PESSOA WHERE CPF = " + cpf, conexao);
            using (var dr = cmd.ExecuteReader())
            {
                
                if (dr.HasRows && dr.Read())
                {
                    pessoa = new();
                    EnderecoDAO enderecoDAO = new();

                    pessoa.endereco = enderecoDAO.consulte(Convert.ToInt32(dr["endereco"]));
                    pessoa.cpf = Convert.ToInt64(dr["cpf"]);
                    pessoa.nome = dr["nome"].ToString();
                    pessoa.telefones = null;
                }
            }
            conexao.Close();
            return pessoa;
        }
    }
}
