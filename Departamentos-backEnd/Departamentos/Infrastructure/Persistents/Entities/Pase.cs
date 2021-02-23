using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Departamentos.Infrastructure.Persistents.Entities
{
    public class Pase
    {
        public long Id { get; set; }
        public DateTime Fecha { get; set; }
        public string Observaciones { get; set; }
        public long IdDocumento { get; set; }
        public int IdDocente { get; set; }
        public short IdEstadoTramite { get; set; }
       [ForeignKey("IdDocumento")]
        public Nota Documento { get; set; }
        [ForeignKey("IdDocente")]
        public Docente Docente { get; set; }
        [ForeignKey("IdEstadoTramite")]
        public EstadoTramite EstadoTramite { get; set; }
    }
    public class PaseDTO
    {
        public DateTime Fecha { get; set; }
        public string Observaciones { get; set; }
        public NotaDTO Documento { get; set; }
        public DocenteDTO Docente { get; set; }
        public EstadoTramiteDTO EstadoTramite { get; set; }
    }
}
