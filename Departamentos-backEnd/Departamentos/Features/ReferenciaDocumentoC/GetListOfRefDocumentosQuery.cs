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

namespace Departamentos.Features.ReferenciaDocumentoC
{
    public class GetListOfRefDocumentosQuery
    {
        public class QueryResult
        {
            public List<ReferenciaDocumentoDTO> ReferenciaEntidades { get; set; }
        }

        public class Query : IRequest<QueryResult>
        {
            public long? IdDocumento { get; set; }
            public long? IdDocumentoReferenciado { get; set; }
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
                var Query = _DatabaseContext.ReferenciaDocumentos.AsQueryable();

                if (request.IdDocumento.HasValue)
                    Query = Query.Where(element => element.IdDocumento == request.IdDocumento);

                if (request.IdDocumentoReferenciado.HasValue)
                    Query = Query.Where(element => element.IdDocumentoReferenciado == request.IdDocumentoReferenciado);

                var result = await Query.ToListAsync();
                var results = _mapper.Map<List<ReferenciaDocumentoDTO>>(result);

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
                CreateMap<ReferenciaDocumento, ReferenciaDocumentoDTO>();
            }
        }
    }
}
