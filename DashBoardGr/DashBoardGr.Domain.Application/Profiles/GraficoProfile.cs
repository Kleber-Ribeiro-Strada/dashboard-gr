using AutoMapper;
using DashBoardGr.Domain.Application.Queries.BuscarAnalisesGraficoBarras;
using DashBoardGr.Domain.Repository.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DashBoardGr.Domain.Application.Profiles
{
    public class GraficoProfile: Profile
    {
        public GraficoProfile()
        {
            CreateMap<GraficoGeralDto, BuscarAnalisesGraficoPizzaViewModel>();

            CreateMap<GraficoGeralDto.DadosGraficosDto, BuscarAnalisesGraficoPizzaViewModel.DadosGraficos>();
        }
    }
}
