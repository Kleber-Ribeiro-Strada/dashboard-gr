namespace DashBoardGr.Domain.Repository.Entities
{
    public class Proprietario
    {
        public Proprietario()
        {

        }

        public Guid Id { get; set; }
        public string CpfCnpj { get; private set; } = string.Empty;
        public string Nome { get; private set; } = string.Empty;
        public string Cep { get; private set; } = string.Empty;
        public string CodigoCidade { get; private set; } = string.Empty;
        public string NomeCidade { get; private set; } = string.Empty;
        public string Rua { get; private set; } = string.Empty;
        public string Numero { get; private set; } = string.Empty;
        public string Complemento { get; private set; } = string.Empty;
        public string Bairro { get; private set; } = string.Empty;
        public string Estado { get; private set; } = string.Empty;
        public string Telefone { get; private set; } = string.Empty;

        public virtual ICollection<Veiculo> Veiculos { get; set; } = new HashSet<Veiculo>();
    }
}
