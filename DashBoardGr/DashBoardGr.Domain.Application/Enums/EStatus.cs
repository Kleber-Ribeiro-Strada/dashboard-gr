using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DashBoardGr.Domain.Application.Enums
{
    public enum EStatus
    {
        [Description("Pendente")]
        Pendente = 1,

        [Description("Aprovado")]
        Aprovado = 2,

        [Description("Reprovado")]
        Reprovado = 3
    }

}
