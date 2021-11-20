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
            Pessoa pessoaConsulte = pessoaDAO.consulte(pessoa.cpf);
            if(pessoaConsulte.cpf == pessoa.cpf && pessoaConsulte.nome == pessoa.nome)
                Console.WriteLine($@"O cpf {pessoa.cpf} foi inserido no banco de dados.");

            pessoa.nome = "Teste alteração";
            pessoaDAO.altere(pessoa);
            pessoaConsulte = pessoaDAO.consulte(pessoa.cpf);
            if (pessoaConsulte.cpf == pessoa.cpf && pessoaConsulte.nome == pessoa.nome)
                Console.WriteLine($@"A pessoa mudou de nome de Maria Paula de Coelho Neto Júnior para {pessoaConsulte.nome}.");

            pessoaDAO.exclua(pessoa);
            Pessoa pessoaConsulteExcluido = pessoaDAO.consulte(pessoa.cpf);
            if(pessoaConsulteExcluido == null)
                Console.WriteLine($@"A pessoa {pessoa.nome} foi excluida do banco de dados.");
        }
    }
}
