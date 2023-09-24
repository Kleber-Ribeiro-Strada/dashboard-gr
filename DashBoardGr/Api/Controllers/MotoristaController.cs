﻿using DashBoardGr.Domain.Application.Commands.AdicionarMotorista;
using DashBoardGr.Domain.Application.Queries.BuscarMotoristaPorCodigo;
using DashBoardGr.Domain.Application.Queries.BuscarMotoristas;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MotoristaController : ControllerBase
    {
        private readonly ILogger<MotoristaController> _logger;
        private readonly IMediator _mediator;

        public MotoristaController(ILogger<MotoristaController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpPost("adicionar")]
        public async Task<IActionResult> AdicionarMotorista([FromBody] AdicionarMotoristaCommand command)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var result = await _mediator.Send(command);
            if(result.IsSuccessStatusCode)
                return Ok(result);

            return BadRequest(result);
            
        }

        [HttpGet]
        public async Task<IActionResult> BuscarMotoristas()
        {
            var result = await _mediator.Send(new BuscarMotoristasQuery { });

            return Ok(result);
        }

        [HttpGet("buscar-motorista/{id}")]
        public async Task<IActionResult> BuscarMotorista(Guid id)
        {
            var result = await _mediator.Send(new BuscarMotoristaPorCodigoQuery { Id = id });

            return Ok(result);
        }
    }
}
