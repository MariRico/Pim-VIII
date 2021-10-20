using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PimVIII.Entidade
{
    public class Pessoa
    {
        protected int id { get; set; }
        public string nome { get; set; }
        public long cpf { get; set; }
        public Endereco endereco { get; set; }
        public Telefone[] telefones { get; set; }

    }
}
