using Departamentos.Infrastructure;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Departamentos.Features.TipoDocumentoC
{
    public class DeleteTipoDocumentoCommand
    {
        public class Command : IRequest
        {
            public int Id { get; set; }
        }
        public class CommandValidator : AbstractValidator<Command>
        {
            DepartamentosContext _DatabaseContext;

            public CommandValidator(DepartamentosContext databaseContext)
            {
                _DatabaseContext = databaseContext;

                RuleFor(command => command.Id)
                    .NotEmpty()
                    .NotNull()
                    .WithMessage("Id no puede ser vacío.");

                RuleFor(command => command.Id)
                  .MustAsync(async (Id, cancelToken) =>
                  {
                      return await _DatabaseContext.TipoDocumentos.AnyAsync
                      (element => element.Id == Id);
                  })
                      .WithMessage("Elemento no encontrado.");
            }
        }
        public class Handler : IRequestHandler<Command>
        {
            private DepartamentosContext _DatabaseContext;

            public Handler(DepartamentosContext databaseContext)
            {
                _DatabaseContext = databaseContext;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var toRemove = _DatabaseContext.TipoDocumentos.Where(element => element.Id == request.Id);
                _DatabaseContext.TipoDocumentos.RemoveRange(toRemove);
                await _DatabaseContext.SaveChangesAsync();

                return Unit.Value;
            }
        }
    }
}
