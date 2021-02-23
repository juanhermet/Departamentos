using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Departamentos.Infrastructure.Persistents.Entities
{
    public class TipoDocumento
    {
        public short Id { get; set; }
        public string Tipo { get; set; }
    }
    public class TipoDocumentoDTO
    {
        public string Tipo { get; set; }
    }
}
