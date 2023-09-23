using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DashBoardGr.Domain.Application.Queries.BuscarAnalisesGraficoBarras
{
    public  class BuscarAnalisesGraficoBarrasViewModel
    {
        public List<string> Labels { get; set; } = new();

        public List<DadosGraficos> Datasets { get; set; } = new();

        public class DadosGraficos
        {
            public List<int> Data { get; set; } = new();

            public string Label { get; set; } = string.Empty;
        }
    }
}
