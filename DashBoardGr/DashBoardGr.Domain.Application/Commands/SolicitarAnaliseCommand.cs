using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DashBoardGr.Domain.Application.Commands
{
    public class SolicitarAnaliseCommand : IRequest<Unit>
    {
        public string Nome { get; set; }

        public string Sobrenome { get; set; }

        public DateTime DataNascimento { get; set; }
    }
}
