using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PimVIII.Entidade
{
    public class Telefone
    {
        protected int id { get; set; }
        public int numero { get; set; }
        public int ddd { get; set; }
        public TipoTelefone tipo { get; set; }
    }
}
