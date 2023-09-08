using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RelatorioController : ControllerBase
    {
        [HttpGet("buscar-analise-por-periodo")]
        public string BuscarAnalisePorPeriodo()
        {
            return "teste";
        }

        [HttpGet("buscar-analise-por-cliente")]
        public string BuscarAnalisesPorCliente()
        {
            return "teste";
        }

        [HttpGet("buscar-analitico")]
        public string Analitico(object filtro)
        {
            return "teste";
        }

        #region Sintéticos
        [HttpGet("buscar-dados-sinteticos-aprovado-reprovado-agrupado-por-semanas")]
        public string SinteticoAprovadoReprovadoAgrupadoPorSemanas(object filtro)
        {
            return "teste";
        }

        [HttpGet("buscar-sintetico-total-reprovacoes")]
        public string SinteticoTotalReprovacoes(object filtro)
        {
            return "teste";
        }

        [HttpGet("buscar-sintetico-status-reprovacoes")]
        public string SinteticoStatusReprovacoes(object filtro)
        {
            return "teste";
        }
        #endregion

    }
}
