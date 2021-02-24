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
    public class UpdateRefDocumentoCommand
    {

        public class Command : IRequest<CommandResult>
        {
            public long Id { get; set; }
            public long IdDocumento { get; set; }
            public short IdDocumentoReferenciado { get; set; }
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

                RuleFor(command => command.IdDocumento)
                   .NotEmpty()
                       .WithMessage("Nombre no puede ser vacío.")
                   .NotNull()
                       .WithMessage("Nombre no puede ser vacío.");

                RuleFor(command => command.IdDocumentoReferenciado)
                   .NotEmpty()
                       .WithMessage("Nombre no puede ser vacío.")
                   .NotNull()
                       .WithMessage("Nombre no puede ser vacío.");

                RuleFor(command => command.Id)
                   .MustAsync(async (Id, cancelToken) =>
                   {
                       return !await _DatabaseContext.ReferenciaDocumentos.AnyAsync
                       (element => element.Id == Id);
                   })
                       .WithMessage("elemento no encontrado.");

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
                var foundElement = alterElement(request);

                _DatabaseContext.ReferenciaDocumentos.Update(foundElement);

                await _DatabaseContext.SaveChangesAsync();

                return new CommandResult { Id = foundElement.Id };
            }

            private ReferenciaDocumento alterElement(Command request)
            {
                var entity = _DatabaseContext.ReferenciaDocumentos.Find(request.Id);

                entity.Documento               = _DatabaseContext.Documentos.Find(request.IdDocumento);
                entity.DocumentoReferenciado   = _DatabaseContext.Documentos.Find(request.IdDocumentoReferenciado);
                entity.IdDocumento             = request.IdDocumento;
                entity.IdDocumentoReferenciado = request.IdDocumentoReferenciado;

                return entity;
            }
        }
    }
}
