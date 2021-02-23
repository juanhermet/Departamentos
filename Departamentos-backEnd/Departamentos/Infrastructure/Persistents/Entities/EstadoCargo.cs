using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Departamentos.Infrastructure.Persistents.Entities
{
    public class EstadoCargo
    {
        public short Id { get; set; }
        public string Nombre { get; set; }
    }
    public class EstadoCargoDTO
    {
        public string Nombre { get; set; }
    }
}
