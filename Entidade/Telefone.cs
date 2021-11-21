
namespace PimVIII.Entidade
{
    public class Telefone
    {
        public Telefone() { }
        public Telefone(int pId) => id = pId;
        protected int id { get; set; }
        public int numero { get; set; }
        public int ddd { get; set; }
        public TipoTelefone tipo { get; set; }
    }
}
