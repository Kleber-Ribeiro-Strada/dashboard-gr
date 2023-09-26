using AutoMapper;
using DashBoardGr.Domain.Application.Queries.AnaliseQueries.BuscarAnalise;
using DashBoardGr.Domain.Application.Queries.BuscarAnalisesRelatorio;
using DashBoardGr.Domain.Repository.Entities;

namespace DashBoardGr.Domain.Application.Profiles
{
    public class AnaliseProfile : Profile
    {
        public AnaliseProfile()
        {
            CreateMap<AnaliseRisco, BuscarAnalisesGraficoViewModel>()
                .ForMember(vm => vm.NomeMotorista, ar => ar.MapFrom(x => x.Motorista.Nome))
                .ForMember(vm => vm.Cpf, ar => ar.MapFrom(x => x.Motorista.Cpf));


            CreateMap<AnaliseRisco, BuscarAnaliseViewModel>()
                .ForMember(vm=>vm.NomeMotorista, ar=>ar.MapFrom(x=>x.Motorista.Nome))
                .ForMember(vm => vm.Cpf, ar => ar.MapFrom(x => x.Motorista.Cpf));

        }
    }
}
