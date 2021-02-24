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
    public class UpdateAsignaturasCommand
    {
        public class Command : IRequest<CommandResult>
        {
            public short Id { get; set; }
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

                RuleFor(command => command.Id)
                    .NotEmpty()
                        .WithMessage("Id no puede ser vacío.")
                    .NotNull()
                        .WithMessage("Id no puede ser vacío.");

                RuleFor(command => command.Id)
                   .MustAsync(async (Id, cancelToken) =>
                   {
                       return await _DatabaseContext.Asignaturas.AnyAsync
                       (element => element.Id == Id);
                   })
                       .WithMessage("Asignatura no encontrada.");

                RuleFor(command => command.Nombre)
                   .NotEmpty()
                       .WithMessage("Nombre no puede ser vacío.")
                   .NotNull()
                       .WithMessage("Nombre no puede ser vacío.");

                RuleFor(command => command.Catedra)
                   .NotEmpty()
                       .WithMessage("Cátedra no puede ser vacío.")
                   .NotNull()
                       .WithMessage("Cátedra no puede ser vacío.");
                
                RuleFor(command => command)
                   .MustAsync(async (catedra, cancelToken) =>
                   {
                       return await _DatabaseContext.Catedras.AnyAsync
                       (element => element.Id == catedra.Catedra.Id);
                   })
                       .WithMessage("Catedra no encontrada.");

                RuleFor(command => command)
                   .MustAsync(async (asignatura, cancelToken) =>
                   {
                       return await _DatabaseContext.Asignaturas.AnyAsync
                       (element => element.Id != asignatura.Id && element.Nombre == asignatura.Nombre);
                   })
                       .WithMessage("Ya existe una asignatura con ese nombre.");
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
                var foundAsignatura = alterAsignatura(request);

                _DatabaseContext.Asignaturas.Update(foundAsignatura);

                await _DatabaseContext.SaveChangesAsync();

                return new CommandResult { Id = foundAsignatura.Id };
            }

            private Asignatura alterAsignatura(Command request)
            {
                var asignatura = _DatabaseContext.Asignaturas.Find(request.Id);

                asignatura.Nombre = request.Nombre;
                asignatura.IdCatedra = request.Catedra.Id;
                asignatura.Catedra = request.Catedra;
                
                return asignatura;
            }
        }
    }
}
