﻿using AutoMapper;
using Departamentos.Infrastructure;
using Departamentos.Infrastructure.Persistents.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Departamentos.Features.TipoDocumentoC
{
    public class GetListOfTipoDocumentoQuery
    {
        public class QueryResult
        {
            public List<TipoDocumentoDTO> TiposDocumentos { get; set; }
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
                var Query = _DatabaseContext.TipoDocumentos.AsQueryable();

                if (!string.IsNullOrEmpty(request.Tipo))
                    Query = Query.Where(element => element.Tipo.Contains(request.Tipo));

                var result = await Query.ToListAsync();
                var results = _mapper.Map<List<TipoDocumentoDTO>>(result);

                return new QueryResult
                {
                    TiposDocumentos = results
                };
            }
        }

        public class MappingProfile : Profile
        {
            public MappingProfile()
            {
                CreateMap<TipoDocumento, TipoDocumentoDTO>();
            }
        }
    }
}
