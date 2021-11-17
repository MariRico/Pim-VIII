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
            if (pessoaDAO.insira(pessoa))
                Console.WriteLine($@"A pessoa {pessoa.nome} foi inserida pelo sistema.");

            Pessoa pessoaConsulte = pessoaDAO.consulte(pessoa.cpf);
            if(pessoaConsulte.cpf == pessoa.cpf)
                Console.WriteLine($@"O cpf {pessoa.cpf} foi inserido no banco de dados.");

            if (pessoaDAO.exclua(pessoa))
                Console.WriteLine($@"A pessoa {pessoa.nome} foi excluida pelo sistema.");

            Pessoa pessoaConsulteExcluido = pessoaDAO.consulte(pessoa.cpf);
            if(pessoaConsulteExcluido == null)
                Console.WriteLine($@"A pessoa {pessoa.nome} foi excluida do banco de dados.");
        }
    }
}
