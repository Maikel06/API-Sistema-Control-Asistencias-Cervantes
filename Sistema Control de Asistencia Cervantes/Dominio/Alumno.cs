namespace Sistema_Control_de_Asistencia_Cervantes.Dominio
{
    public partial class Alumno
    {
        
        public Alumno() { 
            Alumno_Inscribe_Cursos = new HashSet<Alumno_Inscribe_Curso>();
            Encargado_Cargo_Alumnos = new HashSet<Encargado_Cargo_Alumno>();
            Alumno_Asiste_BloqueHorarios = new HashSet<Alumno_Asiste_BloqueHorario>();
        }

        public int Id { get; set; }
        public String Cedula { get; set; } = null!;
        public String Nombre { get; set; } = null!;
        public String Apellidos { get; set; } = null!;

        public virtual ICollection<Alumno_Inscribe_Curso> Alumno_Inscribe_Cursos { get; set; }
        public virtual ICollection<Encargado_Cargo_Alumno> Encargado_Cargo_Alumnos { get; set; }
        public virtual ICollection<Alumno_Asiste_BloqueHorario> Alumno_Asiste_BloqueHorarios { get; set; }




    }
}
