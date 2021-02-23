using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Departamentos.Infrastructure.Persistents.Entities
{
    public class Entidad
    {
        public short Id { get; set; }
        public string Nombre { get; set; }
    }
    public class EntidadDTO
    {
        public string Nombre { get; set; }
    }
}
