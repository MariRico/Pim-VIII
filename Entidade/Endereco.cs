using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PimVIII.Entidade
{
    public class Endereco
    {
        protected int id { get; set; }
        public string logradouro { get; set; }
        public int numero { get; set; }
        public int cep { get; set; }
        public string bairro { get; set; }
        public string cidade { get; set; }
        public string estado { get; set; }
    }
}
