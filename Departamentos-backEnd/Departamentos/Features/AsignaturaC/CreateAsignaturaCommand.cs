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

namespace Departamentos.Controllers.AsignaturaC
{
    public class CreateAsignaturaCommand
    {
        public class Command : IRequest<CommandResult>
        {
            public string Nombre { get; set; }
            public Catedra Catedra { get; set; }
        }

        public class CommandResult
        {
            public int Id { get; set; }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            private DepartamentosContext _DatabaseContext;

            public CommandValidator(DepartamentosContext databaseContext)
            {
                _DatabaseContext = databaseContext;

                RuleFor(command => command.Nombre)
                    .NotEmpty()
                        .WithMessage("El nombre no debe ser vacío")
                    .NotNull()
                        .WithMessage("El nombre no debe ser vacío");
                
                RuleFor(command => command.Catedra)
                    .MustAsync(async (catedra, cancelToken) =>
                    {
                        return await _DatabaseContext.Catedras.AnyAsync
                        (catedraElement => catedraElement.Id == catedra.Id);
                    })
                        .WithMessage("La Cátedra no existe.");
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
                var newAsignatura = new Asignatura
                {
                    Nombre = request.Nombre,
                    Catedra = request.Catedra,
                    IdCatedra = request.Catedra.Id
                };

                _DatabaseContext.Asignaturas.Add(newAsignatura);

                await _DatabaseContext.SaveChangesAsync();

                return new CommandResult { Id = newAsignatura.Id };
            }
        }
    }
}
