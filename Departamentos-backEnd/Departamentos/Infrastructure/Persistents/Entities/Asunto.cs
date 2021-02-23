using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Departamentos.Infrastructure.Persistents.Entities
{
    public class Asunto
    {
        public short Id { get; set; }
        public string Nombre { get; set; }
        public string asunto { get; set; }
        public string Descripcion { get; set; }
    }
    public class AsuntoDTO
    {
        public string Nombre { get; set; }
        public string asunto { get; set; }
        public string Descripcion { get; set; }
    }
}
