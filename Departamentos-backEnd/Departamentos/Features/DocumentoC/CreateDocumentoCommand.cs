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

namespace Departamentos.Features.DocumentoC
{
    public class CreateDocumentoCommand
    {
        public class Command : IRequest<CommandResult>
        {
            public long     Numero { get; set; }
            public int      Anio { get; set; }
            public string   DocNumeroOriginal { get; set; }
            public DateTime FechaIngreso { get; set; }
            public DateTime FechaSalida { get; set; }
            public short    IdTipoDocumento { get; set; }
            public short    IdEntidadOrigen { get; set; }
            public short    IdEntidadDestino { get; set; }
            public int      IdCargo { get; set; }
            public short    IdEstadoTramite { get; set; }
            public long     IdEtapaTramite { get; set; }
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

                RuleFor(command => command.Numero)
                    .NotEmpty()
                        .WithMessage("El código no debe ser vacío")
                    .NotNull()
                        .WithMessage("El código no debe ser vacío");

                RuleFor(command => command.Anio)
                    .NotEmpty()
                        .WithMessage("El año no debe ser vacío")
                    .NotNull()
                        .WithMessage("El año no debe ser vacío");

                RuleFor(command => command.DocNumeroOriginal)
                    .NotEmpty()
                        .WithMessage("El código original no debe ser vacío")
                    .NotNull()
                        .WithMessage("El código original no debe ser vacío");

                RuleFor(command => command.FechaIngreso)
                    .NotEmpty()
                        .WithMessage("La fecha de ingreso no debe ser vacía")
                    .NotNull()
                        .WithMessage("La fecha de ingreso no debe ser vacía");

                RuleFor(command => command.FechaSalida)
                    .NotEmpty()
                        .WithMessage("La fecha de salida no debe ser vacía")
                    .NotNull()
                        .WithMessage("La fecha de salida no debe ser vacía");

                RuleFor(command => command.IdTipoDocumento)
                    .NotEmpty()
                        .WithMessage("El tipo de documento no debe ser vacío")
                    .NotNull()
                        .WithMessage("El tipo de documento no debe ser vacío");

                RuleFor(command => command.IdEntidadOrigen)
                    .NotEmpty()
                        .WithMessage("La entidad origen no debe ser vacía")
                    .NotNull()
                        .WithMessage("La entidad origen no debe ser vacía");

                RuleFor(command => command.IdEntidadDestino)
                    .NotEmpty()
                        .WithMessage("La entidad destino no debe ser vacía")
                    .NotNull()
                        .WithMessage("La entidad destino no debe ser vacía");

                RuleFor(command => command.IdCargo)
                    .NotEmpty()
                        .WithMessage("El cargo no debe ser vacío")
                    .NotNull()
                        .WithMessage("El cargo no debe ser vacío");

                RuleFor(command => command.IdEstadoTramite)
                    .NotEmpty()
                        .WithMessage("El estado del trámite no debe ser vacío")
                    .NotNull()
                        .WithMessage("El estado del trámite no debe ser vacío");

                RuleFor(command => command.IdEtapaTramite)
                    .NotEmpty()
                        .WithMessage("La etapa del trámite no debe ser vacía")
                    .NotNull()
                        .WithMessage("La etapa del trámite no debe ser vacía");

                RuleFor(command => command.IdTipoDocumento)
                   .MustAsync(async (Id, cancelToken) =>
                   {
                       return !await _DatabaseContext.TipoDocumentos.AnyAsync
                       (element => element.Id == Id);
                   })
                       .WithMessage("Tipo documento no encontrado.");

                RuleFor(command => command.IdEntidadOrigen)
                   .MustAsync(async (Id, cancelToken) =>
                   {
                       return !await _DatabaseContext.Entidades.AnyAsync
                       (element => element.Id == Id);
                   })
                       .WithMessage("Entidad origen no encontrada.");

                RuleFor(command => command.IdEntidadDestino)
                   .MustAsync(async (Id, cancelToken) =>
                   {
                       return !await _DatabaseContext.Entidades.AnyAsync
                       (element => element.Id == Id);
                   })
                       .WithMessage("Entidad destino no encontrada.");

                RuleFor(command => command.IdCargo)
                   .MustAsync(async (Id, cancelToken) =>
                   {
                       return !await _DatabaseContext.Cargos.AnyAsync
                       (element => element.Id == Id);
                   })
                       .WithMessage("Cargo no encontrado.");

                RuleFor(command => command.IdEstadoTramite)
                   .MustAsync(async (Id, cancelToken) =>
                   {
                       return !await _DatabaseContext.EstadoTramites.AnyAsync
                       (element => element.Id == Id);
                   })
                       .WithMessage("Estado trámite no encontrado.");

                RuleFor(command => command.IdEtapaTramite)
                   .MustAsync(async (Id, cancelToken) =>
                   {
                       return !await _DatabaseContext.EtapaTramites.AnyAsync
                       (element => element.Id == Id);
                   })
                       .WithMessage("Estapa trámite no encontrada.");
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
                var foundTipoDocument = await _DatabaseContext.Documentos.FindAsync(request.IdTipoDocumento);
                var founddEntidadOrigen = await _DatabaseContext.Entidades.FindAsync(request.IdEntidadOrigen);
                var founddEntidadDestino = await _DatabaseContext.Entidades.FindAsync(request.IdEntidadDestino);
                var foundCargo = await _DatabaseContext.Cargos.FindAsync(request.IdCargo);
                var foundEstadoTram = await _DatabaseContext.EstadoTramites.FindAsync(request.IdEstadoTramite);
                var foundEtapaTram = await _DatabaseContext.EtapaTramites.FindAsync(request.IdEtapaTramite);

                var newElement = new Documento
                {
                    Numero = request.Numero,
                    anio
                };

                _DatabaseContext.Documentos.Add(newElement);

                await _DatabaseContext.SaveChangesAsync();

                return new CommandResult { Id = newElement.Id };
            }
        }
    }
}
