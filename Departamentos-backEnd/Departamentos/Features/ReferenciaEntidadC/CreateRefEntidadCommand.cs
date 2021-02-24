using Departamentos.Infrastructure;
using Departamentos.Infrastructure.Persistents.Entities;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Departamentos.Features.ReferenciaEntidadC
{
    public class CreateRefEntidadCommand
    {
        public class Command : IRequest<CommandResult>
        {
            public int IdDocumento { get; set; }
            public short IdEntidadReferenciada { get; set; }
        }

        public class CommandResult
        {
            public long Id { get; set; }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            private DepartamentosContext _DatabaseContext;
            public CommandValidator(DepartamentosContext databaseContext)
            {
                _DatabaseContext = databaseContext;

                RuleFor(command => command.IdDocumento)
                    .NotEmpty()
                        .WithMessage("El documento no debe ser vacío")
                    .NotNull()
                        .WithMessage("El documento no debe ser vacío");

                RuleFor(command => command.IdEntidadReferenciada)
                   .NotEmpty()
                       .WithMessage("La referencia no debe ser vacía")
                   .NotNull()
                       .WithMessage("La referencia no debe ser vacía");

                RuleFor(command => command.IdDocumento)
                  .MustAsync(async (Id, cancelToken) =>
                  {
                      return await _DatabaseContext.Documentos.AnyAsync
                      (element => element.Id == Id);
                  })
                      .WithMessage("Documento no encontrado.");

                RuleFor(command => command.IdEntidadReferenciada)
                  .MustAsync(async (Id, cancelToken) =>
                  {
                      return await _DatabaseContext.Entidades.AnyAsync
                      (element => element.Id == Id);
                  })
                      .WithMessage("Entidad no encontrada.");
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
                var foundDocument  = await _DatabaseContext.Documentos.FindAsync(request.IdDocumento);
                var foundRefEntity = await _DatabaseContext.Entidades.FindAsync(request.IdEntidadReferenciada);
                
                var newElement = new ReferenciaEntidad
                {
                    Documento             = foundDocument,
                    EntidadReferenciada   = foundRefEntity,
                    IdDocumento           = request.IdDocumento,
                    IdEntidadReferenciada = request.IdEntidadReferenciada
                };

                _DatabaseContext.ReferenciaEntidades.Add(newElement);

                await _DatabaseContext.SaveChangesAsync();

                return new CommandResult { Id = newElement.Id };
            }
        }
    }
}
