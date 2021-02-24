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

namespace Departamentos.Features.ReferenciaDocenteC
{
    public class GetListOfRefDocentesQuery
    {
        public class QueryResult
        {
            public List<ReferenciaDocenteDTO> ReferenciaEntidades { get; set; }
        }

        public class Query : IRequest<QueryResult>
        {
            public long? IdDocumento { get; set; }
            public long? IdDocenteReferenciado { get; set; }
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
                var Query = _DatabaseContext.ReferenciaDocentes.AsQueryable();

                if (request.IdDocumento.HasValue)
                    Query = Query.Where(element => element.IdDocumento == request.IdDocumento);

                if (request.IdDocenteReferenciado.HasValue)
                    Query = Query.Where(element => element.IdDocenteReferenciado == request.IdDocenteReferenciado);

                var result = await Query.ToListAsync();
                var results = _mapper.Map<List<ReferenciaDocenteDTO>>(result);

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
                CreateMap<ReferenciaDocente, ReferenciaDocenteDTO>();
                CreateMap<Documento, DocumentoDTO>();
            }
        }
    }
}
