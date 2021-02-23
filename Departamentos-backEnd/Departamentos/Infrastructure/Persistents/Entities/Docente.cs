using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Departamentos.Infrastructure.Persistents.Entities
{
    public class Docente
    {
        public int Id { get; set; }
        public long Legajo { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public string Cuil { get; set; }
        public bool EsDirectivo { get; set; }
    }
    public class DocenteDTO
    {
        public long Legajo { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public string Cuil { get; set; }
        public bool EsDirectivo { get; set; }
    }
}
