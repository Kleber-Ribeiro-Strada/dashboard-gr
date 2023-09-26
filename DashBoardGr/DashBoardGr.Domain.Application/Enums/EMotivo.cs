using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DashBoardGr.Domain.Application.Enums
{
    public enum EMotivo
    {
        [Description("SituacaoCadastralPendente")]
        SituacaoCadastralPendente,

        [Description("FotoSemNitidez")]
        FotoSemNitidez,

        [Description("CadastroInvalido")]
        CadastroInvalido,

        [Description("DocumentoVencido")]
        DocumentoVencido,

        [Description("PendenciaReceitaFederal")]
        PendenciaReceitaFederal,

        [Description("Outros")]
        Outros
    }
}
