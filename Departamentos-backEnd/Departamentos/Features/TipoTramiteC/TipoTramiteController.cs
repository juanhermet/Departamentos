using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Departamentos.Features.TipoTramiteC
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class TipoTramiteController : Controller
    {    
        private IMediator _mediator;
       
        public TipoTramiteController(IMediator mediator)    
        {
            _mediator = mediator;
        }
        [HttpPost]
        [ProducesResponseType(typeof(CreateTipoTramiteCommand.Command), 200)]
        [ProducesResponseType(typeof(ValidationProblemDetails), 400)]
        public async Task<JsonResult> CrearTipoTramite([FromBody] CreateTipoTramiteCommand.Command command)
        {
            var result = await _mediator.Send(command);
            return new JsonResult(result);
        }

        [HttpPut]
        [ProducesResponseType(typeof(UpdateTipoTramiteCommand.Command), 200)]
        [ProducesResponseType(typeof(ValidationProblemDetails), 400)]
        public async Task<JsonResult> ActualizarTipoTramite([FromBody] UpdateTipoTramiteCommand.Command command)
        {
            var result = await _mediator.Send(command);
            return new JsonResult(result);
        }

        [HttpGet]
        [ProducesResponseType(typeof(GetListOfTipoTramiteQuery.Query), 200)]
        [ProducesResponseType(typeof(ValidationProblemDetails), 400)]
        public async Task<JsonResult> ListarTipoTramites([FromQuery] GetListOfTipoTramiteQuery.Query query)
        {
            var result = await _mediator.Send(query);
            return new JsonResult(result);
        }

        [HttpDelete]
        [ProducesResponseType(typeof(DeleteTipoTramiteCommand.Command), 200)]
        [ProducesResponseType(typeof(ValidationProblemDetails), 400)]
        public async Task<ActionResult> EliminarTipoTramite([FromQuery] DeleteTipoTramiteCommand.Command command)
        {
            await _mediator.Send(command);
            return Ok();
        }
    }
}
