using AutoMapper;
using Departamentos.Infrastructure;
using Departamentos.Infrastructure.Persistents.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Departamentos.Features.PaseC
{
    public class GetListOfPasesQuery
    {
        public class QueryResult
        {
            public List<PaseDTO> ReferenciaEntidades { get; set; }
        }

        public class Query : IRequest<QueryResult>
        {
            public DateTime? Fecha { get; set; }
            public string Observaciones { get; set; }
            public long? IdDocumento { get; set; }
            public int? IdDocente { get; set; }
            public short? IdEstadoTramite { get; set; }
        }

        public class Handler : IRequestHandler<Query, QueryResult>
        {
            private DepartamentosContext _DatabaseContext;
            IMapper _mapper;

            public Handler(DepartamentosContext databaseContext, IMapper mapper)
            {
                _DatabaseContext = databaseContext;
                _mapper = mapper;
            }

            public async Task<QueryResult> Handle(Query request, CancellationToken cancellationToken)
            {
                var Query = _DatabaseContext.Pases.AsQueryable();

                if (request.Fecha.HasValue)
                    Query = Query.Where(element => element.Fecha == request.Fecha);

                if (request.IdDocumento.HasValue)
                    Query = Query.Where(element => element.IdDocumento == request.IdDocumento);

                if (request.IdDocente.HasValue)
                    Query = Query.Where(element => element.IdDocente == request.IdDocente);

                if (request.IdEstadoTramite.HasValue)
                    Query = Query.Where(element => element.IdEstadoTramite == request.IdEstadoTramite);

                if (!string.IsNullOrEmpty(request.Observaciones))
                    Query = Query.Where(element => element.Observaciones.Contains(request.Observaciones));

                var result = await Query.ToListAsync();
                var results = _mapper.Map<List<PaseDTO>>(result);

                return new QueryResult
                {
                    ReferenciaEntidades = results
                };
            }
        }

        public class MappingProfile : Profile
        {
            public MappingProfile()
            {
                CreateMap<Pase, PaseDTO>();
            }
        }
    }
}
