using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Departamentos.Infrastructure.Persistents.Entities
{
    public class EtapaTramite
    {
        public long Id { get; set; }
        public short IdAsunto { get; set; }
        public short IdTipoTramite { get; set; }
        [ForeignKey("IdAsunto")]
        public Asunto Asunto { get; set; }
        [ForeignKey("IdTipoTramite")]
        public TipoTramite TipoTramite { get; set; }
    }
    public class EtapaTramiteDTO
    {
        public AsuntoDTO Asunto { get; set; }
        public TipoTramiteDTO TipoTramite { get; set; }
    }
}
