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

namespace Departamentos.Features.ReferenciaDocumentoC
{
    public class CreateRefDocumentoCommand
    {
        public class Command : IRequest<CommandResult>
        {
            public long IdDocumento { get; set; }
            public long IdDocumentoReferenciado { get; set; }
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

                RuleFor(command => command.IdDocumentoReferenciado)
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

                RuleFor(command => command.IdDocumentoReferenciado)
                   .MustAsync(async (Id, cancelToken) =>
                   {
                       return !await _DatabaseContext.Documentos.AnyAsync
                       (element => element.Id == Id);
                   })
                       .WithMessage("Documento referenciado no encontrado.");

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
                var foundDocument    = await _DatabaseContext.Documentos.FindAsync(request.IdDocumento);
                var foundDocumentRef = await _DatabaseContext.Documentos.FindAsync(request.IdDocumentoReferenciado);

                var newElement = new ReferenciaDocumento
                {
                    Documento = foundDocument,
                    DocumentoReferenciado = foundDocumentRef,
                    IdDocumento = request.IdDocumento,
                    IdDocumentoReferenciado = request.IdDocumentoReferenciado
                };

                _DatabaseContext.ReferenciaDocumentos.Add(newElement);

                await _DatabaseContext.SaveChangesAsync();

                return new CommandResult { Id = newElement.Id };
            }
        }
    }
}
