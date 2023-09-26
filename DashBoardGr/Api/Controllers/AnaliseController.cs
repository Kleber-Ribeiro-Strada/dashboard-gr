using DashBoardGr.Domain.Application.Commands.SolicitarAnalise;
using DashBoardGr.Domain.Application.Queries.AnaliseQueries.BuscarAnalise;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnaliseController : ControllerBase
    {
        #region Propriedades
        private readonly ILogger<AnaliseController> _logger;
        private readonly IMediator _mediator;
        #endregion

        #region Construtor
        public AnaliseController(ILogger<AnaliseController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }
        #endregion

        [HttpPost("solicitar-analise")]
        public async Task<IActionResult> SolicitarAnaliseAsync([FromBody]SolicitarAnaliseCommand command)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            
            _logger.LogInformation("Solitiar Análise", command);
            var result = await _mediator.Send(command);
            if (result.IsSuccessStatusCode)
                return Ok(result);

            _logger.LogError("Erro ao solicitar análise, Solitiar Análise", command);
            return BadRequest(result);
        }

        [HttpGet("verificar-analise")]
        public async Task<IActionResult> VerificarAnalise(Guid id)
        {
            _logger.LogInformation($"Buscar Análise Id: {id}");
            var buscarAnaliseQuery = new BuscarAnaliseQuery { Id = id };
            var result = await _mediator.Send(buscarAnaliseQuery);

            if (result != null)
                return Ok(result);

            _logger.LogInformation($"Análise: {id} não encontrada");
            return NotFound();
        }

        [HttpGet("teste")]
        public IActionResult Teste()
        {
            _logger.LogInformation("123 testando");

            return Ok(new { result = "teste" });
        }
    }
}
