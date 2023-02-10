using API_Lab.Models;

namespace Sistema_Control_de_Asistencia_Cervantes.Dominio
{
    public partial class Curso
    {
        public Curso() {
            this.BloquesHorario = new HashSet<BloqueHorario>();
            this.Usuario_Imparte_Cursos = new HashSet<Usuario_Imparte_Curso>();
            this.Alumnos = new HashSet<Alumno>();
        }
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Seccion { get; set; } = null!;
        public string aula { get; set; } = null!;
        public int Anho { get; set; }

        public virtual ICollection<BloqueHorario> BloquesHorario { get; set; }

        public virtual ICollection<Usuario_Imparte_Curso> Usuario_Imparte_Cursos { get; set; }

        public virtual ICollection<Alumno> Alumnos { get; set; }

    }
}
