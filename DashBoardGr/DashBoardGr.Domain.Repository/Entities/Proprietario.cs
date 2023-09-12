using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DashBoardGr.Domain.Repository.Entities
{
    public class Proprietario
    {
        public Guid Id { get; set; }
        public string CpfCnpj { get; private set; } = string.Empty;
        public string Nome { get; private set; } = string.Empty;
        public string Cep { get; private set; } = string.Empty;
        public string? CodigoCidade { get; private set; }
        public string? NomeCidade { get; private set; }
        public string? Rua { get; private set; }
        public string Numero { get; private set; } = string.Empty;
        public string? Complemento { get; private set; }
        public string? Bairro { get; private set; }
        public string? Estado { get; private set; }
        public string Telefone { get; private set; } = string.Empty;

        public ICollection<Veiculo> Veiculos { get; set; }
    }
}
