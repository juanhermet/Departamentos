using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Departamentos.Infrastructure.Persistents.Entities
{
    public class Nota
    {
        public long Id { get; set; }
        public long Numero { get; set; }
        public int Año { get; set; }
        public string DocNumeroOriginal { get; set; }
        public DateTime FechaIngreso { get; set; }
        public DateTime FechaSalida { get; set; }
        public short IdTipoDocumento { get; set; }
        public short IdEntidadOrigen { get; set; }
        public short IdEntidadDestino { get; set; }
        public int IdCargo { get; set; }
        public short IdEstadoTramite { get; set; }
        public long IdEtapaTramite { get; set; }
        [ForeignKey("IdTipoDocumento")]
        public TipoDocumento TipoDocumento { get; set; }
        [ForeignKey("IdEntidadOrigen")]
        public Entidad EntidadOrigen { get; set; }
        [ForeignKey("IdEntidadDestino")]
        public Entidad EntidadDestino { get; set; }
        [ForeignKey("IdEstadoTramite")]
        public EstadoTramite EstadoTramite { get; set; }
        [ForeignKey("IdEtapaTramite")]
        public EtapaTramite EtapaTramite { get; set; }
        [ForeignKey("IdCargo")]
        public Cargo Cargo { get; set; }
    }
    public class NotaDTO
    {
        public long Numero { get; set; }
        public int Año { get; set; }
        public string DocNumeroOriginal { get; set; }
        public DateTime FechaIngreso { get; set; }
        public DateTime FechaSalida { get; set; }
        public TipoDocumentoDTO TipoDocumento { get; set; }
        public EntidadDTO EntidadOrigen { get; set; }
        public EntidadDTO EntidadDestino { get; set; }
        public EstadoTramiteDTO EstadoTramite { get; set; }
        public EtapaTramiteDTO EtapaTramite { get; set; }
        public CargoDTO Cargo { get; set; }
    }
}
