using AutoMapper;
using DashBoardGr.Domain.Application.Commands.AdicionarMotorista;
using DashBoardGr.Domain.Application.Queries.BuscarMotoristas;
using DashBoardGr.Domain.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DashBoardGr.Domain.Application.Profiles
{
    public class MotoristaProfile : Profile
    {
        public MotoristaProfile() 
        {
            CreateMap<AdicionarMotoristaCommand, Motorista>();

            CreateMap<AdicionarCnhMotoristaCommand, Cnh>();

            CreateMap<Motorista, BuscarMotoristasViewModel>();
        }

    }
}
