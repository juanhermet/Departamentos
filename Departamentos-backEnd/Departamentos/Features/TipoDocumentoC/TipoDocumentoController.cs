using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Departamentos.Features.TipoDocumentoC
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class TipoDocumentoController : Controller
    {
        IMediator _mediator;

        public TipoDocumentoController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        [ProducesResponseType(typeof(CreateTipoDocumentoCommand.Command), 200)]
        [ProducesResponseType(typeof(ValidationProblemDetails), 400)]
        public async Task<JsonResult> CrearTipoDocumento([FromBody] CreateTipoDocumentoCommand.Command command)
        {
            var result = await _mediator.Send(command);
            return new JsonResult(result);
        }

        [HttpPut]
        [ProducesResponseType(typeof(UpdateTipoDocumentoCommand.Command), 200)]
        [ProducesResponseType(typeof(ValidationProblemDetails), 400)]
        public async Task<JsonResult> ActualizarTipoDocumento([FromBody] UpdateTipoDocumentoCommand.Command command)
        {
            var result = await _mediator.Send(command);
            return new JsonResult(result);
        }

        [HttpGet]
        [ProducesResponseType(typeof(GetListOfTipoDocumentoQuery.Query), 200)]
        [ProducesResponseType(typeof(ValidationProblemDetails), 400)]
        public async Task<JsonResult> ListarTipoDocumentos([FromQuery] GetListOfTipoDocumentoQuery.Query query)
        {
            var result = await _mediator.Send(query);
            return new JsonResult(result);
        }

        [HttpDelete]
        [ProducesResponseType(typeof(DeleteTipoDocumentoCommand.Command), 200)]
        [ProducesResponseType(typeof(ValidationProblemDetails), 400)]
        public async Task<ActionResult> EliminarTipoDocumento([FromQuery] DeleteTipoDocumentoCommand.Command command)
        {
            await _mediator.Send(command);
            return Ok();
        }
    }
}
