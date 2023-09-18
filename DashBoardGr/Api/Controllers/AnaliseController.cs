using DashBoardGr.Domain.Application.Commands.SolicitarAnalise;
using DashBoardGr.Domain.Application.Queries.AnaliseQueries.BuscarAnalise;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnaliseController : ControllerBase
    {
        private readonly ILogger<AnaliseController> _logger;
        private readonly IMediator _mediator;

        public AnaliseController(ILogger<AnaliseController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpPost("solicitar-analise")]
        public async Task<IActionResult> SolicitarAnaliseAsync([FromBody]SolicitarAnaliseCommand command)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            
            _logger.LogInformation("123 testando");
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpGet("verificar-analise")]
        public async Task<IActionResult> VerificarAnalise(Guid Id)
        {
            var buscarAnaliseQuery = new BuscarAnaliseQuery();

            return Ok(Task.FromResult(new { }));
        }

        [HttpGet("teste")]
        public IActionResult Teste()
        {
            _logger.LogInformation("123 testando");

            return Ok(new { result = "teste" });
        }
    }
}
