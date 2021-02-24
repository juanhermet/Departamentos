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

namespace Departamentos.Features.ReferenciaDocenteC
{
    public class CreateRefDocenteCommand
    {
        public class Command : IRequest<CommandResult>
        {
            public long IdDocumento { get; set; }
            public int  IdDocenteReferenciado { get; set; }
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

                RuleFor(command => command.IdDocenteReferenciado)
                    .NotEmpty()
                        .WithMessage("El documento referenciado no debe ser vacío")
                    .NotNull()
                        .WithMessage("El documento referenciado no debe ser vacío");

                RuleFor(command => command.IdDocumento)
                   .MustAsync(async (Id, cancelToken) =>
                   {
                       return !await _DatabaseContext.Documentos.AnyAsync
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
                var foundDocument  = await _DatabaseContext.Documentos.FindAsync(request.IdDocumento);
                var foundDocentRef = await _DatabaseContext.Docentes.FindAsync(request.IdDocenteReferenciado);

                var newElement = new ReferenciaDocente 
                {
                    Documento             = foundDocument,
                    DocenteReferenciado   = foundDocentRef,
                    IdDocumento           = request.IdDocumento,
                    IdDocenteReferenciado = request.IdDocenteReferenciado
                };

                _DatabaseContext.ReferenciaDocentes.Add(newElement);

                await _DatabaseContext.SaveChangesAsync();

                return new CommandResult { Id = newElement.Id };
            }
        }
    }
}
