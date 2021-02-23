using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Departamentos.Infrastructure.Persistents.Users
{
    public class Usuarios : IdentityUser<string>
    {
        public int UsuarioId { get; set; }
        public string Nombre { get; set; }
    }
}
