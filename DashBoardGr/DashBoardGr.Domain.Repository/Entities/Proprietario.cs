namespace DashBoardGr.Domain.Repository.Entities
{
    public class Proprietario
    {
        public Proprietario(
            string cpfCnpj,
            string nome, 
            string cep,
            string codigoCidade, 
            string nomeCidade, 
            string rua,
            string? complemento,
            string bairro, 
            string estado,
            string telefone)
        {
            Id = Guid.NewGuid();
            CpfCnpj = cpfCnpj;
            Nome = nome;
            Cep = cep;
            CodigoCidade = codigoCidade;
            NomeCidade = nomeCidade;
            Rua = rua;
            Complemento = complemento;
            Bairro = bairro;
            Estado = estado;
            Telefone = telefone;

        }

        public Guid Id { get; set; }
        public string CpfCnpj { get; private set; } 
        public string Nome { get; private set; } 
        public string Cep { get; private set; } 
        public string CodigoCidade { get; private set; } 
        public string NomeCidade { get; private set; } 
        public string Rua { get; private set; } 
        public string Numero { get; private set; } 
        public string? Complemento { get; private set; } 
        public string Bairro { get; private set; } 
        public string Estado { get; private set; } 
        public string Telefone { get; private set; } 

        public virtual ICollection<Veiculo> Veiculos { get; set; } = new HashSet<Veiculo>();
    }
}
