using MessagePack;
using Sistema_Control_de_Asistencia_Cervantes.Dominio;

namespace Sistema_Control_de_Asistencia_Cervantes.Dominio
{
    public partial class Usuario
    {
        public Usuario()
        {
            Usuario_Imparte_Cursos = new HashSet<Usuario_Imparte_Curso>();
            Usuario_Imparte_BloquesHorario = new HashSet<Usuario_Imparte_BloqueHorario>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string Apellido { get; set; } = null!;
        public string Contrasenha { get; set; } = null!;
        public Boolean Rol { get; set; }
        public string NombreUsuario { get; set; } = null!;

        public ICollection<Usuario_Imparte_Curso> Usuario_Imparte_Cursos { get; set; } = null!;

        public ICollection<Usuario_Imparte_BloqueHorario> Usuario_Imparte_BloquesHorario { get; set; } = null!;

    }
}
