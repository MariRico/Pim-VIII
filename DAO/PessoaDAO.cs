using PimVIII.Entidade;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace PimVIII.DAO
{
    public class PessoaDAO
    {
        string strConnection = ConfigurationManager.ConnectionStrings["CharityManagement"].ConnectionString;
        public bool exclua(Pessoa p)
        {
            SqlConnection conexao = new(strConnection);
            conexao.Open(); // abre a conexão com o banco
            int nlinhas = 0;

            using (SqlCommand cmd = new SqlCommand($"DELETE PESSOA_TELEFONE " +
                $"WHERE ID_PESSOA in (select id from pessoa where pessoa.cpf = '{p.cpf}');", conexao))
                nlinhas = cmd.ExecuteNonQuery();

            using (SqlCommand cmd = new SqlCommand($"DELETE PESSOA WHERE CPF = {p.cpf};", conexao))
                nlinhas = cmd.ExecuteNonQuery();
                
            conexao.Close();
            return (nlinhas == 1);
        }

        public bool insira(Pessoa pessoa)
        {
            SqlConnection conexao = new(strConnection);
            conexao.Open(); // abre a conexão com o banco
            int nlinhas = 0, idEndereco = 0;

            idEndereco = InserirEndereco(pessoa);

            using (SqlCommand cmd = new SqlCommand($"INSERT INTO PESSOA( CPF, ENDERECO, NOME) VALUES({pessoa.cpf},{idEndereco},'{pessoa.nome}');", conexao))
                nlinhas = cmd.ExecuteNonQuery(); // executa cmd

            int idPessoa = 0;
            using (SqlCommand cmd = new SqlCommand($"SELECT max(id) FROM PESSOA", conexao))
                idPessoa = Convert.ToInt32(cmd.ExecuteScalar());

            // Inserindo ou não o telefone
            InserirTelefone(pessoa, idPessoa);


            conexao.Close();
            return (nlinhas == 1);
        }

        private static void InserirTelefone(Pessoa pessoa, int idPessoa)
        {
            TelefoneDAO telefoneDAO = new();
            foreach (var item in pessoa.telefones)
            {
                int idTelefone = 0;
                do
                {
                    idTelefone = telefoneDAO.getIdTelefone(item);
                    if (idTelefone != 0)
                        telefoneDAO.insira(idPessoa, item);
                }
                while (idTelefone == 0);
            }
        }

        private static int InserirEndereco(Pessoa pessoa)
        {
            int idEndereco;
            EnderecoDAO enderecoDAO = new();
            do
            {
                idEndereco = enderecoDAO.getId(pessoa.endereco);
                // Se nao tiver o registro então vamos inserir no banco de dados antes
                if (idEndereco == 0)
                    enderecoDAO.insira(pessoa.endereco);
            }
            while (idEndereco == 0);
            return idEndereco;
        }

        public bool altere(Pessoa pessoa)
        {
            int nlinhas = 0, idEndereco = 0;
            bool retorno = false;
            SqlConnection conexao = new(strConnection);
            conexao.Open();

            EnderecoDAO enderecoDAO = new();
            while (idEndereco == 0)
            {
                idEndereco = enderecoDAO.getId(pessoa.endereco);
                // Se nao tiver o registro então vamos inserir no banco de dados antes
                if (idEndereco == 0)
                    enderecoDAO.insira(pessoa.endereco);
            }

            using (SqlCommand cmd = new SqlCommand(@$"
UPDATE PESSOA
   SET ENDERECO = {idEndereco}, 
       NOME = '{pessoa.nome}'
 WHERE Cpf = '{pessoa.cpf}';", conexao))
                nlinhas = cmd.ExecuteNonQuery(); // executa cmd

            conexao.Close();
            return (nlinhas == 1);
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
                    pessoa = new(Convert.ToInt32(dr["id"]));
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
