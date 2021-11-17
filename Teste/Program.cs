using PimVIII.DAO;
using PimVIII.Entidade;
using System;

namespace Teste
{
    class Program
    {
        static void Main(string[] args)
        {
            Endereco endereco = new Endereco { logradouro = "Rua Girassol", numero = 400, cep = 13087420, bairro = "Chácara Primavera", cidade = "Campinas", estado = "SP" };
            Pessoa pessoa = new Pessoa { cpf = 123456,endereco = endereco, nome = "Maria Paula de Coelho Neto Júnior" };
            PessoaDAO pessoaDAO = new PessoaDAO();
            pessoaDAO.insira(pessoa);

            pessoaDAO.exclua(pessoa);
        }
    }
}
