using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RelatorioController : ControllerBase
    {
        [HttpGet]
        public string BuscarAnalisePorPeriodo()
        {
            return "teste";
        }

        [HttpGet]
        public string BuscarAnalisesPorCliente()
        {
            return "teste";
        }

        [HttpGet]
        public string Analitico(object filtro)
        {
            return "teste";
        }

        #region Sintéticos
        [HttpGet]
        public string SinteticoAprovadoReprovadoAgrupadoPorSemanas(object filtro)
        {
            return "teste";
        }

        [HttpGet]
        public string SinteticoTotalReprovacoes(object filtro)
        {
            return "teste";
        }

        [HttpGet]
        public string SinteticoStatusReprovacoes(object filtro)
        {
            return "teste";
        }
        #endregion

    }
}
