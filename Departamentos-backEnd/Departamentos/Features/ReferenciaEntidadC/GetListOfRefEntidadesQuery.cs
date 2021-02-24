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

namespace Departamentos.Features.ReferenciaEntidadC
{
    public class GetListOfRefEntidadesQuery
    {
        public class QueryResult
        {
            public List<ReferenciaEntidadDTO> ReferenciaEntidades { get; set; }
        }

        public class Query : IRequest<QueryResult>
        {
            public int? IdDocumento { get; set; }
            public short? IdEntidadReferenciada { get; set; }
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
                var Query = _DatabaseContext.ReferenciaEntidades.AsQueryable();

                if (request.IdDocumento.HasValue)
                    Query = Query.Where(element => element.IdDocumento == request.IdDocumento);

                if (request.IdEntidadReferenciada.HasValue)
                    Query = Query.Where(element => element.IdEntidadReferenciada == request.IdEntidadReferenciada);

                var result = await Query.ToListAsync();
                var results = _mapper.Map<List<ReferenciaEntidadDTO>>(result);

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
                CreateMap<ReferenciaEntidad, ReferenciaEntidadDTO>();
            }
        }
    }
}
