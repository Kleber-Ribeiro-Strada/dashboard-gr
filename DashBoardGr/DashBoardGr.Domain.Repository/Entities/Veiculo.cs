﻿namespace DashBoardGr.Domain.Repository.Entities
{
    public class Veiculo
    {
        public Veiculo(
            string tipo, 
            string placa,
            string chassi,
            string renavam, 
            string rntrc,
            DateTime dataLicenciamento,
            string cor,
            string marca,
            string modelo,
            int anoFabricacao,
            int anoModelo,
            string estado,
            string codigoCidade,
            string imagemCrlv, 
            Guid proprietarioId)
        {
            Id = Guid.NewGuid();
            Tipo = tipo;
            Placa = placa;
            Chassi = chassi;
            Renavam = renavam;
            Rntrc = rntrc;
            DataLicenciamento = dataLicenciamento;
            Cor = cor;
            Marca = marca;
            Modelo = modelo;
            AnoFabricacao = anoFabricacao;
            AnoModelo = anoModelo;
            Estado = estado;
            CodigoCidade = codigoCidade;
            ImagemCrlv = imagemCrlv;
            ProprietarioId = proprietarioId;
        }

        public Guid Id { get; set; }
        public string Tipo { get; set; }
        public string Placa { get; set; }
        public string Chassi { get; set; }
        public string Renavam { get; set; }
        public string Rntrc { get; set; }
        public DateTime DataLicenciamento { get; set; }
        public string Cor { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public int AnoFabricacao { get; set; }
        public int AnoModelo { get; set; } 
        public string Estado { get; set; }
        public string CodigoCidade { get; set; }
        public string ImagemCrlv { get; set; }

        public Guid ProprietarioId { get; set; }
        public virtual Proprietario Proprietario { get; set; } = null!;

        public virtual ICollection<AnaliseRiscoVeiculo> AnaliseRiscoVeiculos { get; set; } = null!;


    }
}