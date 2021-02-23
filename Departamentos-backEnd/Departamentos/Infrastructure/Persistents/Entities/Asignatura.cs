using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Departamentos.Infrastructure.Persistents.Entities
{
    public class Asignatura
    {
        public short Id { get; set; }
        public string Nombre { get; set; }
        public short IdCatedra { get; set; }
        [ForeignKey("IdCatedra")]
        public Catedra Catedra { get; set; }
    }

    public class AsignaturaDTO
    {
        public string Nombre { get; set; }
        public CatedraDTO Catedra { get; set; }
    }
}
