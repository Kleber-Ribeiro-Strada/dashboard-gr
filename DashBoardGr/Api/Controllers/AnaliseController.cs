using DashBoardGr.Domain.Application.Commands.SolicitarAnalise;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AnaliseController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

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
        public string VerificarAnalise()
        {
            return "teste";
        }
    }
}
