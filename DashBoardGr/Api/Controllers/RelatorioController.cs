using DashBoardGr.Domain.Application.Queries.BuscarAnalisesGraficoBarras;
using DashBoardGr.Domain.Application.Queries.BuscarAnalisesGraficoPizza;
using DashBoardGr.Domain.Application.Queries.BuscarAnalisesRelatorio;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RelatorioController : ControllerBase
    {
        private readonly IMediator _mediator;
        public RelatorioController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> BuscarRelatorioFiltro([FromQuery]BuscarAnalisesRelatorioQuery query)
        {
            return Ok(await _mediator.Send(query));
        }

        [HttpGet("buscar-grafico-barras-semanas")]
        public async Task<IActionResult> BuscarGraficoBarras([FromQuery] BuscarAnalisesGraficoBarrasQuery query)
        {
            return Ok(await _mediator.Send(query));
        }


        [HttpGet("buscar-grafico-pizza")]
        public async Task<IActionResult> BuscarGraficoPizza([FromQuery] BuscarAnalisesGraficoPizzaQuery query)
        {
            return Ok(await _mediator.Send(query));
        }

        [HttpGet("buscar-grafico-linha-horas")]
        public async Task<IActionResult> BuscarGraficoLinha([FromQuery] BuscarAnalisesGraficoLinhaQuery query)
        {
            return Ok(await _mediator.Send(query));
        }
    }
}
