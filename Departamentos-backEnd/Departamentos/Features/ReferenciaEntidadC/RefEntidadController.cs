using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Departamentos.Features.ReferenciaEntidadC
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class RefEntidadController : Controller
    {
        IMediator _mediator;

        public RefEntidadController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [ProducesResponseType(typeof(CreateRefEntidadCommand.Command), 200)]
        [ProducesResponseType(typeof(ValidationProblemDetails), 400)]
        public async Task<JsonResult> CrearTipoDocumento([FromBody] CreateRefEntidadCommand.Command command)
        {
            var result = await _mediator.Send(command);
            return new JsonResult(result);
        }

        [HttpPut]
        [ProducesResponseType(typeof(UpdateRefEntidadCommand.Command), 200)]
        [ProducesResponseType(typeof(ValidationProblemDetails), 400)]
        public async Task<JsonResult> ActualizarTipoDocumento([FromBody] UpdateRefEntidadCommand.Command command)
        {
            var result = await _mediator.Send(command);
            return new JsonResult(result);
        }

        [HttpGet]
        [ProducesResponseType(typeof(GetListOfRefEntidadesQuery.Query), 200)]
        [ProducesResponseType(typeof(ValidationProblemDetails), 400)]
        public async Task<JsonResult> ListarTipoDocumentos([FromQuery] GetListOfRefEntidadesQuery.Query query)
        {
            var result = await _mediator.Send(query);
            return new JsonResult(result);
        }

        [HttpDelete]
        [ProducesResponseType(typeof(DeleteRefEntidadCommand.Command), 200)]
        [ProducesResponseType(typeof(ValidationProblemDetails), 400)]
        public async Task<ActionResult> EliminarTipoDocumento([FromQuery] DeleteRefEntidadCommand.Command command)
        {
            await _mediator.Send(command);
            return Ok();
        }
    }
}
