using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Departamentos.Infrastructure.Persistents.Entities
{
    public class ReferenciaEntidad
    {
        public long Id { get; set; }
        public long IdDocumento { get; set; }
        public short IdEntidadReferenciada { get; set; }
        [ForeignKey("IdDocumento")]
        public Documento Documento { get; set; }
        [ForeignKey("IdEntidadReferenciada")]
        public Entidad EntidadReferenciada { get; set; }
    }
    public class ReferenciaEntidadDTO
    {
        public NotaDTO Documento { get; set; }
        public EntidadDTO EntidadReferenciada { get; set; }
    }
}
