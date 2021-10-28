using PimVIII.DAO;
using System;

namespace Teste
{
    class Program
    {
        static void Main(string[] args)
        {
            PessoaDAO pessoaDAO = new PessoaDAO();
            pessoaDAO.insira(null);
        }
    }
}
