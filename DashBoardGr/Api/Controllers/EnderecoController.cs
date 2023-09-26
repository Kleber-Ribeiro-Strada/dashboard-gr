using DashBoardGr.Infrastructure.BuscarCep.ExternalServices;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnderecoController : ControllerBase
    {
        private readonly BuscarEnderecoService _service;
        private readonly ILogger<EnderecoController> _logger;

        public EnderecoController(BuscarEnderecoService service, ILogger<EnderecoController> logger)
        {
            _service = service;
            _logger = logger;
        }

        [HttpGet("{cep}/buscar-endereco")]
        public async Task<IActionResult> BuscarEndereco(string cep)
        {
            _logger.LogInformation($"Serviço externo para buscar de endereço pelo cep: {cep}");
            if (!ModelState.IsValid)
                return BadRequest();

            return Ok(await _service.BuscarEndereco(cep));
        }
    }
}
