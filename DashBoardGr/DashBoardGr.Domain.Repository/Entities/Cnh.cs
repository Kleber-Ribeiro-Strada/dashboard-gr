namespace DashBoardGr.Domain.Repository.Entities
{
    public class Cnh
    {
        public Cnh(
            Guid motoristaId
            , string numero
            , string? estadoEmissao
            , DateTime dataVencimento
            , string categoria
            , string? codigoCidade
            , string? codigoSeguranca
            , DateTime? dataPrimeiraHabilitacao
            , string? imagem)
        {
            MotoristaId = motoristaId;
            Numero = numero;
            EstadoEmissao = estadoEmissao;
            DataVencimento = dataVencimento;
            Categoria = categoria;
            CodigoCidade = codigoCidade;
            CodigoSeguranca = codigoSeguranca;
            DataPrimeiraHabilitacao = dataPrimeiraHabilitacao;
            Imagem = imagem;
        }
        public Guid Id { get; private set; }
        public string Numero { get; private set; } = string.Empty;
        public string? EstadoEmissao { get; private set; }
        public DateTime DataVencimento { get; private set; }
        public string Categoria { get; private set; } = string.Empty;
        public string? CodigoCidade { get; private set; }
        public string? CodigoSeguranca { get; private set; }
        public DateTime? DataPrimeiraHabilitacao { get; private set; }
        public string? Imagem { get; private set; }

        public Guid MotoristaId { get; set; }
        public Motorista Motorista { get; set; } 
    }
}
