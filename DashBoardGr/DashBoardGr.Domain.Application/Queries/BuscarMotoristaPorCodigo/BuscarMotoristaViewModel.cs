﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DashBoardGr.Domain.Application.Queries.BuscarMotoristaPorCodigo
{
    public class BuscarMotoristaViewModel
    {
        public Guid Id { get; set; }

        public string Nome { get; set; } = string.Empty;
    }
}
