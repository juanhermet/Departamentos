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

namespace Departamentos.Features.TipoTramiteC
{
    public class GetListOfTipoTramiteQuery
    {
        public class QueryResult
        {
            public List<TipoTramiteDTO> TiposTramites { get; set; }
        }

        public class Query : IRequest<QueryResult>
        {
            public string Tipo { get; set; }
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
                var Query = _DatabaseContext.TipoTramites.AsQueryable();

                if (!string.IsNullOrEmpty(request.Tipo))
                    Query = Query.Where(element => element.Tipo.Contains(request.Tipo));

                var result = await Query.ToListAsync();
                var results = _mapper.Map<List<TipoTramiteDTO>>(result);

                return new QueryResult
                {
                    TiposTramites = results
                };
            }
        }

        public class MappingProfile : Profile
        {
            public MappingProfile()
            {
                CreateMap<TipoTramite, TipoTramiteDTO>();
            }
        }
    }
}
