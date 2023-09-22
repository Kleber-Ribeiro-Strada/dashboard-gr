using AutoMapper;
using DashBoardGr.Domain.Application.Queries.BuscarAnalisesRelatorio;
using DashBoardGr.Domain.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DashBoardGr.Domain.Application.Profiles
{
    public class AnaliseProfile : Profile
    {
        public AnaliseProfile()
        {
            CreateMap<AnaliseRisco, BuscarAnalisesGraficoViewModel>()
                .ForMember(vm => vm.NomeMotorista, ar => ar.MapFrom(x => x.Motorista.Nome));
        }
    }
}
