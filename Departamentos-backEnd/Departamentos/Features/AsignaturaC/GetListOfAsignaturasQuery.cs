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

namespace Departamentos.Controllers.AsignaturaC
{
    public class GetListOfAsignaturasQuery
    {
        public class QueryResult
        {
            public List<AsignaturaDTO> Asignaturas { get; set; }
        }

        public class Query : IRequest<QueryResult>
        {
            public string Nombre { get; set; }
            public int? IdCatedra { get; set; }
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
                var Query = _DatabaseContext.Asignaturas.AsQueryable();

                if (request.IdCatedra.HasValue)
                    Query = Query.Where(element => element.IdCatedra == request.IdCatedra);

                if (!string.IsNullOrEmpty(request.Nombre))
                    Query = Query.Where(element => element.Nombre.Contains(request.Nombre));

                var result = await Query.ToListAsync();
                var results = _mapper.Map<List<AsignaturaDTO>>(result);

                return new QueryResult
                {
                    Asignaturas = results
                };
            }
        }

        public class MappingProfile : Profile
        {
            public MappingProfile()
            {
                CreateMap<Asignatura, AsignaturaDTO>();
            }
        }
    }
}
