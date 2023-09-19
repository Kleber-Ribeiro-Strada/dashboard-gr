﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DashBoardGr.Domain.Application.Queries.BuscarMotoristas
{
    public class BuscarMotoristasViewModel
    {
        public Guid Id { get; set; }
        public string Nome { get; set; } 
        public DateTime DataNascimento { get; set; }
        public string Cpf { get; set; } 
        public string Telefone { get; set; } 
        public string Email { get; set; } 
    }
}
