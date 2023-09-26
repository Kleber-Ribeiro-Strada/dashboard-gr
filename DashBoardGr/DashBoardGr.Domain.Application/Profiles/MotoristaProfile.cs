using AutoMapper;
using DashBoardGr.Domain.Application.Commands.AdicionarMotorista;
using DashBoardGr.Domain.Application.Commands.AvaliarAnalise;
using DashBoardGr.Domain.Application.Queries.BuscarMotoristaPorCodigo;
using DashBoardGr.Domain.Application.Queries.BuscarMotoristas;
using DashBoardGr.Domain.Repository.Entities;
using System.Net.WebSockets;
using static DashBoardGr.Domain.Application.Queries.BuscarMotoristas.BuscarMotoristasViewModel;

namespace DashBoardGr.Domain.Application.Profiles
{
    public class MotoristaProfile : Profile
    {
        public MotoristaProfile() 
        {
            CreateMap<AdicionarMotoristaCommand, Motorista>();

            CreateMap<AdicionarCnhMotoristaCommand, Cnh>();


            CreateMap<AnaliseRisco, BuscarMotoristasAnaliseViewModel>();
            CreateMap<Motorista, BuscarMotoristasViewModel>()
                .ForMember(m => m.Analise, vm => vm.MapFrom(obj => obj.Analises.OrderByDescending(a=>a.DataSolicitacaoAnalise).FirstOrDefault()));


            CreateMap<Motorista, BuscarMotoristaViewModel>();
        }

    }
}
