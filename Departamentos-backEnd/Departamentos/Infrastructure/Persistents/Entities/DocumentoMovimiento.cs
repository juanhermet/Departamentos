using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Departamentos.Infrastructure.Persistents.Entities
{
    public class DocumentoMovimiento
    {
        public long Id { get; set; }
        public DateTime Fecha { get; set; }
        public string Observaciones { get; set; }
        public long IdDocumento { get; set; }
        public short IdEntidadOrigen { get; set; }
        public short IdEntidadDestino { get; set; }
        public long IdPase { get; set; }
        public int IdDocente { get; set; }
        [ForeignKey("IdDocumento")]
        public Documento Documento { get; set; }
        [ForeignKey("IdEntidadOrigen")]
        public Entidad EntidadOrigen { get; set; }
        [ForeignKey("IdEntidadDestino")]
        public Entidad EntidadDestino { get; set; }
        [ForeignKey("IdPase")]
        public Pase Pase { get; set; }
        [ForeignKey("IdDocente")]
        public Docente Docente { get; set; }
    }
    public class DocumentoMovimientoDTO
    {
        public DateTime Fecha { get; set; }
        public string Observaciones { get; set; }
        public NotaDTO Documento { get; set; }
        public EntidadDTO EntidadOrigen { get; set; }
        public EntidadDTO EntidadDestino { get; set; }
        public PaseDTO Pase { get; set; }
        public DocenteDTO Docente { get; set; }
    }
}
