using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Departamentos.Infrastructure.Persistents.Entities
{
    public class ReferenciaDocente
    {
        public long Id { get; set; }
        public long IdDocumento { get; set; }
        public int IdDocenteReferenciado { get; set; }
        [ForeignKey("IdDocumento")]
        public Nota Documento { get; set; }
        [ForeignKey("IdDocenteReferenciado")]
        public Docente DocenteReferenciado { get; set; }
    }
    public class ReferenciaDocenteDTO
    {
        public NotaDTO Documento { get; set; }
        public DocenteDTO DocenteReferenciado { get; set; }
    }
}
