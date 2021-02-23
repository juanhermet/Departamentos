using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Departamentos.Infrastructure.Persistents.Entities
{
    public class TipoCargo
    {
        public short Id { get; set; }
        public string Tipo { get; set; }
    }
    public class TipoCargoDTO
    {
        public string Tipo { get; set; }
    }
}
