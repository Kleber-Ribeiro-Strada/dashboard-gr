using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DashBoardGr.Domain.Repository.Dtos
{
    public class GraficoGeralDto
    {
        public List<string> Labels { get; set; } = new();

        public List<DadosGraficosDto> Datasets { get; set; } = new();

        public class DadosGraficosDto
        {
            public List<int> Data { get; set; } = new();

            public string Label { get; set; } = string.Empty;
        }
    }
}
