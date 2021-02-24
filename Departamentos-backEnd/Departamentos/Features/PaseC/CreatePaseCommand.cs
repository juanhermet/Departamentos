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
    public class CreatePaseCommand
    {
        public class Command : IRequest<CommandResult>
        {
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

                RuleFor(command => command.Fecha)
                    .NotEmpty()
                        .WithMessage("La fecha no debe ser vacía")
                    .NotNull()
                        .WithMessage("La fecha no debe ser vacía");

                RuleFor(command => command.Observaciones)
                    .NotEmpty()
                        .WithMessage("Las Observaciones no debe ser vacías")
                    .NotNull()
                        .WithMessage("Las Observaciones no debe ser vacías");

                RuleFor(command => command.IdDocumento)
                    .NotEmpty()
                        .WithMessage("El documento no debe ser vacío")
                    .NotNull()
                        .WithMessage("El documento no debe ser vacío");

                RuleFor(command => command.IdDocente)
                    .NotEmpty()
                        .WithMessage("El docente no debe ser vacío")
                    .NotNull()
                        .WithMessage("El docente no debe ser vacío");

                RuleFor(command => command.IdEstadoTramite)
                    .NotEmpty()
                        .WithMessage("El estado del trámite no debe ser vacío")
                    .NotNull()
                        .WithMessage("El estado del trámite no debe ser vacío");

                RuleFor(command => command.IdDocumento)
                   .MustAsync(async (Id, cancelToken) =>
                   {
                       return await _DatabaseContext.Documentos.AnyAsync
                       (element => element.Id == Id);
                   })
                       .WithMessage("elemento no encontrado.");

                RuleFor(command => command.IdDocente)
                   .MustAsync(async (Id, cancelToken) =>
                   {
                       return await _DatabaseContext.Docentes.AnyAsync
                       (element => element.Id == Id);
                   })
                       .WithMessage("Documento no encontrado.");

                RuleFor(command => command.IdEstadoTramite)
                   .MustAsync(async (Id, cancelToken) =>
                   {
                       return await _DatabaseContext.EstadoTramites.AnyAsync
                       (element => element.Id == Id);
                   })
                       .WithMessage("Estado trámite no encontrado.");
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
                var foundDocument = await _DatabaseContext.Documentos.FindAsync(request.IdDocumento);
                var foundDocent   = await _DatabaseContext.Docentes.FindAsync(request.IdDocente);
                var foundTram     = await _DatabaseContext.EstadoTramites.FindAsync(request.IdEstadoTramite);
                
                var newElement = new Pase
                {
                    Fecha           = request.Fecha,
                    Observaciones   = request.Observaciones,
                    IdDocente       = request.IdDocente,
                    IdDocumento     = request.IdDocumento,
                    IdEstadoTramite = request.IdEstadoTramite,
                    Docente         = foundDocent,
                    Documento       = foundDocument,
                    EstadoTramite   = foundTram
                };

                _DatabaseContext.Pases.Add(newElement);

                await _DatabaseContext.SaveChangesAsync();

                return new CommandResult { Id = newElement.Id };
            }
        }
    }
}
