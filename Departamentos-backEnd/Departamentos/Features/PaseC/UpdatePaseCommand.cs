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

namespace Departamentos.Features.PaseC
{
    public class UpdatePaseCommand
    {
        public class Command : IRequest<CommandResult>
        {
            public long     Id { get; set; }
            public DateTime Fecha { get; set; }
            public string   Observaciones { get; set; }
            public long     IdDocumento { get; set; }
            public int      IdDocente { get; set; }
            public short    IdEstadoTramite { get; set; }
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

                RuleFor(command => command.Id)
                   .NotEmpty()
                   .WithMessage("Id no puede ser vacío.")
                   .NotNull()
                   .WithMessage("Id no puede ser vacío.");

                RuleFor(command => command.Fecha)
                   .NotEmpty()
                       .WithMessage("Documento no puede ser vacío.")
                   .NotNull()
                       .WithMessage("Documento no puede ser vacío.");

                RuleFor(command => command.Observaciones)
                   .NotEmpty()
                       .WithMessage("Documento no puede ser vacío.")
                   .NotNull()
                       .WithMessage("Documento no puede ser vacío.");

                RuleFor(command => command.IdDocumento)
                   .NotEmpty()
                       .WithMessage("Documento no puede ser vacío.")
                   .NotNull()
                       .WithMessage("Documento no puede ser vacío.");

                RuleFor(command => command.IdDocente)
                   .NotEmpty()
                       .WithMessage("Documento no puede ser vacío.")
                   .NotNull()
                       .WithMessage("Documento no puede ser vacío.");

                RuleFor(command => command.IdEstadoTramite)
                   .NotEmpty()
                       .WithMessage("Documento no puede ser vacío.")
                   .NotNull()
                       .WithMessage("Documento no puede ser vacío.");

                
                RuleFor(command => command.Id)
                   .MustAsync(async (Id, cancelToken) =>
                   {
                       return !await _DatabaseContext.ReferenciaDocentes.AnyAsync
                       (element => element.Id == Id);
                   })
                       .WithMessage("Documento no encontrado.");

                RuleFor(command => command.IdDocumento)
                   .MustAsync(async (Id, cancelToken) =>
                   {
                       return !await _DatabaseContext.Notas.AnyAsync
                       (element => element.Id == Id);
                   })
                       .WithMessage("Documento no encontrado.");

                RuleFor(command => command.IdDocenteReferenciado)
                  .MustAsync(async (Id, cancelToken) =>
                  {
                      return !await _DatabaseContext.Docentes.AnyAsync
                      (element => element.Id == Id);
                  })
                      .WithMessage("Docente no encontrado.");
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
                var foundElement = alterElement(request);

                _DatabaseContext.ReferenciaDocentes.Update(foundElement);

                await _DatabaseContext.SaveChangesAsync();

                return new CommandResult { Id = foundElement.Id };
            }

            private Pase alterElement(Command request)
            {
                var entity = _DatabaseContext.Pases.Find(request.Id);

                entity.Docente = _DatabaseContext.Docentes.Find(request.IdDocenteReferenciado);
                entity.Documento = _DatabaseContext.Notas.Find(request.IdDocumento);
                entity.EstadoTramite = _DatabaseContext.EstadoTramites.Find(request.);

                return entity;
            }
        }
    }
}
