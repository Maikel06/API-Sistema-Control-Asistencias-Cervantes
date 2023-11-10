using MessagePack;
using Sistema_Control_de_Asistencia_Cervantes.Dominio;

namespace Sistema_Control_de_Asistencia_Cervantes.Dominio
{
    public partial class Usuario
    {
        public Usuario()
        {
        }

        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string Apellido { get; set; } = null!;
        public string Contrasenha { get; set; } = null!;
        public Boolean Rol { get; set; }
        public string NombreUsuario { get; set; } = null!;

    }
}
