using Departamentos.Infrastructure;
using Departamentos.Infrastructure.Persistents.Entities;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Departamentos.Features.TipoDocumentoC
{
    public class CreateTipoDocumentoCommand
    {
        public class Command : IRequest<CommandResult>
        {
            public string Tipo { get; set; }
        }

        public class CommandResult
        {
            public int Id { get; set; }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(command => command.Tipo)
                    .NotEmpty()
                        .WithMessage("El Tipo no debe ser vacío")
                    .NotNull()
                        .WithMessage("El Tipo no debe ser vacío");
            }
        }

        public class Handler : IRequestHandler<Command, CommandResult>
        {
            private DepartamentosContext _DatabaseContext;

            public Handler(DepartamentosContext context)
            {
                _DatabaseContext = context;
            }

            public async Task<CommandResult> Handle(Command request, CancellationToken cancellationToken)
            {
                var newElement = new TipoDocumento
                {
                    Tipo = request.Tipo
                };

                _DatabaseContext.TipoDocumentos.Add(newElement);

                await _DatabaseContext.SaveChangesAsync();

                return new CommandResult { Id = newElement.Id };
            }
        }
    }
}
