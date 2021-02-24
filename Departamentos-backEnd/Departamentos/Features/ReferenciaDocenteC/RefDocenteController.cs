using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Departamentos.Features.ReferenciaDocenteC
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class RefDocenteController : Controller
    {
        IMediator _mediator;

        public RefDocenteController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [ProducesResponseType(typeof(CreateRefDocenteCommand.Command), 200)]
        [ProducesResponseType(typeof(ValidationProblemDetails), 400)]
        public async Task<JsonResult> CrearTipoDocumento([FromBody] CreateRefDocenteCommand.Command command)
        {
            var result = await _mediator.Send(command);
            return new JsonResult(result);
        }

        [HttpPut]
        [ProducesResponseType(typeof(UpdateRefDocenteCommand.Command), 200)]
        [ProducesResponseType(typeof(ValidationProblemDetails), 400)]
        public async Task<JsonResult> ActualizarTipoDocumento([FromBody] UpdateRefDocenteCommand.Command command)
        {
            var result = await _mediator.Send(command);
            return new JsonResult(result);
        }

        [HttpGet]
        [ProducesResponseType(typeof(GetListOfRefDocentesQuery.Query), 200)]
        [ProducesResponseType(typeof(ValidationProblemDetails), 400)]
        public async Task<JsonResult> ListarTipoDocumentos([FromQuery] GetListOfRefDocentesQuery.Query query)
        {
            var result = await _mediator.Send(query);
            return new JsonResult(result);
        }

        [HttpDelete]
        [ProducesResponseType(typeof(DeleteRefDocenteCommand.Command), 200)]
        [ProducesResponseType(typeof(ValidationProblemDetails), 400)]
        public async Task<ActionResult> EliminarTipoDocumento([FromQuery] DeleteRefDocenteCommand.Command command)
        {
            await _mediator.Send(command);
            return Ok();
        }

    }
}
