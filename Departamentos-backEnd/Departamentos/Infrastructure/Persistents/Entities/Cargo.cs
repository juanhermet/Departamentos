using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Departamentos.Infrastructure.Persistents.Entities
{
    public class Cargo
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public short IdAsignatura { get; set; }
        public short IdTipoCargo { get; set; }
        public short IdEstadoCargo { get; set; }
        [ForeignKey("IdAsignatura")]
        public Asignatura Asignatura { get; set; }
        [ForeignKey("IdTipoCargo")]
        public TipoCargo TipoCargo { get; set; }
        [ForeignKey("IdEstadoCargo")]
        public EstadoCargo EstadoCargo { get; set; }
    }

    public class CargoDTO
    {
        public string Nombre { get; set; }
        public AsignaturaDTO Asignatura { get; set; }
        public TipoCargoDTO TipoCargo { get; set; }
        public EstadoCargoDTO EstadoCargo { get; set; }
    }
}
