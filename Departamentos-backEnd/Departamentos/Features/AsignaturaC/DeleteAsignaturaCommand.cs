using Departamentos.Infrastructure;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Departamentos.Controllers.AsignaturaC
{
    public class DeleteAsignaturaCommand
    {
        public class Command : IRequest
        {
            public int Id { get; set; }
        }
        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(command => command.Id)
                    .NotEmpty()
                    .NotNull()
                    .WithMessage("Id no puede ser vacío.");
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
                var toRemove = _DatabaseContext.Asignaturas.Where(element => element.Id == request.Id);
                _DatabaseContext.Asignaturas.RemoveRange(toRemove);
                await _DatabaseContext.SaveChangesAsync();

                return Unit.Value;
            }
        }
    }
}
