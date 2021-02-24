﻿using Departamentos.Infrastructure;
using Departamentos.Infrastructure.Persistents.Entities;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Departamentos.Features.TipoTramiteC
{
    public class UpdateTipoTramiteCommand
    {

        public class Command : IRequest<CommandResult>
        {
            public short Id { get; set; }
            public string Tipo { get; set; }
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
                    .NotNull()
                    .WithMessage("Id no puede ser vacío.");

                RuleFor(command => command.Id)
                   .MustAsync(async (Id, cancelToken) =>
                   {
                       return await _DatabaseContext.TipoTramites.AnyAsync
                       (element => element.Id == Id);
                   })
                       .WithMessage("Asignatura no encontrada.");

                RuleFor(command => command.Tipo)
                   .NotEmpty()
                       .WithMessage("Nombre no puede ser vacío.")
                   .NotNull()
                       .WithMessage("Nombre no puede ser vacío.");

                RuleFor(command => command.Tipo)
                   .MustAsync(async (tipo, cancelToken) =>
                   {
                       return !await _DatabaseContext.TipoTramites.AnyAsync
                       (element => element.Tipo == tipo);
                   })
                       .WithMessage("Ya existe un tipo de tramite con ese nombre.");
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
                var foundTramite = alterTramite(request);

                _DatabaseContext.TipoTramites.Update(foundTramite);

                await _DatabaseContext.SaveChangesAsync();

                return new CommandResult { Id = foundTramite.Id };
            }

            private TipoTramite alterTramite(Command request)
            {
                var entity = _DatabaseContext.TipoTramites.Find(request.Id);

                entity.Tipo = request.Tipo;

                return entity;
            }
        }
    }
}
