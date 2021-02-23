using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Departamentos.Infrastructure.Persistents.Entities
{
    public class EstadoTramite
    {
        public short Id { get; set; }
        public string Nombre { get; set; }
    }
    public class EstadoTramiteDTO
    {
        public string Nombre { get; set; }
    }
}
