using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Departamentos.Infrastructure.Persistents.Entities
{
    public class ReferenciaDocumento
    {
        public long Id { get; set; }
        public long IdDocumento { get; set; }
        public long IdDocumentoReferenciado { get; set; }
        [ForeignKey("IdDocumento")]
        public Nota Documento { get; set; }
        [ForeignKey("IdDocumentoReferenciado")]
        public Nota DocumentoReferenciado { get; set; }
    }
    public class ReferenciaDocumentoDTO
    {
        public NotaDTO Documento { get; set; }
        public NotaDTO DocumentoReferenciado { get; set; }
    }
}
