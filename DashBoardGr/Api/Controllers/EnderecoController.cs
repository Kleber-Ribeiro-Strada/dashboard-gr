using DashBoardGr.Infrastructure.BuscarCep.ExternalServices;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnderecoController : ControllerBase
    {
        private readonly BuscarEnderecoService _service;

        public EnderecoController(BuscarEnderecoService service)
        {
            _service = service;
        }

        [HttpGet("{cep}/buscar-endereco")]
        public async Task<IActionResult> BuscarEndereco(string cep)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            return Ok(await _service.BuscarEndereco(cep));
        }
    }
}
