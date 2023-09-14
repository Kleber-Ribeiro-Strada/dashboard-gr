using DashBoardGr.Domain.Application.Commands.SolicitarAnalise;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DashBoardGr.Domain.Application.Commands.AdicionarVeiculo
{
    public class AdicionarVeiculoCommandValidator : AbstractValidator<AdicionarVeiculoCommand>
    {
        public AdicionarVeiculoCommandValidator()
        {
            
        }
    }
}
