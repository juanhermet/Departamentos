using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Departamentos.Features.TipoCargoC
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class TipoCargoController :Controller
    {
        IMediator _mediator;

        public TipoCargoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [ProducesResponseType(typeof(CreateTipoCargoCommand.Command), 200)]
        [ProducesResponseType(typeof(ValidationProblemDetails), 400)]
        public async Task<JsonResult> CrearTipoDocumento([FromBody] CreateTipoCargoCommand.Command command)
        {
            var result = await _mediator.Send(command);
            return new JsonResult(result);
        }

        [HttpPut]
        [ProducesResponseType(typeof(UpdateTipoCargoCommand.Command), 200)]
        [ProducesResponseType(typeof(ValidationProblemDetails), 400)]
        public async Task<JsonResult> ActualizarTipoDocumento([FromBody] UpdateTipoCargoCommand.Command command)
        {
            var result = await _mediator.Send(command);
            return new JsonResult(result);
        }

        [HttpGet]
        [ProducesResponseType(typeof(GetListOfTipoCargosQuery.Query), 200)]
        [ProducesResponseType(typeof(ValidationProblemDetails), 400)]
        public async Task<JsonResult> ListarTipoDocumentos([FromQuery] GetListOfTipoCargosQuery.Query query)
        {
            var result = await _mediator.Send(query);
            return new JsonResult(result);
        }

        [HttpDelete]
        [ProducesResponseType(typeof(DeleteTipoCargoCommand.Command), 200)]
        [ProducesResponseType(typeof(ValidationProblemDetails), 400)]
        public async Task<ActionResult> EliminarTipoDocumento([FromQuery] DeleteTipoCargoCommand.Command command)
        {
            await _mediator.Send(command);
            return Ok();
        }
    }
}
