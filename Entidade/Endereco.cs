
namespace PimVIII.Entidade
{
    public class Endereco
    {
        public Endereco() { }
        public Endereco(int pId) => id = pId;
        protected int id { get; set; }
        public string logradouro { get; set; }
        public int numero { get; set; }
        public int cep { get; set; }
        public string bairro { get; set; }
        public string cidade { get; set; }
        public string estado { get; set; }
    }
}
