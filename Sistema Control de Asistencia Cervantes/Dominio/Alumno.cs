namespace Sistema_Control_de_Asistencia_Cervantes.Dominio
{
    public partial class Alumno
    {

        public Alumno() { 
            Cursos = new HashSet<Curso>();
            Encargados = new HashSet<Encargado>();
            Alumno_Asiste_BloqueHorarios = new HashSet<Alumno_Asiste_BloqueHorario>();
        }

        public int Id { get; set; }
        public String Cedula { get; set; } = null!;
        public String Nombre { get; set; } = null!;
        public String Apellidos { get; set; } = null!;

        public virtual ICollection<Curso> Cursos { get; set; }
        public virtual ICollection<Encargado> Encargados { get; set; }
        public virtual ICollection<Alumno_Asiste_BloqueHorario> Alumno_Asiste_BloqueHorarios { get; set; }




    }
}
