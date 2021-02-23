using Departamentos.Infrastructure.Persistents.Users;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Departamentos.Features.Home
{
    public class HomeController :Controller
    {
        private IMediator _mediator;

        public HomeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [ProducesResponseType(typeof(RegisterUserCommand.Command), 200)]
        [ProducesResponseType(typeof(ValidationProblemDetails), 400)]
        public async Task<JsonResult> CrearUsuario([FromBody] RegisterUserCommand.Command command)
        {
            var result = await _mediator.Send(command);
            return new JsonResult(result);
        }

    }
}
