using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Departamentos.Infrastructure.Persistents.Entities
{
    public class DocenteTomaCargo
    {
        public long Id { get; set; }
        public DateTime Ingreso { get; set; }
        public DateTime Vencimiento { get; set; }
        public int IdCargo { get; set; }
        public int IdDocente { get; set; }
        [ForeignKey("IdCargo")]
        public Cargo Cargo { get; set; }
        [ForeignKey("IdDocente")]
        public Docente Docente { get; set; }
    }
    public class DocenteTomaCargoDTO
    {
        public DateTime Ingreso { get; set; }
        public DateTime Vencimiento { get; set; }
        public CargoDTO Cargo { get; set; }
        public DocenteDTO Docente { get; set; }
    }
}
