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

        public AnaliseController(ILogger<AnaliseController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public string SolicitarAnalise()
        {
            return "teste";
        }

        [HttpGet]
        public string VerificarAnalise()
        {
            return "teste";
        }



    }
}
