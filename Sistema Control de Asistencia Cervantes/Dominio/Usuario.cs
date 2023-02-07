using System;
using System.Collections.Generic;

namespace API_Lab.Models
{
    public partial class Usuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string Apellido { get; set; } = null!;
        public string Contraseña { get; set; } = null!;
        public Boolean Rol { get; set; }
        public string NombreUsuario { get; set; } = null!;

    }
}
