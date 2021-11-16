using PimVIII.DAO;
using PimVIII.Entidade;
using System;

namespace Teste
{
    class Program
    {
        static void Main(string[] args)
        {
            Endereco endereco = new Endereco {  }
            Pessoa pessoa = new Pessoa { cpf = 123456, };
            PessoaDAO pessoaDAO = new PessoaDAO();
            pessoaDAO.insira(null);
        }
    }
}
