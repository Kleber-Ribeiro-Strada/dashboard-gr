using AutoMapper;
using DashBoardGr.Domain.Application.Queries.BuscarAnalisesGraficoBarras;
using DashBoardGr.Domain.Application.Queries.BuscarAnalisesGraficoLinha;
using DashBoardGr.Domain.Application.Queries.BuscarAnalisesGraficoPizza;
using DashBoardGr.Domain.Repository.Dtos;

namespace DashBoardGr.Domain.Application.Profiles
{
    public class GraficoProfile: Profile
    {
        public GraficoProfile()
        {
            CreateMap<GraficoGeralDto, BuscarAnalisesGraficoPizzaViewModel>();
            CreateMap<GraficoGeralDto.DadosGraficosDto, BuscarAnalisesGraficoPizzaViewModel.DadosGraficos>();

            CreateMap<GraficoGeralDto, BuscarAnalisesGraficoLinhaViewModel>();
            CreateMap<GraficoGeralDto.DadosGraficosDto, BuscarAnalisesGraficoLinhaViewModel.DadosGraficos>();

            CreateMap<GraficoGeralDto, BuscarAnalisesGraficoBarrasViewModel>();
            CreateMap<GraficoGeralDto.DadosGraficosDto, BuscarAnalisesGraficoBarrasViewModel.DadosGraficos>();
        }
    }
}
