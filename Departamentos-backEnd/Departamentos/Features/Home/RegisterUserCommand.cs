using Departamentos.Infrastructure.Persistents.Users;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Departamentos.Features.Home
{
    public class RegisterUserCommand
    {
        public class Command : IRequest<CommandResult>
        {
            public string Usuario { get; set; }
            public string Password { get; set; }
            public string Email { get; set; }
            public string Confpass { get; set; }
            public string Nombre { get; set; }
        }

        public class CommandResult
        {
            public int Id { get; set; }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            private readonly UserManager<Usuarios> _userManager;

            public CommandValidator(UserManager<Usuarios> userManager)
            {
                _userManager = userManager;

                RuleFor(command => command.Nombre)
                    .NotEmpty()
                        .WithMessage("El nombre no debe ser vacío")
                    .NotNull()
                        .WithMessage("El nombre no debe ser vacío");

                RuleFor(command => command.Password)
                    .NotEmpty()
                        .WithMessage("El password no debe ser vacío")
                    .NotNull()
                        .WithMessage("El password no debe ser vacío");

                RuleFor(command => command.Usuario)
                   .NotEmpty()
                       .WithMessage("El usuario no debe ser vacío")
                   .NotNull()
                       .WithMessage("El usuario no debe ser vacío");

                RuleFor(command => command.Email)
                   .NotEmpty()
                       .WithMessage("El Email no debe ser vacío")
                   .NotNull()
                       .WithMessage("El Email no debe ser vacío");

                RuleFor(command => command.Confpass)
                   .NotEmpty()
                       .WithMessage("La confirmación del Email no debe ser vacía")
                   .NotNull()
                       .WithMessage("La confirmación del Email no debe ser vacía");

                RuleFor(command => command)
                    .MustAsync(async (catedra, cancelToken) =>
                    {
                        return await _userManager.FindByNameAsync(catedra.Nombre) != null;
                    })
                        .WithMessage("El usuario ya existe");
            }
        }

        public class Handler : IRequestHandler<Command,CommandResult>
        {
            private readonly UserManager<Usuarios> _userManager;

            public Handler(UserManager<Usuarios> userManager)
            {
                _userManager = userManager;
            }

            public async Task<CommandResult> Handle(Command request, CancellationToken cancellationToken)
            {
                Usuarios usuarioExist = new Usuarios
                {
                    Email = request.Email,
                    EmailConfirmed = true,
                    Nombre = request.Nombre,
                    UserName = request.Usuario,
                };
                
                IdentityResult identityResult = await _userManager.CreateAsync(usuarioExist, request.Password);
                
                return new CommandResult { Id = int.Parse(usuarioExist.Id) };
            }
        }
    }
}
