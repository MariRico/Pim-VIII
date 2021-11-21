
namespace PimVIII.Entidade
{
    public class TipoTelefone
    {
        public TipoTelefone() { }
        public TipoTelefone(int pId) => id = pId;
        protected int id { get; set; }
        public string tipo { get; set; }
    }
}
